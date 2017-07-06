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
    public partial class VerViajes : Form
    {
        string anio = "2015";
        string trimestre = "CONVERT(datetime, '01/01/2015 00:00:00',103) AND CONVERT(datetime,'31/03/2015 23:59:59', 103)";
        public DBAccess Access2 { get; set; }
        private string idUsuario = "";
        private string idRol = "";
        string clienteId;
        string choferId;

        public VerViajes(string idUser, int idRolUsuario)
        {
            InitializeComponent();
            Access2 = new DBAccess();
            idUsuario = idUser;
            idRol = idRolUsuario.ToString();
            cbTrimestre.SelectedIndex = 0;


        }

        private string obtenerIdCliente() {
            using (SqlConnection conexion = new SqlConnection(Access2.Conexion))
            {

               string query = String.Format("SELECT Cli_Id FROM[HAY_TABLA].[Cliente] C WHERE C.Cli_Usuario =" + idUsuario);
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        clienteId = dr["Cli_Id"].ToString();                     
                    }
                    return clienteId;
                }
                catch
                {
                    return "0";
                }
            }
        }

        private string obtenerIdChofer()
        {
            using (SqlConnection conexion = new SqlConnection(Access2.Conexion))
            {

                string query = String.Format("SELECT Cho_Id FROM[HAY_TABLA].[Chofer] C WHERE C.Cho_Usuario =" + idUsuario);
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        choferId = dr["Cho_Id"].ToString();
                    }
                    return choferId;
                }
                catch
                {
                    return "0";
                }
            }
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {
            anio = nudAnio.Value.ToString();
            actualizarTrimestre();
        }

        private void cbTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarTrimestre();
        }

        private void actualizarTrimestre()
        {
            switch (cbTrimestre.Text)
            {
                case "Enero - Marzo":
                    trimestre = "CONVERT(datetime, '01/01/" + anio + " 00:00:00',103) AND CONVERT(datetime,'31/03/" + anio + " 23:59:59', 103)";
                    mostrarConsulta();
                    break;
                case "Abril - Junio":
                    trimestre = "CONVERT(datetime, '01/04/" + anio + " 00:00:00',103) AND CONVERT(datetime,'30/06/" + anio + " 23:59:59', 103)";
                    mostrarConsulta();
                    break;
                case "Julio - Septiembre":
                    trimestre = "CONVERT(datetime, '01/07/" + anio + " 00:00:00',103) AND CONVERT(datetime,'30/09/" + anio + " 23:59:59', 103)";
                    mostrarConsulta();
                    break;
                case "Octubre - Diciembre":
                    trimestre = "CONVERT(datetime, '01/10/" + anio + " 00:00:00',103) AND CONVERT(datetime,'31/12/" + anio + " 23:59:59', 103)";
                    mostrarConsulta();
                    break;
                default:
                    MessageBox.Show("ERROR");
                    break;
            }
        }

        private void mostrarConsulta()
        {
            DataTable dtListado = new DataTable("Listado");

            DataColumn cChofer = new DataColumn("Chofer");
            DataColumn cCliente = new DataColumn("Cliente");
            DataColumn cAutoUtilizado = new DataColumn("AutoUtilizado");
            DataColumn cTurno_Descripcion = new DataColumn("Turno_Descripcion");
            DataColumn cFecha = new DataColumn("Fecha");
            DataColumn cHoraInicio = new DataColumn("HoraInicio");
            DataColumn cHoraFin = new DataColumn("HoraFin");
            DataColumn cImporte = new DataColumn("Importe");

            dtListado.Columns.Add(cChofer);
            dtListado.Columns.Add(cCliente);
            dtListado.Columns.Add(cAutoUtilizado);
            dtListado.Columns.Add(cTurno_Descripcion);
            dtListado.Columns.Add(cFecha);
            dtListado.Columns.Add(cHoraInicio);
            dtListado.Columns.Add(cHoraFin);
            dtListado.Columns.Add(cImporte);
            if (idRol == "2")
            {
                using (SqlConnection conexion2 = new SqlConnection(Access2.Conexion))

                {
                    string query = String.Format("SELECT CONCAT(Chofer.Cho_Nombre,' ', Chofer.Cho_Apellido) as Chofer, CONCAT(Cliente.Cli_Nombre,' ', Cliente.Cli_Apellido) as Cliente, V.Vi_AutoPatente AutoUtilizado, Turno.Turno_Descripcion, CONCAT(DAY(V.Vi_Inicio),'/', MONTH(V.Vi_Inicio),'/',YEAR(V.Vi_Inicio)) as Fecha, CONCAT(DATEPART(HH,V.Vi_Inicio),'hs ',DATEPART(mi,V.Vi_Inicio), 'min') as HoraInicio, CONCAT(DATEPART(HH,V.Vi_Fin),'hs ',DATEPART(mi,V.Vi_Fin), 'min') as HoraFin, V.Vi_ImporteTotal Importe FROM HAY_TABLA.Viaje V INNER JOIN Hay_TABLA.Chofer ON Chofer.Cho_Id = V.Vi_IdChofer INNER JOIN Hay_TABLA.Cliente ON Cliente.Cli_Id = V.Vi_IdCliente INNER JOIN Hay_TABLA.Turno ON Turno.Turno_Id = V.Vi_IdTurno WHERE Cli_Id = " + obtenerIdCliente() + " AND (Vi_Inicio BETWEEN " + trimestre + ") ORDER BY Vi_Inicio DESC");
                    SqlCommand cmd = new SqlCommand(query, conexion2);
                    try
                    {
                        conexion2.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            DataRow row = dtListado.NewRow();
                            row["Chofer"] = dr["Chofer"].ToString();
                            row["Cliente"] = dr["Cliente"].ToString();
                            row["AutoUtilizado"] = dr["AutoUtilizado"].ToString();
                            row["Turno_Descripcion"] = dr["Turno_Descripcion"].ToString();
                            row["Fecha"] = dr["Fecha"].ToString();
                            row["HoraInicio"] = dr["HoraInicio"].ToString();
                            row["HoraFin"] = dr["HoraFin"].ToString();
                            row["Importe"] = dr["Importe"].ToString();
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
            else if (idRol == "3") {
                using (SqlConnection conexion2 = new SqlConnection(Access2.Conexion))

                {
                    string query = String.Format("SELECT CONCAT(Chofer.Cho_Nombre,' ', Chofer.Cho_Apellido) as Chofer, CONCAT(Cliente.Cli_Nombre,' ', Cliente.Cli_Apellido) as Cliente, V.Vi_AutoPatente AutoUtilizado, Turno.Turno_Descripcion, CONCAT(DAY(V.Vi_Inicio),'/', MONTH(V.Vi_Inicio),'/',YEAR(V.Vi_Inicio)) as Fecha, CONCAT(DATEPART(HH,V.Vi_Inicio),'hs ',DATEPART(mi,V.Vi_Inicio), 'min') as HoraInicio, CONCAT(DATEPART(HH,V.Vi_Fin),'hs ',DATEPART(mi,V.Vi_Fin), 'min') as HoraFin, V.Vi_ImporteTotal Importe FROM HAY_TABLA.Viaje V INNER JOIN Hay_TABLA.Chofer ON Chofer.Cho_Id = V.Vi_IdChofer INNER JOIN Hay_TABLA.Cliente ON Cliente.Cli_Id = V.Vi_IdCliente INNER JOIN Hay_TABLA.Turno ON Turno.Turno_Id = V.Vi_IdTurno WHERE Cho_Id = " + obtenerIdChofer() + " AND (Vi_Inicio BETWEEN " + trimestre + ") ORDER BY Vi_Inicio DESC");
                    SqlCommand cmd = new SqlCommand(query, conexion2);
                    try
                    {
                        conexion2.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            DataRow row = dtListado.NewRow();
                            row["Chofer"] = dr["Chofer"].ToString();
                            row["Cliente"] = dr["Cliente"].ToString();
                            row["AutoUtilizado"] = dr["AutoUtilizado"].ToString();
                            row["Turno_Descripcion"] = dr["Turno_Descripcion"].ToString();
                            row["Fecha"] = dr["Fecha"].ToString();
                            row["HoraInicio"] = dr["HoraInicio"].ToString();
                            row["HoraFin"] = dr["HoraFin"].ToString();
                            row["Importe"] = dr["Importe"].ToString();
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

        }
    }
}
