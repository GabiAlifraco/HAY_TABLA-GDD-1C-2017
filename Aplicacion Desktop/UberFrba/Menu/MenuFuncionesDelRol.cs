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
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Registro_Viajes;

namespace UberFrba.Menu
{
    public partial class MenuFuncionesDelRol : Form
    {
        public DBAccess Access { get; set; }
        private string idUsuario = "";
        private string idRol = "";
        private List<KeyValuePair<string, int>> listFunciones = new List<KeyValuePair<string, int>>()
        {
        };

        public MenuFuncionesDelRol(string idUser, int idRolUsuario)
        {
            InitializeComponent();
            idUsuario = idUser;
            idRol = idRolUsuario.ToString();
            Access = new DBAccess();
            MostrarFunciones(idRol);
        }

        private void MostrarFunciones(string idRol)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

                string query = String.Format("SELECT F.Descripcion, F.Id_Funcionalidad FROM[HAY_TABLA].[FUNCIONALIDAD_POR_ROL] FR INNER JOIN [HAY_TABLA].[FUNCIONALIDAD] AS F ON F.Id_Funcionalidad = FR.Id_Funcionalidad  WHERE FR.Id_Rol =" + idRol);
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        // listFunciones.Add((new KeyValuePair<string, int>(dr["Descripcion"].ToString(), (int)dr["Id_Funcionalidad"])));
                        listBoxFunciones.Items.Add((dr["Descripcion"].ToString()));
                    }


                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void MenuFuncionesDelRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (listBoxFunciones.SelectedItem.ToString())
            {
                case "ABM de Cliente":
                    AbmClientes formularioClientes = new AbmClientes();
                    formularioClientes.Show();
                    break;
                case "ABM de Chofer":
                    AbmChofer formularioChofer = new AbmChofer();
                    formularioChofer.Show();
                    break;
                case "ABM de Automóvil":
                    AbmAutomovil formularioAutomovil = new AbmAutomovil();
                    formularioAutomovil.Show();
                    break;
                case "ABM de Turno":
                    AbmTurno formTurnos = new AbmTurno();
                    formTurnos.Show();
                    break;
                case "ABM de Rol":
                    AbmRol formRol = new AbmRol();
                    formRol.Show();
                    break;
                case "Registro de Viajes":
                    RegistroViajes formRegistroViajes = new RegistroViajes();
                    formRegistroViajes.Show();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
