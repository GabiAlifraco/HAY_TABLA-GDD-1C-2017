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

namespace UberFrba.Registro_Viajes
{
    public partial class RegistroViajes : Form
    {
        public DBAccess Access { get; set; }
        public RegistroViajes()
        {
            InitializeComponent();
            Access = new DBAccess();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        public void mostrarDatos()
        {
            DataTable dtViajes = new DataTable("Viajes");

            DataColumn cChofer = new DataColumn("Chofer");
            DataColumn cCliente = new DataColumn("Cliente");
            DataColumn cAutoPatente = new DataColumn("AutoPatente");
            DataColumn cTurno = new DataColumn("Turno");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cHoraInicio = new DataColumn("HoraInicio");
            DataColumn cHoraFin = new DataColumn("HoraFin");
            DataColumn cImporteTotal = new DataColumn("ImporteTotal");

            dtViajes.Columns.Add(cChofer);
            dtViajes.Columns.Add(cCliente);
            dtViajes.Columns.Add(cAutoPatente);
            dtViajes.Columns.Add(cTurno);
            dtViajes.Columns.Add(cFecha);
            dtViajes.Columns.Add(cHoraInicio);
            dtViajes.Columns.Add(cHoraFin);
            dtViajes.Columns.Add(cImporteTotal);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                //lo escribo por partes para que no quede una línea de 10 km
                string consulta = "SELECT CONCAT(Chofer.Cho_Nombre,' ', Chofer.Cho_Apellido) as Chofer, ";
                consulta += "CONCAT(Cliente.Cli_Nombre,' ', Cliente.Cli_Apellido) as Cliente, V.Vi_AutoPatente, ";
                consulta += "Turno.Turno_Descripcion, CONCAT(DAY(V.Vi_Inicio), '/' , MONTH(V.Vi_Inicio),'/', ";
                consulta += "YEAR(V.Vi_Inicio)) as Fecha, CONCAT(DATEPART(HH,V.Vi_Inicio),'hs ', ";
                consulta += "DATEPART(mi,V.Vi_Inicio), 'min') as HoraInicio, CONCAT(DATEPART(HH,V.Vi_Fin),'hs ',";
                consulta += "DATEPART(mi,V.Vi_Fin), 'min') as HoraFin,V.Vi_ImporteTotal ";
                consulta += "FROM HAY_TABLA.Viaje V ";
                consulta += "INNER JOIN Hay_TABLA.Chofer ON Chofer.Cho_Id = V.Vi_IdChofer ";
                consulta += "INNER JOIN Hay_TABLA.Cliente ON Cliente.Cli_Id = V.Vi_IdCliente ";
                consulta += "INNER JOIN Hay_TABLA.Turno ON Turno.Turno_Id = V.Vi_IdTurno ";
                consulta += "WHERE (Chofer.Cho_Nombre LIKE '%" + tbChofer.Text + "%' ";
                consulta += "OR Chofer.Cho_Apellido LIKE '%" + tbChofer.Text + "%') ";
                consulta += "AND (Cliente.Cli_Apellido LIKE '%" + tbCliente.Text + "%' ";
                consulta += "OR Cliente.Cli_Nombre LIKE '%" + tbCliente.Text + "%')";

                string query = String.Format(consulta);
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DataRow row = dtViajes.NewRow();
                        row["Chofer"] = dr["Chofer"].ToString();
                        row["Cliente"] = dr["Cliente"].ToString();
                        row["AutoPatente"] = dr["Vi_AutoPatente"].ToString();
                        row["Turno"] = dr["Turno_Descripcion"].ToString();
                        row["Fecha"] = dr["Fecha"].ToString();
                        row["HoraInicio"] = dr["HoraInicio"].ToString();
                        row["HoraFin"] = dr["HoraFin"].ToString();
                        row["ImporteTotal"] = dr["Vi_ImporteTotal"].ToString();
                        dtViajes.Rows.Add(row);
                    }
                    dgvVerViajes.DataSource = dtViajes;
                    dgvVerViajes.AutoResizeColumns();
                    dgvVerViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
