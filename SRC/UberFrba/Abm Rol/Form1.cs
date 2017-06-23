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

namespace UberFrba.Abm_Rol
{
    public partial class AbmDeRoles : Form
    {
        public DBAccess Access { get; set; }
        private List<KeyValuePair<int, string>> listaKVPFuncionalidadesSeleccionadas = new List<KeyValuePair<int, string>>();
        public AbmDeRoles()
        {
            InitializeComponent();
            Access = new DBAccess();
            MostrarRoles();
        }

        private void btnAltaDeRol_Click(object sender, EventArgs e)
        {
            AltaDeRol formAltaDeRol = new AltaDeRol();
            formAltaDeRol.Show();
        }


        void MostrarRoles()
        {
            DataTable dtRoles = new DataTable("Roles");

            DataColumn cId = new DataColumn("Id");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtRoles.Columns.Add(cId);
            dtRoles.Columns.Add(cNombre);
            dtRoles.Columns.Add(cHabilitado);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT * FROM [HAY_TABLA].[Rol]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        DataRow row = dtRoles.NewRow();
                        row["Id"] = dr["Id_Rol"].ToString();
                        row["Nombre"] = dr["Nombre"].ToString();
                        row["Habilitado"] = dr["Habilitado"].ToString();


                            dtRoles.Rows.Add(row);
                        
                    }
                    dgvRoles.DataSource = dtRoles;
                    dgvRoles.AutoResizeColumns();
                    dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdSeleccionado.Text = dgvRoles.CurrentRow.Cells[0].Value.ToString();
            tbNombreRol.Text = dgvRoles.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarFuncionalidades();
        }

        private void MostrarFuncionalidades()
        {
            clbFuncionalidades.Items.Clear();
            listaKVPFuncionalidadesSeleccionadas.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("  SELECT F.Id_Funcionalidad, Id_Rol, Descripcion FROM HAY_TABLA.FUNCIONALIDAD F  INNER JOIN HAY_TABLA.FUNCIONALIDAD_POR_ROL ON F.Id_Funcionalidad = FUNCIONALIDAD_POR_ROL.Id_Funcionalidad WHERE Id_Rol = " +  txtIdSeleccionado.Text);
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        listaKVPFuncionalidadesSeleccionadas.Add(new KeyValuePair<int, string>((int)dr["Id_Funcionalidad"], dr["Descripcion"].ToString()));
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Id_Funcionalidad],[Descripcion] FROM [HAY_TABLA].[Funcionalidad]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int a = 0; 
                    while (dr.Read())
                    {
                        clbFuncionalidades.Items.Add(new KeyValuePair<int, string>((int)dr["Id_Funcionalidad"], dr["Descripcion"].ToString()));
                        if (listaKVPFuncionalidadesSeleccionadas.Contains(new KeyValuePair<int, string>((int)dr["Id_Funcionalidad"], dr["Descripcion"].ToString())))
                        {
                            clbFuncionalidades.SetItemChecked(a, true);
                        }
                        a++;
                            
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (true)//VALIDACIONES
            {

                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;
                    try
                    {

                        /*string query = String.Format("UPDATE [HAY_TABLA].[Chofer] SET Cho_Nombre = @Nombre, Cho_Apellido = @Apellido, Cho_DNI =@DNI, Cho_Mail=@Mail, Cho_Telefono = @Telefono, Cho_Direccion= @Direccion,Cho_FechaNacimiento = @FechaNacimiento  WHERE Cho_Id =" + txtIdSeleccionado.Text);


                        command.CommandText = query;

                        SqlParameter param = new SqlParameter("@Nombre", txtChoferNombre.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);
                      

                        command.ExecuteNonQuery();  */

                        foreach (KeyValuePair<int, string> funcionalidad in clbFuncionalidades.CheckedItems)
                        {
                            if (listaKVPFuncionalidadesSeleccionadas.Contains(new KeyValuePair<int, string>(funcionalidad.Key, funcionalidad.Value)))
                            {
                                //ya esta en la bd guardado esa funcionalidad seleccionada
                            }
                            else
                            {
                                //agrego una nueva funcionalidad al rol, lo tengo que guardar
                                string query2 = String.Format("INSERT INTO [HAY_TABLA].[Funcionalidad_Por_Rol] (Id_Rol, Id_Funcionalidad) VALUES (" + txtIdSeleccionado.Text + "," + funcionalidad.Key.ToString() + ")");
                                command.CommandText = query2;
                                command.ExecuteNonQuery();
                            }

                        }
                        foreach (KeyValuePair<int, string> funcionalidad in listaKVPFuncionalidadesSeleccionadas)
                        {
                            if (clbFuncionalidades.CheckedItems.Contains(new KeyValuePair<int, string>(funcionalidad.Key, funcionalidad.Value)))
                            {
                                //ya esta en la bd guardado esa funcionalidad seleccionada
                            }
                            else
                            {
                                //estaba selecionada y ahora ya no.
                                string query3 = String.Format("DELETE FROM [HAY_TABLA].[Funcionalidad_Por_Rol] WHERE Id_Rol =" + txtIdSeleccionado.Text + " AND Id_Funcionalidad =" + funcionalidad.Key.ToString());
                                command.CommandText = query3;
                                command.ExecuteNonQuery();
                            }

                        }

                        sqlTransact.Commit();
                        MessageBox.Show("El Rol fue guardado con exito");
                        MostrarRoles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                        sqlTransact.Rollback();
                    }


                }
            }
        }
    }
}
