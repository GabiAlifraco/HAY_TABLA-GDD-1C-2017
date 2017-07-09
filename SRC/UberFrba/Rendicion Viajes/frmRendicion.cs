using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Rendicion_Viajes
{
    public partial class frmRendicion : Form
    {
        public DBAccess Access { get; set; }
        public string Conexion { get; set; }
        public ValidacionesAbm Validador { get; set; }
        public decimal totalRendicion;
        public frmRendicion()
        {
            InitializeComponent();
            Access = new DBAccess();
            cargarChoferes();//Todos los choferes habilitados
            cargarTodosLosTurnos();//Todos los turnos habilitados, el chofer puede haber realizado viajes en turnos que estaban habilitados y ya no lo estan.Estos viejas deben pagarse de todas formas.
            Validador = new ValidacionesAbm();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

         }
        


        private void cargarChoferes()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

                
                string query = String.Format("SELECT Cho_Id, Cho_Nombre, Cho_Apellido FROM[HAY_TABLA].[Chofer] C JOIN[HAY_TABLA].[USUARIO_POR_ROL] UR ON  C.Cho_Usuario = UR.Nombre_Usuario AND  Habilitado = 1 AND Id_Rol = 3");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBoxChoferes.Items.Add(new KeyValuePair<int, string>((int)dr["Cho_Id"], dr["Cho_Nombre"].ToString() + " " + dr["Cho_Apellido"].ToString()));
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        void cargarTodosLosTurnos()
        {
            listBoxTurnos.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion] FROM[HAY_TABLA].[Turno]");
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {

                            decimal HoraInicio = (decimal)dr["Turno_HoraInicio"];
                            decimal HInicio = Math.Truncate(HoraInicio / 100);
                            string Minicio = (HoraInicio % 100).ToString();
                            decimal HoraFin = (decimal)dr["Turno_HoraFin"];
                            decimal HFin = Math.Truncate(HoraFin / 100);
                            string MFin = (HoraFin % 100).ToString();

                            if (Minicio.Length == 1) { Minicio = "0" + Minicio; }
                            if (MFin.Length == 1) { MFin = "0" + MFin; }

                            listBoxTurnos.Items.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString() + " " + HInicio.ToString() + ":" + Minicio.ToString() + " a " + HFin.ToString() + ":" + MFin.ToString()));

                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRendicion_Click(object sender, EventArgs e)
        {
            btnConfirmarRendicion.Visible = false;
            btnCancelarRendicion.Visible = false;
            if (Validador.validarFechaCampo(txtFechaRendicion.Text, "La fecha de rendicion"))
            {

                if (listBoxChoferes.SelectedIndex != -1)
                {
                    if (listBoxTurnos.SelectedIndex != -1)
                    {
                        if (txtPorcentajeDePago.Text != "0,00") {
                            MostrarRendicion();
                        } else {
                            MessageBox.Show("Se debe ingresar un porcentaje mayor a 0");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un turno");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un chofer");
                }
            }
        }

        private bool validarQueNoSeHayaRendidoEsaFecha(SqlConnection conexion)
        {
            DateTime FR = (DateTime.Parse(txtFechaRendicion.Text));

            KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
            KeyValuePair<int, string> turnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;
            string query = String.Format("SELECT [Rendicion_Nro],[Cho_Id],[Turno_Id],[Rendicion_Fecha],[Rendicion_Total] FROM [HAY_TABLA].[Rendicion] WHERE Cho_Id = " + choferSeleccionado.Key.ToString() + " AND Turno_Id = " + turnoSeleccionado.Key.ToString() + " AND  Rendicion_Fecha BETWEEN '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 00:00:00.000' AND '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 23:59:59.000'");

            SqlCommand cmd2 = new SqlCommand(query, conexion);
            try
            {
                conexion.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    MessageBox.Show("No se puede realizar la rendicion de viajes porque ya fue hecha anteriormente la rendicion de viajes para la fecha '" + txtFechaRendicion.Text + "' y " + turnoSeleccionado.Value + " para el chofer '" + choferSeleccionado.Value + "'. Nro de Rendicion:" + dr["Rendicion_Nro"].ToString() + " - Total Rendicion:" + dr["Rendicion_Total"].ToString());
                    return false;
                }
                dr.Close();
                return true;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void cargarViajesDeLaRendicion(SqlConnection conexion)
        {

            totalRendicion = 0;
            decimal totalKms = 0;
            int totalViajes = 0;

            DataTable dtRendicion = new DataTable("Rendicion de cuentas");

            DataColumn cCantidadKms = new DataColumn("Kms");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cImporte = new DataColumn("Importe");
            DataColumn cRendicion = new DataColumn("Rendicion");

            dtRendicion.Columns.Add(cCantidadKms);
            dtRendicion.Columns.Add(cFecha);
            dtRendicion.Columns.Add(cImporte);
            dtRendicion.Columns.Add(cRendicion);

            dgvRendicion.DataSource = dtRendicion;

            DateTime FR = (DateTime.Parse(txtFechaRendicion.Text));
            KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
            KeyValuePair<int, string> turnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;
            string query = String.Format("SELECT [Vi_CantKilometros], Vi_Inicio AS fecha ,[Vi_ImporteTotal] FROM[HAY_TABLA].[Viaje] V WHERE Vi_IdChofer = " + choferSeleccionado.Key.ToString() + " AND Vi_IdTurno = " + turnoSeleccionado.Key.ToString() + " AND  Vi_Inicio BETWEEN @FechaInicio AND @FechaFin");
            SqlCommand cmd = new SqlCommand(query, conexion);

            DateTime fechaInicio = DateTime.Parse(txtFechaRendicion.Text);
            SqlParameter param = new SqlParameter("@FechaInicio", fechaInicio);
            param.SqlDbType = System.Data.SqlDbType.DateTime;
            cmd.Parameters.Add(param);

            DateTime fechaFin = DateTime.Parse(txtFechaRendicion.Text);
            fechaFin = fechaInicio.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlParameter param2 = new SqlParameter("@FechaFin", fechaFin);
            param.SqlDbType = System.Data.SqlDbType.DateTime;
            cmd.Parameters.Add(param2);
            
            try
            {
                conexion.Close();
                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Vi_CantKilometros"].ToString() != "")
                    {
                        DataRow row = dtRendicion.NewRow();
                        row["Kms"] = dr["Vi_CantKilometros"].ToString();
                        row["Fecha"] = dr["fecha"].ToString();
                        row["Importe"] = dr["Vi_ImporteTotal"].ToString();
                        row["Rendicion"] = Convert.ToDecimal(txtPorcentajeDePago.Text) * (decimal)dr["Vi_ImporteTotal"] / 100;

                        totalRendicion += Convert.ToDecimal(txtPorcentajeDePago.Text) * (decimal)dr["Vi_ImporteTotal"] / 100;
                        totalKms += (decimal)dr["Vi_CantKilometros"];
                        totalViajes++;
                        dtRendicion.Rows.Add(row);
                    }
                }

                if (totalViajes > 0)
                {

                    dr.Close();
                    dgvRendicion.DataSource = dtRendicion;
                    dgvRendicion.AutoResizeColumns();
                    dgvRendicion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    txtCantidadViajes.Text = "Cantidad de viajes de la rendicion:" + Convert.ToString(totalViajes);
                    txtCantKms.Text = "Cantidad total de kms:" + Convert.ToString(totalKms);
                    txtImporteTotal.Text = "Rendicion total:" + Convert.ToString(Math.Round(totalRendicion, 2));

                    btnConfirmarRendicion.Visible = true;
                    btnCancelarRendicion.Visible = true;
                    btnRendicion.Visible = false;
                    listBoxChoferes.Enabled = false;
                    listBoxTurnos.Enabled = false;
                    txtFechaRendicion.Enabled = false;
                    txtPorcentajeDePago.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No hay viajes registrados en la fecha '" + txtFechaRendicion.Text + "' y " + turnoSeleccionado.Value + " del chofer '" + choferSeleccionado.Value + "'");
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void MostrarRendicion()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                if (validarQueNoSeHayaRendidoEsaFecha(conexion)) {
                    cargarViajesDeLaRendicion(conexion);

                }
                else{
                    //No se puede hacer rendicion, ya fue hecha antes.
                }

            }
           
        }

        private void HacerRendicion(){
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

                DateTime FR = (DateTime.Parse(txtFechaRendicion.Text));
                KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                KeyValuePair<int, string> turnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;
                try
                {
                    conexion.Open();
                    string query = String.Format("INSERT INTO[HAY_TABLA].[Rendicion] (Cho_Id,Turno_Id,Rendicion_Fecha,Rendicion_Total) OUTPUT Inserted.Rendicion_Nro VALUES (@Cho_Id,@Turno_Id,@Rendicion_Fecha,@Rendicion_Total)");
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    SqlParameter param = new SqlParameter("@Cho_Id", choferSeleccionado.Key.ToString());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Turno_Id", turnoSeleccionado.Key.ToString());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rendicion_Fecha", FR);
                    param.SqlDbType = System.Data.SqlDbType.DateTime;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rendicion_Total", Math.Round(totalRendicion, 2));
                    param.SqlDbType = System.Data.SqlDbType.Decimal;
                    cmd.Parameters.Add(param);

                    decimal nroRendicon =(decimal)cmd.ExecuteScalar();


                    query = String.Format("SELECT [Id_Viaje] FROM[HAY_TABLA].[Viaje] V WHERE Vi_IdChofer = " + choferSeleccionado.Key.ToString() + " AND Vi_IdTurno = " + turnoSeleccionado.Key.ToString() + " AND  Vi_Inicio BETWEEN '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 00:00:00.000' AND '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 23:59:59.000'");
                    cmd.CommandText = query;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<string> idsViajesRendicion = new List<string>();
                    while (dr.Read())
                    {
                        idsViajesRendicion.Add(dr["Id_Viaje"].ToString());
                    }
                    dr.Close();

                    foreach (string idViaje in idsViajesRendicion)
                    {
                        query = String.Format("INSERT INTO [HAY_TABLA].[Detalle_Viaje_Rendicion] (Rendicion_Nro,Id_Viaje,PorcentajeDePago) VALUES (@NroRendi,@IdVi,@PorcentajePago)");
                        SqlCommand cmd2 = new SqlCommand(query, conexion);                       

                        param = new SqlParameter("@NroRendi", nroRendicon.ToString());
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        cmd2.Parameters.Add(param);

                        param = new SqlParameter("@IdVi", idViaje);
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        cmd2.Parameters.Add(param);
                        
                        param = new SqlParameter("@PorcentajePago", Math.Round(totalRendicion, 2));
                        param.SqlDbType = System.Data.SqlDbType.Decimal;
                        cmd2.Parameters.Add(param);

                        cmd2.ExecuteNonQuery();

                    }


                    MessageBox.Show("Rendicion creada exitosamente. NRO Rendicon: " + nroRendicon + " Importe total:$" + Math.Round(totalRendicion, 2).ToString());
                    dgvRendicion.DataSource = null;
                    btnConfirmarRendicion.Visible = false;
                    btnCancelarRendicion.Visible = false;
                    btnRendicion.Visible = true;
                    listBoxChoferes.Enabled = true;
                    listBoxTurnos.Enabled = true;
                    txtFechaRendicion.Enabled = true;
                    txtPorcentajeDePago.Enabled = true;

                    txtCantKms.Text = "";
                    txtCantidadViajes.Text = "";
                    txtImporteTotal.Text = "";

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HacerRendicion();
        }

        private void btnCancelarRendicion_Click(object sender, EventArgs e)
        {
            dgvRendicion.DataSource = null;
            btnConfirmarRendicion.Visible = false;
            btnCancelarRendicion.Visible = false;
            btnRendicion.Visible = true;
            listBoxChoferes.Enabled = true;
            listBoxTurnos.Enabled = true;
            txtFechaRendicion.Enabled = true;
            txtPorcentajeDePago.Enabled = true;


            txtCantKms.Text = "";
            txtCantidadViajes.Text = "";
            txtImporteTotal.Text = "";

        }
    }
}
