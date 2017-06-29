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

namespace UberFrba.Abm_Chofer
{
    public partial class AbmChofer : Form
    {
        private List<KeyValuePair<int, string>> listaKVPTurnos = new List<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> listaKVPTurnosSeleccionados = new List<KeyValuePair<int, string>>();
        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }
        public AbmChofer()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            dgvChoferes.ReadOnly = true;
            MostrarChoferes();
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            AltaChofer altaChoferForm = new AltaChofer();
            altaChoferForm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            panelChoferes.Visible = false;
            panelDatosChoferSeleccionado.Visible = true;
            mostrarTurnos();

        }

        private void mostrarTurnos()
        {
            listaKVPTurnos.Clear();
            listaKVPTurnosSeleccionados.Clear();
            listaTurnos.Items.Clear();

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT Turno.[Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion] FROM[HAY_TABLA].[AsignacionDeTurnos] INNER JOIN[HAY_TABLA].Turno ON Turno.Turno_Id = AsignacionDeTurnos.Turno_Id WHERE AsignacionDeTurnos.Cho_Id = " + txtIdSeleccionado.Text);
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                            listaKVPTurnosSeleccionados.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()));

                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion]FROM[HAY_TABLA].[Turno]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int a = 0;
                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                            listaKVPTurnos.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()));
                            listaTurnos.Items.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()));
                            if (listaKVPTurnosSeleccionados.Contains(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()))) {
                                listaTurnos.SetItemChecked(a, true);
                            }
                            
                        }
                        a++;
                    }
                    conexion.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        void MostrarChoferes()
        {
            DataTable dtChoferes = new DataTable("Clientes");

            DataColumn cId = new DataColumn("Id");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cDNI = new DataColumn("DNI");
            DataColumn cMail = new DataColumn("Mail");
            DataColumn cTelefono = new DataColumn("Telefono");
            DataColumn cDireccion = new DataColumn("Direccion");
            DataColumn cFechaNacimiento = new DataColumn("FechaNacimiento");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtChoferes.Columns.Add(cId);
            dtChoferes.Columns.Add(cNombre);
            dtChoferes.Columns.Add(cApellido);
            dtChoferes.Columns.Add(cDNI);
            dtChoferes.Columns.Add(cMail);
            dtChoferes.Columns.Add(cTelefono);
            dtChoferes.Columns.Add(cDireccion);
            dtChoferes.Columns.Add(cFechaNacimiento);
            dtChoferes.Columns.Add(cHabilitado);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

             

                string query;
                if (checkVerInhabilitados.Checked)
                {/// ver todos
                    query = String.Format("SELECT * FROM [HAY_TABLA].[Chofer] c  JOIN[HAY_TABLA].[Usuarios] U ON c.Cho_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Id_Rol = 3 AND Cho_DNI LIKE '" + txtFiltroDNI.Text.Trim() + "%' AND Cho_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cho_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
                }
                else
                {//ver solo habilitados
                    query = String.Format("SELECT * FROM [HAY_TABLA].[Chofer] c  JOIN[HAY_TABLA].[Usuarios] U ON c.Cho_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Habilitado = 1  AND Id_Rol = 3 AND Cho_DNI LIKE '" + txtFiltroDNI.Text.Trim() + "%' AND Cho_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cho_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
                }


                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        DataRow row = dtChoferes.NewRow();
                        row["Id"] = dr["Cho_Id"].ToString();
                        row["Nombre"] = dr["Cho_Nombre"].ToString();
                        row["Apellido"] = dr["Cho_Apellido"].ToString();
                        row["DNI"] = dr["Cho_DNI"].ToString();
                        row["Mail"] = dr["Cho_Mail"].ToString();
                        row["Telefono"] = dr["Cho_Telefono"].ToString();
                        row["Direccion"] = dr["Cho_Direccion"].ToString();
                        row["FechaNacimiento"] = dr["Cho_FechaNacimiento"].ToString();
                        row["Habilitado"] = dr["Habilitado"].ToString();


                        dtChoferes.Rows.Add(row);

                    }
                    dgvChoferes.DataSource = dtChoferes;
                    dgvChoferes.AutoResizeColumns();
                    dgvChoferes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                    if (checkVerInhabilitados.Checked)
                    {/// ver todos       
                        for (int i = 0; i < dgvChoferes.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = dgvChoferes.Rows[i];
                            if (row.Cells[8].Value.ToString() == "False")
                            {
                                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.LimeGreen;
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


        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChoferes.CurrentRow.Cells[8].Value.ToString() == "False")
            {
                panelDatosChoferSeleccionado.Visible = false;
                btnModificar.Visible = false;
                btnEliminarChofer.Visible = false;
                btnAltaLogica.Visible = true;
            }
            else
            {
                txtIdSeleccionado.Text = dgvChoferes.CurrentRow.Cells[0].Value.ToString();
                txtChoferNombre.Text = dgvChoferes.CurrentRow.Cells[1].Value.ToString();
                txtChoferApellido.Text = dgvChoferes.CurrentRow.Cells[2].Value.ToString();
                txtChoferDNI.Text = dgvChoferes.CurrentRow.Cells[3].Value.ToString();
                txtChoferMail.Text = dgvChoferes.CurrentRow.Cells[4].Value.ToString();
                txtChoferTelefono.Text = dgvChoferes.CurrentRow.Cells[5].Value.ToString();
                string dir = dgvChoferes.CurrentRow.Cells[6].Value.ToString();
                txtChoferDireccion.Text = dir.Substring(0, dir.LastIndexOf(" "));
                txtChoferAltura.Text = dir.Substring(dir.LastIndexOf(" "), (dir.Length - dir.LastIndexOf(" ")));

                DateTime fechaNacimiento = DateTime.Parse(dgvChoferes.CurrentRow.Cells[7].Value.ToString());
                string fNacimiento;
                if (fechaNacimiento.Date.Day < 10)
                {
                    fNacimiento = "0" + fechaNacimiento.Date.Day.ToString();
                }
                else
                {
                    fNacimiento = fechaNacimiento.Date.Day.ToString();
                }
                if (fechaNacimiento.Date.Month < 10)
                {
                    fNacimiento += "0" + fechaNacimiento.Date.Month.ToString();
                }
                else
                {
                    fNacimiento += fechaNacimiento.Date.Month.ToString();
                }
                fNacimiento += fechaNacimiento.Date.Year.ToString();
                txtChoferNacimiento.Text = fNacimiento;

                btnModificar.Visible = true;

                btnEliminarChofer.Visible = true;
                btnAltaLogica.Visible = false;
            }
         
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                try
                {

                    if (NoExiste(conexion, txtChoferDNI.Text.Trim(), dgvChoferes.CurrentRow.Cells[3].Value.ToString(), "Cho_DNI", "DNI") && NoExiste(conexion, txtChoferTelefono.Text.Trim(), dgvChoferes.CurrentRow.Cells[5].Value.ToString(), "Cho_Telefono", "Telefono"))
                    {
                        conexion.Close();
                        guardarChofer();
                        panelChoferes.Visible = true;
                        panelDatosChoferSeleccionado.Visible = false;
                        btnModificar.Visible = false;
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    panelChoferes.Visible = true;
                    panelDatosChoferSeleccionado.Visible = false;
                    btnModificar.Visible = false;
                }
            }
            

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            MostrarChoferes();
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {

            panelChoferes.Visible = true;
            panelDatosChoferSeleccionado.Visible = false;
            btnModificar.Visible = false;
            MostrarChoferes();
        }

        private void guardarChofer()
        {

            if (ValidarChofer(txtChoferNombre.Text, txtChoferApellido.Text, txtChoferDNI.Text, txtChoferMail.Text, txtChoferTelefono.Text, txtChoferDireccion.Text, txtChoferAltura.Text, txtChoferNacimiento.Text))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;
                    try
                    {
                        string query = String.Format("UPDATE [HAY_TABLA].[Chofer] SET Cho_Nombre = @Nombre, Cho_Apellido = @Apellido, Cho_DNI =@DNI, Cho_Mail=@Mail, Cho_Telefono = @Telefono, Cho_Direccion= @Direccion,Cho_FechaNacimiento = @FechaNacimiento  WHERE Cho_Id =" + txtIdSeleccionado.Text);


                        command.CommandText = query;

                        SqlParameter param = new SqlParameter("@Nombre", txtChoferNombre.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Apellido", txtChoferApellido.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@DNI", txtChoferDNI.Text);
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Mail", txtChoferMail.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Telefono", txtChoferTelefono.Text);
                        param.SqlDbType = System.Data.SqlDbType.Int;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Direccion", txtChoferDireccion.Text + " " + txtChoferAltura.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        DateTime fechaNacimiento = DateTime.Parse(txtChoferNacimiento.Text);
                        param = new SqlParameter("@FechaNacimiento", fechaNacimiento);
                        param.SqlDbType = System.Data.SqlDbType.DateTime;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();
                        
                        foreach (KeyValuePair<int, string> turno in listaTurnos.CheckedItems)
                        {
                                if (listaKVPTurnosSeleccionados.Contains(new KeyValuePair<int, string>(turno.Key, turno.Value)))
                                {
                                    //ya esta en la bd guardado ese turno seleccionado
                                }else
                                {
                                    //agrego un nuevo turno al chofer, lo tengo que guardar
                                    query = String.Format("INSERT INTO [HAY_TABLA].[AsignacionDeTurnos] (Turno_Id, Cho_Id,Auto_Id) VALUES (" + turno.Key.ToString() + "," + txtIdSeleccionado.Text + ",0)");
                                    command.CommandText = query;
                                    command.ExecuteNonQuery();
                                }
  
                        }
                        foreach (KeyValuePair<int, string> turno in listaKVPTurnosSeleccionados)
                        {
                            if (listaTurnos.CheckedItems.Contains(new KeyValuePair<int, string>(turno.Key, turno.Value)))
                            {
                                //ya esta en la bd guardado ese turno seleccionado
                            }
                            else
                            {
                                //elimino un nuevo turno al chofer, estaba selecionado y ahora ya no.
                                query = String.Format("DELETE FROM [HAY_TABLA].[AsignacionDeTurnos] WHERE Turno_Id =" + turno.Key.ToString() + " AND Cho_Id=" + txtIdSeleccionado.Text);
                                command.CommandText = query;
                                command.ExecuteNonQuery();
                            }

                        }

                        sqlTransact.Commit();
                        MessageBox.Show("El chofer fue guardado con exito");
                        MostrarChoferes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                        sqlTransact.Rollback();
                    }

                }
            }
        }

        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void soloLetras(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsWhiteSpace(e.KeyChar)))
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }

            }
        }

        private bool ValidarChofer(string nombre, string apellido, string dni, string email, string telefono, string calle, string altura, string fechaNacimiento)
        {
            bool resultadoValidacion = true;
            resultadoValidacion = (Validador.validarStringVacio(email, "Mail") && Validador.validarMail(email) && Validador.validarStringVacio(nombre, "Nombre") && Validador.validarStringVacio(apellido, "Apellido") && Validador.validarStringVacio(dni, "DNI") && Validador.validarStringVacio(calle, "Calle") && Validador.validarStringVacio(altura, "Altura") && Validador.validarFecha(fechaNacimiento));
            return resultadoValidacion;
        }

        private bool NoExiste(SqlConnection conexionAbierta, string dato, string datoActual, string nombreCampoEnTabla, string nombreDelDato)
        {
            if (dato == datoActual)
            {
                return true;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [HAY_TABLA].[Chofer] WHERE " + nombreCampoEnTabla + " = " + dato, conexionAbierta);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        MessageBox.Show(nombreDelDato + "'" + dato + "' ya se encuentra registrado en el sistema");
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

        private void btnEliminarChofer_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("EXEC [HAY_TABLA].[bajaLogicaRolDelUsuario] 3," + dgvChoferes.CurrentRow.Cells[3].Value.ToString());

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    MostrarChoferes();
                    btnEliminarChofer.Visible = false;
                    btnModificar.Visible = false;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAltaLogica_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("EXEC [HAY_TABLA].[altaLogicaRolDelUsuario] 3," + dgvChoferes.CurrentRow.Cells[3].Value.ToString());

                SqlCommand cmd = new SqlCommand(query, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    MostrarChoferes();
                    btnAltaLogica.Visible = false;
                    btnModificar.Visible = false;


                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
