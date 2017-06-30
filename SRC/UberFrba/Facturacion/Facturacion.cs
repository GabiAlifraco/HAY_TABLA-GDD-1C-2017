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

        public frmFacturacion()
        {
            InitializeComponent();
            Access = new DBAccess();
            cargar_clientes();
        }



        private void cargar_clientes()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT Cli_Id,CLI_Nombre,Cli_Apellido FROM [HAY_TABLA].[Cliente]");
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


        void Facturar()
        {
            DataTable dtFactura = new DataTable("Factura");

            DataColumn cCantidadKms = new DataColumn("Kms");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cImporte = new DataColumn("Importe");

            dtFactura.Columns.Add(cCantidadKms);
            dtFactura.Columns.Add(cFecha);
            dtFactura.Columns.Add(cImporte);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                decimal totalFactura = 0;
                decimal totalKms = 0;
                int totalViajes = 0;
                DateTime FI = (DateTime.Parse(txtFechaI.Text));
                DateTime FF = (DateTime.Parse(txtFechaF.Text));

                KeyValuePair<int, string> ClienteSeleccionado = (KeyValuePair<int, string>)listBoxCliente.SelectedItem;
                string query = String.Format("SELECT [Vi_CantKilometros], CONVERT(date, [Vi_Inicio]) AS fecha ,[Vi_ImporteTotal] FROM[HAY_TABLA].[Viaje] V WHERE Vi_IdCliente = " + ClienteSeleccionado.Key.ToString() + " AND Factura_nro IS NULL AND  Vi_Inicio BETWEEN '" + FI.Year +"-"+FI.Month+"-"+FI.Day + "' AND '" + FF.Year + "-" + FF.Month + "-"+FF.Day + "'");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
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

                        query = String.Format("INSERT INTO[HAY_TABLA].[Factura] (Factura_Fecha_Inicio,Factura_Fecha_Fin,Cli_Id,Factura_Total)  OUTPUT Inserted.Factura_Nro VALUES (@FechaI,@FechaFin,@ClienteId,@ImporteTotal)");
                  
                        cmd.CommandText = query;

                        SqlParameter param = new SqlParameter("@FechaI", FI);
                        param.SqlDbType = System.Data.SqlDbType.DateTime;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@FechaFin", FF);
                        param.SqlDbType = System.Data.SqlDbType.DateTime;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ImporteTotal", totalFactura);
                        param.SqlDbType = System.Data.SqlDbType.Decimal;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter("@ClienteId", ClienteSeleccionado.Key.ToString());
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        cmd.Parameters.Add(param);

                        Decimal nroFactura = (Decimal)cmd.ExecuteScalar();

                        query = String.Format("UPDATE [HAY_TABLA].[Viaje] SET Factura_nro = " + nroFactura.ToString() + " WHERE Factura_nro IS NULL AND Vi_IdCliente = " + ClienteSeleccionado.Key.ToString() + " AND Vi_Inicio BETWEEN '" + FI.Year + "-" + FI.Month + "-" + FI.Day + "' AND '" + FF.Year + "-" + FF.Month + "-" + FF.Day + "'");
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();


                    }
                    else {
                        MessageBox.Show("No hay viajes para facturar entre esas fechas");
                    }




                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool validarFecha(string fecha, string nombreDelCampo)
        {
            DateTime value;
            if (!DateTime.TryParse(fecha, out value))
            {
                MessageBox.Show(nombreDelCampo + " no es valida");
                return false;
            }
            else
            {

                DateTime hoy = DateTime.Now;
                if (hoy > value)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(nombreDelCampo + " es mayor al la fecha actual");
                    return false;
                }

            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

            if (validarFecha(txtFechaI.Text, "La fecha de inicio") && validarFecha(txtFechaF.Text, "La fecha de fin")) {
                DateTime inicio = DateTime.Parse(txtFechaI.Text);
                DateTime final = DateTime.Parse(txtFechaF.Text);
                if (final > inicio)
                {
                    if (listBoxCliente.SelectedIndex != -1)
                    {
                        Facturar();
                    }else
                    {
                        MessageBox.Show("Debe seleccionar un cliente");
                    }

                }else {
                    MessageBox.Show("La fecha de inicio debe ser menor que la fecha de fin");
                }
            }
        }

        private void listBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
