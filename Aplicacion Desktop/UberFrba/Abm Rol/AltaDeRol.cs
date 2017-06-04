using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class AltaDeRol : Form
    {
        public DBAccess Access { get; set; }

        public AltaDeRol()
        {
            InitializeComponent();
            Access = new DBAccess();
            MostrarFuncionalidades();
        }

        private void MostrarFuncionalidades()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Id_Funcionalidad],[Descripcion] FROM [GD1C2017].[HAY_TABLA].[Funcionalidad]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Descripcion"].ToString() != "")
                        {
                            clbFuncionalidades.Items.Add(new KeyValuePair<int, string>((int)dr["Id_Funcionalidad"], dr["Descripcion"].ToString()));
                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (tbNombreRol.Text == "")
                MessageBox.Show("El nombre del Rol no puede estar vacío", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
