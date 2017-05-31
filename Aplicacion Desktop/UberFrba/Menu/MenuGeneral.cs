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

namespace UberFrba.Menu
{
    public partial class MenuGeneral : Form
    {
        public DBAccess Access { get; set; }
        private string idUsuario = "";
        private List<KeyValuePair<string, int>> listRoles = new List<KeyValuePair<string, int>>()
        {
        };
        public MenuGeneral(string idUser, string nombre_usuario)
        {
            InitializeComponent();
            label2.Text = "Bienvenido " + nombre_usuario;
            idUsuario = idUser;
            Access = new DBAccess();
            MostrarRoles(idUser);
        }

        private void MostrarRoles(string idUser)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

                string query = String.Format("SELECT UR.[Id_Rol], R.Id_Rol, R.Nombre FROM [HAY_TABLA].[USUARIO_POR_ROL] AS UR INNER JOIN [HAY_TABLA].[ROL] AS R ON R.Id_Rol = UR.Id_Rol  WHERE UR.Usu_Id =" + idUser + "AND UR.Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listRoles.Add((new KeyValuePair<string, int>(dr["Nombre"].ToString(), (int)dr["Id_Rol"])));
                        listBoxRoles.Items.Add((dr["Nombre"].ToString()));
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
           int seleccionado = listBoxRoles.SelectedIndex;
            if (seleccionado == -1)
            {
                MessageBox.Show("Debe seleccionar un rol de la lista para continuar");
            }
            else {
                MenuFuncionesDelRol formularioMenuFuncionesRol = new MenuFuncionesDelRol(idUsuario, listRoles[seleccionado].Value);
                formularioMenuFuncionesRol.Show();

            }
        }
    }
}
