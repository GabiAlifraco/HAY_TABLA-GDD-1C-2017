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
        ValidacionesAbm validacion;
        public AltaDeRol()
        {
            InitializeComponent();
            Access = new DBAccess();
            validacion = new ValidacionesAbm();
            MostrarFuncionalidades();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (validacion.validarStringVacio(tbNombreRol.Text, "El nombre del Rol"))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    try
                    {

                        if (NoExiste(conexion, tbNombreRol.Text, "", "Nombre", "Nombre"))
                        {
                            conexion.Close();
                            crearRol();
                            this.Close();
                            AbmRol formAbmDeRol = new AbmRol();
                            formAbmDeRol.Show();
                        }

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool NoExiste(SqlConnection conexionAbierta, string dato, string datoActual, string nombreCampoEnTabla, string nombreDelDato)
        {
            if (dato == datoActual)
            {
                return true;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [HAY_TABLA].[Rol] WHERE " + nombreCampoEnTabla + " = '" + dato + "'", conexionAbierta);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        MessageBox.Show(nombreDelDato + " '" + dato + "' ya se encuentra registrado en el sistema");
                        return false;
                    }
                    dr.Close();
                    return true;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
        }
    
        private void MostrarFuncionalidades()
        {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Id_Funcionalidad],[Descripcion] FROM [HAY_TABLA].[Funcionalidad]");
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

        private void crearRol()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("INSERT INTO [HAY_TABLA].[Rol] (nombre, habilitado) OUTPUT Inserted.Id_rol VALUES (@Nombre,1) ");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@Nombre", tbNombreRol.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    int idRol = (int)command.ExecuteScalar();
                    foreach (KeyValuePair<int, string> funcionalidad in clbFuncionalidades.CheckedItems)
                    {
                        query = String.Format("INSERT INTO [HAY_TABLA].[FUNCIONALIDAD_POR_ROL] (Id_Rol, Id_Funcionalidad) VALUES (" + idRol.ToString() + "," + funcionalidad.Key.ToString() + ")");
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        //MessageBox.Show(turno.Key.ToString());

                    }

                    sqlTransact.Commit();
                    MessageBox.Show("El Rol fue creado con exito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    sqlTransact.Rollback();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AbmRol formAbmDeRol = new AbmRol();
            formAbmDeRol.Show();
        }

        
    }
}
