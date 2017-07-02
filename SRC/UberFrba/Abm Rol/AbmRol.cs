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
    public partial class AbmRol : Form
    {
        public DBAccess Access { get; set; }
        ValidacionesAbm validacion;
        private string query;
        private List<KeyValuePair<int, string>> listaKVPFuncionalidadesSeleccionadas = new List<KeyValuePair<int, string>>();
        
        public AbmRol()
        {
            InitializeComponent();
            Access = new DBAccess();
            validacion = new ValidacionesAbm();
            dgvRoles.ReadOnly = true;
            MostrarRoles();
            txtIdSeleccionado.Text = "1";
            tbNombreRol.Text = "Administrador";
        }

        private void btnAltaDeRol_Click(object sender, EventArgs e)
        {      
        }

        private void btnAltaDeRol_Click_1(object sender, EventArgs e)
        {
            AltaDeRol formAltaDeRol = new AltaDeRol();
            formAltaDeRol.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            panelDatosRol.Visible = true;
            panelAbmRol.Visible = false;
            MostrarFuncionalidades();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validacion.validarStringVacio(tbNombreRol.Text, "El nombre del Rol"))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;
                    try
                    {

                        string query = String.Format("UPDATE [HAY_TABLA].[Rol] SET Nombre = @Nombre  WHERE Id_Rol = " + int.Parse(txtIdSeleccionado.Text));
                        //MessageBox.Show(query);
                        command.CommandText = query;

                        SqlParameter param = new SqlParameter("@Nombre", tbNombreRol.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();

                        foreach (KeyValuePair<int, string> funcionalidad in clbFuncionalidades.CheckedItems)
                        {
                            if (listaKVPFuncionalidadesSeleccionadas.Contains(new KeyValuePair<int, string>(funcionalidad.Key, funcionalidad.Value)))
                            {
                                //ya esta en la bd guardado esa funcionalidad seleccionada
                            }
                            else
                            {
                                //agrego una nueva funcionalidad al rol, lo tengo que guardar
                                query = String.Format("INSERT INTO [HAY_TABLA].[Funcionalidad_Por_Rol] (Id_Rol, Id_Funcionalidad) VALUES (" + txtIdSeleccionado.Text + "," + funcionalidad.Key.ToString() + ")");
                                command.CommandText = query;
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
                                query = String.Format("DELETE FROM [HAY_TABLA].[Funcionalidad_Por_Rol] WHERE Id_Rol =" + txtIdSeleccionado.Text + " AND Id_Funcionalidad =" + funcionalidad.Key.ToString());
                                command.CommandText = query;
                                command.ExecuteNonQuery();
                            }

                        }

                        sqlTransact.Commit();
                        MessageBox.Show("El Rol fue guardado con exito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                        sqlTransact.Rollback();
                    }
                    
                }
            }
            MostrarRoles();
            panelDatosRol.Visible = false;
            panelAbmRol.Visible = true;
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdSeleccionado.Text = dgvRoles.CurrentRow.Cells[0].Value.ToString();
            tbNombreRol.Text = dgvRoles.CurrentRow.Cells[1].Value.ToString();
            MostrarFuncionalidades();
            if (dgvRoles.CurrentRow.Cells[2].Value.ToString().Equals("True"))
            {
                button2.Text = "Inhabilitar";
            }
            else
            {
                button2.Text = "Habilitar";
            }
        }

        private void MostrarFuncionalidades()
        {
            clbFuncionalidades.Items.Clear();
            listaKVPFuncionalidadesSeleccionadas.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                query = String.Format("  SELECT F.Id_Funcionalidad, Id_Rol, Descripcion FROM HAY_TABLA.FUNCIONALIDAD F  INNER JOIN HAY_TABLA.FUNCIONALIDAD_POR_ROL ON F.Id_Funcionalidad = FUNCIONALIDAD_POR_ROL.Id_Funcionalidad WHERE Id_Rol = " + txtIdSeleccionado.Text);
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
                query = String.Format("SELECT [Id_Funcionalidad],[Descripcion] FROM [HAY_TABLA].[Funcionalidad]");
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

        void MostrarRoles()
        {
            txtIdSeleccionado.Text = "1";
            tbNombreRol.Text = "Administrador";

            DataTable dtRoles = new DataTable("Roles");

            DataColumn cId = new DataColumn("Id");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtRoles.Columns.Add(cId);
            dtRoles.Columns.Add(cNombre);
            dtRoles.Columns.Add(cHabilitado);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query;
                if (checkVerInhabilitados.Checked)
                {
                    query = String.Format("SELECT * FROM [HAY_TABLA].[Rol]");
                }
                else
                {
                    query = String.Format("SELECT * FROM [HAY_TABLA].[Rol] WHERE Habilitado=1 ORDER BY Id_Rol");
                }
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
                    dgvRoles.CurrentCell = dgvRoles.Rows[0].Cells[0];

                    if (checkVerInhabilitados.Checked)
                    {/// ver todos       
                        for (int i = 0; i < dgvRoles.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = dgvRoles.Rows[i];
                            if (row.Cells[2].Value.ToString() == "False")
                            {
                                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.LimeGreen;
                            }
                            if (dgvRoles.CurrentRow.Cells[2].Value.ToString().Equals("True"))
                            {
                                button2.Text = "Inhabilitar";
                            }
                            else
                            {
                                button2.Text = "Habilitar";
                            }
                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelDatosRol.Visible = false;
            panelAbmRol.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query;
                if (dgvRoles.CurrentRow.Cells[2].Value.ToString().Equals("True"))
                {
                    query = String.Format("EXEC [HAY_TABLA].[bajaLogicaRol] " + dgvRoles.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    query = String.Format("EXEC [HAY_TABLA].[altaLogicaRol] " + dgvRoles.CurrentRow.Cells[0].Value.ToString());
                }
               
                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MostrarRoles();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MostrarRoles();
        }
    }
}
