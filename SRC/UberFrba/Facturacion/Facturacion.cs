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

namespace UberFrba.Facturacion
{
    public partial class frmFacturacion : Form
    {
        public DBAccess Access { get; set; }
        public string Conexion { get; set; }
        public ValidacionesAbm Validador { get; set; }
        decimal totalFactura;
        DateTime fechaInicio;
        DateTime fechaFin;
        public frmFacturacion()
        {
            InitializeComponent();
            Access = new DBAccess();
            cargar_clientes();
            Validador = new ValidacionesAbm();

            fechaInicio = new DateTime(Access.fechaAño(), Access.fechaMes(), 1);
            fechaFin = fechaInicio.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
            fecha_inicio.Text = fechaInicio.Day + "/" + fechaInicio.Month + "/" + fechaInicio.Year;
            fecha_fin.Text = fechaFin.Day + "/" + fechaFin.Month + "/" + fechaFin.Year;

        }



        private void cargar_clientes()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT* FROM[HAY_TABLA].[Cliente] C JOIN[HAY_TABLA].[Usuarios] U on Cli_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] UR ON UR.Nombre_Usuario = U.Usu_Username WHERE UR.Id_Rol = 2 AND UR.Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBoxCliente.Items.Add(new KeyValuePair<int, string>((int)dr["Cli_Id"], dr["CLI_Nombre"].ToString() + " " + dr["Cli_Apellido"].ToString()));
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Facturar()
        {


            KeyValuePair<int, string> ClienteSeleccionado = (KeyValuePair<int, string>)listBoxCliente.SelectedItem;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                string query = String.Format("INSERT INTO[HAY_TABLA].[Factura] (Factura_Fecha_Inicio,Factura_Fecha_Fin,Cli_Id,Factura_Total)  OUTPUT Inserted.Factura_Nro VALUES (@FechaI,@FechaFin,@ClienteId,@ImporteTotal)");
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@FechaI", fechaInicio);
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FechaFin", fechaFin);
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ClienteId", ClienteSeleccionado.Key.ToString());
                param.SqlDbType = System.Data.SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@ImporteTotal", totalFactura);
                param.SqlDbType = System.Data.SqlDbType.Decimal;
                cmd.Parameters.Add(param);



                Decimal nroFactura = (Decimal)cmd.ExecuteScalar();


                
                query = String.Format("SELECT Id_Viaje, [Vi_CantKilometros], Vi_Inicio AS fecha ,[Vi_ImporteTotal] FROM [HAY_TABLA].[Viaje] V WHERE Vi_IdCliente = " + ClienteSeleccionado.Key.ToString() + " AND  Vi_Inicio BETWEEN @FechaInicio AND @FechaF");
                cmd.CommandText = query;

                DateTime fechaActual = new DateTime(Access.fechaAño(), Access.fechaMes(), Access.fechaDia());
                param = new SqlParameter("@FechaInicio", fechaInicio);
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FechaF", fechaFin);
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);


                SqlDataReader dr = cmd.ExecuteReader();
                List<string> idsViajesFactura = new List<string>();
                while (dr.Read())
                {
                    idsViajesFactura.Add(dr["Id_Viaje"].ToString());
                }
                dr.Close();

                foreach (string idViaje in idsViajesFactura)
                {
                    query = String.Format("INSERT INTO [HAY_TABLA].[Detalle_Viaje_Facturacion] (Factura_Nro,Id_Viaje) VALUES (@NroFact,@IdVi)");
                    SqlCommand cmd2 = new SqlCommand(query, conexion);

                    param = new SqlParameter("@NroFact", nroFactura.ToString());
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    cmd2.Parameters.Add(param);

                    param = new SqlParameter("@IdVi", idViaje);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    cmd2.Parameters.Add(param);

                    cmd2.ExecuteNonQuery();

                }


                MessageBox.Show("Factura creada exitosamente. Nro de factura:" + nroFactura + "  Importe Total:$" + totalFactura);
                dgvFactura.DataSource = null;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                btnFacturar.Visible = true;
                listBoxCliente.Enabled = true;

                txtCantKms.Text = "";
                txtCantidadViajes.Text = "";
                txtImporteTotal.Text = "";

            }
        }


        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnFacturar_Click(object sender, EventArgs e)
        {
            mostrarFactura();
        }

        private void mostrarFactura() {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                if (validarQueNoSeHayaFacturadoEsaFecha(conexion))
                {
                    cargarViajesDeLaFactura(conexion);

                }
                else
                {

                }

            }
        }

        private bool validarQueNoSeHayaFacturadoEsaFecha(SqlConnection conexion) {

            KeyValuePair<int, string> clienteSeleccionado = (KeyValuePair<int, string>)listBoxCliente.SelectedItem;
            string query = String.Format("SELECT [Factura_Nro],[Factura_Fecha_Inicio],[Factura_Fecha_Fin],[Cli_Id],[Factura_Total] FROM [HAY_TABLA].[Factura] WHERE Cli_Id = " + clienteSeleccionado.Key.ToString() + " AND  @FechaActual BETWEEN [Factura_Fecha_Inicio] AND [Factura_Fecha_Fin]");

            SqlCommand cmd2 = new SqlCommand(query, conexion);

            DateTime fechaActual = new DateTime(Access.fechaAño(), Access.fechaMes(), Access.fechaDia());
            SqlParameter param = new SqlParameter("@FechaActual", fechaActual);
            param.SqlDbType = System.Data.SqlDbType.DateTime;
            cmd2.Parameters.Add(param);

            try
            {
                conexion.Open();
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    MessageBox.Show("No se puede realizar factura. La factura del cliente '" + clienteSeleccionado.Value + "' ya fue realizada anteriormente (Fecha de inicio:" + fechaInicio.Day + "/" + fechaInicio.Month + "/" + fechaInicio.Year + " Fecha de fin: " + fechaFin.Day + "/" + fechaFin.Month + "/" + fechaFin.Year + " Total Factura: $ " + dr["Factura_Total"].ToString() + ")");
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

        private void cargarViajesDeLaFactura(SqlConnection conexion) {

            DataTable dtFactura = new DataTable("Factura");
            DataColumn cCantidadKms = new DataColumn("Kms");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cImporte = new DataColumn("Importe");

            dtFactura.Columns.Add(cCantidadKms);
            dtFactura.Columns.Add(cFecha);
            dtFactura.Columns.Add(cImporte);

                totalFactura = 0;
                decimal totalKms = 0;
                int totalViajes = 0;

                KeyValuePair<int, string> ClienteSeleccionado = (KeyValuePair<int, string>)listBoxCliente.SelectedItem;
                string query = String.Format("SELECT [Vi_CantKilometros], Vi_Inicio AS fecha ,[Vi_ImporteTotal] FROM [HAY_TABLA].[Viaje] V WHERE Vi_IdCliente = " + ClienteSeleccionado.Key.ToString() + " AND  Vi_Inicio BETWEEN @FechaInicio AND @FechaFin");
                SqlCommand cmd = new SqlCommand(query, conexion);

                DateTime fechaActual = new DateTime(Access.fechaAño(), Access.fechaMes(), Access.fechaDia());
                SqlParameter param = new SqlParameter("@FechaInicio", fechaInicio);
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@FechaFin", fechaFin);
                param.SqlDbType = System.Data.SqlDbType.DateTime;
                cmd.Parameters.Add(param);


                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Vi_CantKilometros"].ToString() != "")
                        {
                            DataRow row = dtFactura.NewRow();
                            row["Kms"] = dr["Vi_CantKilometros"].ToString();
                            row["Fecha"] = dr["fecha"].ToString();
                            row["Importe"] = dr["Vi_ImporteTotal"].ToString();

                            totalFactura += (decimal)dr["Vi_ImporteTotal"];
                            totalKms += (decimal)dr["Vi_CantKilometros"];
                            totalViajes++;
                            dtFactura.Rows.Add(row);
                        }
                    }
                    if (totalViajes > 0)
                    {
                        dr.Close();
                        dgvFactura.DataSource = dtFactura;
                        dgvFactura.AutoResizeColumns();
                        dgvFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        txtCantidadViajes.Text = "Cantidad de viajes facturados:" + Convert.ToString(totalViajes);
                        txtCantKms.Text = "Cantidad total de kms:" + Convert.ToString(totalKms);
                        txtImporteTotal.Text = "Importe total:" + Convert.ToString(totalFactura);
                    
                        btnConfirmar.Visible = true;
                        btnCancelar.Visible = true;
                        btnFacturar.Visible = false;
                        listBoxCliente.Enabled = false;
                    

                }
                else
                    {
                        MessageBox.Show("No se puede realizar factura.El cliente '" + ClienteSeleccionado.Value + "' no realizo ningun viaje entre la fecha " + fechaInicio.Day + "/" + fechaInicio.Month + "/" + fechaInicio.Year + " y " + fechaFin.Day + "/" + fechaFin.Month + "/" + fechaFin.Year);
                    }
            }catch (Exception excep){
                MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void listBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Facturar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvFactura.DataSource = null;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            btnFacturar.Visible = true;
            listBoxCliente.Enabled = true;

            txtCantKms.Text = "";
            txtCantidadViajes.Text = "";
            txtImporteTotal.Text = "";
        }
    }
}
