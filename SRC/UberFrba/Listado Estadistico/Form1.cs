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
    public partial class frmListadoEstadistico : Form
    {
        public DBAccess Access { get; set; }
        public frmListadoEstadistico()
        {
            InitializeComponent();
        }

        private void btnClientesMayorConsumo_Click(object sender, EventArgs e)
        {
            
            DataTable dtClientes = new DataTable("Cliente con mayor consumo");

            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cTotales = new DataColumn("Consumo");

            dtClientes.Columns.Add(cApellido);
            dtClientes.Columns.Add(cNombre);
            dtClientes.Columns.Add(cTotales);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT TOP 5 C.Cli_Apellido, C.Cli_Nombre , sum (Vi_ImporteTotal) totales FROM[HAY_TABLA].[Viaje] V JOIN[HAY_TABLA].[Cliente] C on C.Cli_Id = V.Vi_IdCliente group by C.Cli_Apellido, C.Cli_Nombre order by totales desc");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                            DataRow row = dtClientes.NewRow();
                            row["Apellido"] = dr["Cli_Apellido"].ToString();
                            row["Nombre"] = dr["Cli_Nombre"].ToString();
                            row["Consumo"] = dr["totales"].ToString();
                            dtClientes.Rows.Add(row);
                    }

                    dgvListado.DataSource = dtClientes;
                    dgvListado.AutoResizeColumns();
                    dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
