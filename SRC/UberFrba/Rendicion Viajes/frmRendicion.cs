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
        public frmRendicion()
        {
            InitializeComponent();
            Access = new DBAccess();
            cargarChoferes();
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

        void cargarTurnosDelChofer()
        {
            listBoxTurnos.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                string query = String.Format("SELECT Turno.[Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion] FROM[HAY_TABLA].[AsignacionDeTurnos] INNER JOIN[HAY_TABLA].Turno ON Turno.Turno_Id = AsignacionDeTurnos.Turno_Id WHERE AsignacionDeTurnos.Cho_Id = " + choferSeleccionado.Key.ToString() + "ORDER BY Turno.[Turno_Id] ASC");
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                            listBoxTurnos.Items.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()));

                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTurnosDelChofer();
        }

        private void btnRendicion_Click(object sender, EventArgs e)
        {
            if (Validador.validarFechaCampo(txtFechaRendicion.Text, "La fecha de rendicion"))
            {

                if (listBoxChoferes.SelectedIndex != -1)
                {
                    if (listBoxTurnos.SelectedIndex != -1)
                    {
                        if (txtPorcentajeDePago.Text != "") {
                            HacerRedencion();
                        } else {
                            MessageBox.Show("Se debe ingresar un porcentaje de pago");
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

        void HacerRedencion()
        {
            DataTable dtRendicion = new DataTable("Factura");

            DataColumn cCantidadKms = new DataColumn("Kms");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cImporte = new DataColumn("Importe");
            DataColumn cRendicion = new DataColumn("Rendicion");

            dtRendicion.Columns.Add(cCantidadKms);
            dtRendicion.Columns.Add(cFecha);
            dtRendicion.Columns.Add(cImporte);
            dtRendicion.Columns.Add(cRendicion);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                decimal totalRendicion = 0;
                decimal totalKms = 0;
                int totalViajes = 0;
                DateTime FR = (DateTime.Parse(txtFechaRendicion.Text));

                KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                KeyValuePair<int, string> turnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;

                
                string query = String.Format("SELECT [Vi_CantKilometros], Vi_Inicio AS fecha ,[Vi_ImporteTotal] FROM[HAY_TABLA].[Viaje] V WHERE Vi_IdChofer = " + choferSeleccionado.Key.ToString() + " AND Rendicion_nro IS NOT NULL AND Vi_IdTurno = " + turnoSeleccionado.Key.ToString() + " AND  Vi_Inicio BETWEEN '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 00:00:00.000' AND '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 23:59:59.000'");
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();
                    while (dr.Read())
                    {
                        MessageBox.Show("Ya fue hecha una rendicion para esa fecha y ese turno para ese chofer");
                        return;
                    }
                    dr.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                query = String.Format("SELECT [Vi_CantKilometros], Vi_Inicio AS fecha ,[Vi_ImporteTotal] FROM[HAY_TABLA].[Viaje] V WHERE Vi_IdChofer = " + choferSeleccionado.Key.ToString() + " AND Rendicion_nro IS NULL AND Vi_IdTurno = " + turnoSeleccionado.Key.ToString() + " AND  Vi_Inicio BETWEEN '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 00:00:00.000' AND '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 23:59:59.000'");
                SqlCommand cmd = new SqlCommand(query, conexion);
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
                            row["Rendicion"] = Convert.ToDecimal(txtPorcentajeDePago.Text)  * (decimal)dr["Vi_ImporteTotal"] / 100  ;

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
                        txtImporteTotal.Text = "Rendicion total:" + Convert.ToString(Math.Round(totalRendicion,2));

                        query = String.Format("INSERT INTO[HAY_TABLA].[Rendicion] (Cho_Id,Turno_Id,Rendicion_Fecha,Rendicion_Total,PorcentajeDePago) OUTPUT Inserted.Rendicion_Nro VALUES (@Cho_Id,@Turno_Id,@Rendicion_Fecha,@Rendicion_Total,@PorcentajeDePago)");

                        cmd.CommandText = query;

                        SqlParameter param = new SqlParameter("@Cho_Id", choferSeleccionado.Key.ToString());
                        param.SqlDbType = System.Data.SqlDbType.Decimal;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Turno_Id", turnoSeleccionado.Key.ToString());
                        param.SqlDbType = System.Data.SqlDbType.Decimal;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@Rendicion_Fecha", FR);
                        param.SqlDbType = System.Data.SqlDbType.DateTime;
                        cmd.Parameters.Add(param);
                        
                        param = new SqlParameter("@Rendicion_Total", Math.Round(totalRendicion,2));
                        param.SqlDbType = System.Data.SqlDbType.Decimal;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@PorcentajeDePago", Convert.ToDecimal(txtPorcentajeDePago.Text));
                        param.SqlDbType = System.Data.SqlDbType.Decimal;
                        cmd.Parameters.Add(param);

                        Decimal nroRendicon = (Decimal)cmd.ExecuteScalar();

                        query = String.Format("UPDATE [HAY_TABLA].[Viaje] SET Rendicion_Nro = " + nroRendicon.ToString() + " WHERE Vi_IdTurno = " + turnoSeleccionado.Key.ToString() + " AND Vi_IdChofer = " + choferSeleccionado.Key.ToString() + "AND Rendicion_nro IS NULL AND  Vi_Inicio BETWEEN '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 00:00:00.000' AND '" + FR.Year + "-" + FR.Month + "-" + FR.Day + " 23:59:59.000'");

                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();


                    }
                    else
                    {
                        MessageBox.Show("No hay viajes para  entre esas fechas");
                    }




                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
