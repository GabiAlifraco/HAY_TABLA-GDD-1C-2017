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

namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        string anio = "2015";
        string trimestre = "CONVERT(datetime, '01/01/2015 00:00:00',103) AND CONVERT(datetime,'31/03/2015 23:59:59', 103)";
        public DBAccess Access { get; set; }

        public ListadoEstadistico()
        {
            InitializeComponent();
            Access = new DBAccess();
            cbListado.SelectedIndex = 0;
            cbTrimestre.SelectedIndex = 0;
        }

        private void cbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarTop5();
        }

        private void mostrarTop5()
        {
            switch (cbListado.Text)
            {
                case "Clientes con mayor consumo":
                    mostrarClienteConMayorConsumo();
                    break;
                case "Cliente que usó más veces el mismo automovil en sus viajes":
                    mostrarClienteConAutoUtilizado();
                    break;
                case "Choferes con el viaje más largo realizado":
                    mostrarChoferConViajeLargo();
                    break;
                case "Chóferes con mayor recaudación":
                    mostrarChoferConMayorRecaudacion();
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }
        }

        private void mostrarClienteConMayorConsumo()
        {
            DataTable dtListado = new DataTable("Listado");

            DataColumn cID_Cliente = new DataColumn("ID_Cliente");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn ctotales = new DataColumn("totales");

            dtListado.Columns.Add(cID_Cliente);
            dtListado.Columns.Add(cApellido);
            dtListado.Columns.Add(cNombre);
            dtListado.Columns.Add(ctotales);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT TOP 5  Vi_IdCliente ID_Cliente, Cli_Apellido Apellido, Cli_Nombre Nombre, sum (Vi_ImporteTotal) totales FROM HAY_TABLA.Viaje V JOIN HAY_TABLA.Cliente C ON C.Cli_Id = V.Vi_IdCliente WHERE Vi_Inicio BETWEEN " + trimestre + " GROUP BY Cli_Apellido, Cli_Nombre, Vi_IdCliente ORDER BY totales DESC");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow row = dtListado.NewRow();
                        row["ID_Cliente"] = dr["ID_Cliente"].ToString();
                        row["Apellido"] = dr["Apellido"].ToString();
                        row["Nombre"] = dr["Nombre"].ToString();
                        row["totales"] = dr["totales"].ToString();
                        dtListado.Rows.Add(row);
                    }

                    dgvListado.DataSource = dtListado;
                    dgvListado.AutoResizeColumns();
                    dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mostrarClienteConAutoUtilizado()
        {
            DataTable dtListado = new DataTable("Listado");

            DataColumn cID_Cliente = new DataColumn("ID_Cliente");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cAutoUtilizado = new DataColumn("AutoUtilizado");
            DataColumn cViajesRealizados = new DataColumn("ViajesRealizados");

            dtListado.Columns.Add(cID_Cliente);
            dtListado.Columns.Add(cApellido);
            dtListado.Columns.Add(cNombre);
            dtListado.Columns.Add(cAutoUtilizado);
            dtListado.Columns.Add(cViajesRealizados);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT TOP 5 Vi_IdCliente ID_Cliente, Cli_Apellido Apellido, Cli_Nombre Nombre, Vi_AutoPatente AutoUtilizado, COUNT (Vi_Inicio) ViajesRealizados FROM [GD1C2017].[HAY_TABLA].[Viaje] V JOIN [GD1C2017].[HAY_TABLA].[Cliente] C ON  V.Vi_IdCliente = C.Cli_Id WHERE Vi_Inicio BETWEEN " + trimestre + " GROUP BY Cli_Apellido, Cli_Nombre, Vi_IdCliente, Vi_AutoPatente ORDER BY ViajesRealizados DESC");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow row = dtListado.NewRow();
                        row["ID_Cliente"] = dr["ID_Cliente"].ToString();
                        row["Apellido"] = dr["Apellido"].ToString();
                        row["Nombre"] = dr["Nombre"].ToString();
                        row["AutoUtilizado"] = dr["AutoUtilizado"].ToString();
                        row["ViajesRealizados"] = dr["ViajesRealizados"].ToString();
                        dtListado.Rows.Add(row);
                    }

                    dgvListado.DataSource = dtListado;
                    dgvListado.AutoResizeColumns();
                    dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mostrarChoferConViajeLargo()
        {
            DataTable dtListado = new DataTable("Listado");

            DataColumn cID_Chofer = new DataColumn("ID_Chofer");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cKms = new DataColumn("Kms");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cPrecio = new DataColumn("Precio");

            dtListado.Columns.Add(cID_Chofer);
            dtListado.Columns.Add(cApellido);
            dtListado.Columns.Add(cNombre);
            dtListado.Columns.Add(cKms);
            dtListado.Columns.Add(cFecha);
            dtListado.Columns.Add(cPrecio);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT TOP 5 Vi_IdChofer ID_Chofer, C.Cho_Apellido Apellido, C.Cho_Nombre Nombre, Vi_CantKilometros Kms, Vi_Inicio Fecha, Vi_ImporteTotal Precio FROM HAY_TABLA.Viaje V JOIN HAY_TABLA.Chofer C ON V.Vi_IdChofer = C.Cho_Id WHERE Vi_Inicio BETWEEN " + trimestre + " ORDER BY Kms desc, Fecha, ID_Chofer");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow row = dtListado.NewRow();
                        row["ID_Chofer"] = dr["ID_Chofer"].ToString();
                        row["Apellido"] = dr["Apellido"].ToString();
                        row["Nombre"] = dr["Nombre"].ToString();
                        row["Kms"] = dr["Kms"].ToString();
                        row["Fecha"] = dr["Fecha"].ToString();
                        row["Precio"] = dr["Precio"].ToString();
                        dtListado.Rows.Add(row);
                    }

                    dgvListado.DataSource = dtListado;
                    dgvListado.AutoResizeColumns();
                    dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mostrarChoferConMayorRecaudacion()
        {
            DataTable dtListado = new DataTable("Listado");

            DataColumn cID_Chofer = new DataColumn("ID_Chofer");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cTotalRecaudado = new DataColumn("TotalRecaudado");

            dtListado.Columns.Add(cID_Chofer);
            dtListado.Columns.Add(cApellido);
            dtListado.Columns.Add(cNombre);
            dtListado.Columns.Add(cTotalRecaudado);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT TOP 5 Vi_IdChofer ID_Chofer, Cho_Apellido Apellido, Cho_Nombre Nombre, SUM (Vi_ImporteTotal) TotalRecaudado FROM HAY_TABLA.Viaje V JOIN HAY_TABLA.Chofer C ON V.Vi_IdChofer = C.Cho_Id WHERE Vi_Inicio BETWEEN " + trimestre + " GROUP BY Vi_IdChofer, Cho_Apellido, Cho_Nombre ORDER BY TotalRecaudado DESC");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow row = dtListado.NewRow();
                        row["ID_Chofer"] = dr["ID_Chofer"].ToString();
                        row["Apellido"] = dr["Apellido"].ToString();
                        row["Nombre"] = dr["Nombre"].ToString();
                        row["TotalRecaudado"] = dr["TotalRecaudado"].ToString();
                        dtListado.Rows.Add(row);
                    }

                    dgvListado.DataSource = dtListado;
                    dgvListado.AutoResizeColumns();
                    dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            anio = nudAnio.Value.ToString();
            actualizarTrimestre();
            mostrarTop5();
        }

        private void cbTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarTrimestre();
        }
        private void actualizarTrimestre()
        {
            switch (cbTrimestre.Text)
            {//actualizo el trimestre y muestro el top 5 
                case "Enero - Marzo":
                    trimestre = "CONVERT(datetime, '01/01/" + anio + " 00:00:00',103) AND CONVERT(datetime,'31/03/" + anio + " 23:59:59', 103)";
                    mostrarTop5();
                    break;
                case "Abril - Junio":
                    trimestre = "CONVERT(datetime, '01/04/" + anio + " 00:00:00',103) AND CONVERT(datetime,'30/06/" + anio + " 23:59:59', 103)";
                    mostrarTop5();
                    break;
                case "Julio - Septiembre":
                    trimestre = "CONVERT(datetime, '01/07/" + anio + " 00:00:00',103) AND CONVERT(datetime,'30/09/" + anio + " 23:59:59', 103)";
                    mostrarTop5();
                    break;
                case "Octubre - Diciembre":
                    trimestre = "CONVERT(datetime, '01/10/" + anio + " 00:00:00',103) AND CONVERT(datetime,'31/12/" + anio + " 23:59:59', 103)";
                    mostrarTop5();
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }
        }
    }
}
