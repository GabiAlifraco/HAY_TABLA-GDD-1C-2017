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
            this.Close();
            AltaChofer altaChoferForm = new AltaChofer();
            altaChoferForm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvChoferes.Rows.Count > 1)
            {
                panelChoferes.Visible = false;
                panelDatosChoferSeleccionado.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione un Chofer para modificar");
            }
        }

     

        void MostrarChoferes()
        {
            DataTable dtChoferes = new DataTable("Choferes");

            DataColumn cId = new DataColumn("Id");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cDNI = new DataColumn("DNI");
            DataColumn cMail = new DataColumn("Mail");
            DataColumn cTelefono = new DataColumn("Telefono");
            DataColumn cDireccion = new DataColumn("Direccion");
            DataColumn cPiso = new DataColumn("Piso");
            DataColumn cDepartamento = new DataColumn("Departamento");
            DataColumn cLocalidad = new DataColumn("Localidad");
            DataColumn cFechaNacimiento = new DataColumn("FechaNacimiento");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtChoferes.Columns.Add(cId);
            dtChoferes.Columns.Add(cNombre);
            dtChoferes.Columns.Add(cApellido);
            dtChoferes.Columns.Add(cDNI);
            dtChoferes.Columns.Add(cMail);
            dtChoferes.Columns.Add(cTelefono);
            dtChoferes.Columns.Add(cDireccion);
            dtChoferes.Columns.Add(cPiso);
            dtChoferes.Columns.Add(cDepartamento);
            dtChoferes.Columns.Add(cLocalidad);
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
                    query = String.Format("SELECT * FROM [HAY_TABLA].[Chofer] c  JOIN[HAY_TABLA].[Usuarios] U ON c.Cho_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Habilitado = 1  AND Id_Rol = 3 AND Cho_DNI LIKE '%" + txtFiltroDNI.Text.Trim() + "%' AND Cho_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cho_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
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
                        row["Piso"] = dr["Cho_Piso"].ToString();
                        row["Departamento"] = dr["Cho_Departamento"].ToString();
                        row["Localidad"] = dr["Cho_Localidad"].ToString();
                        row["FechaNacimiento"] = dr["Cho_FechaNacimiento"].ToString();
                        row["Habilitado"] = dr["Habilitado"].ToString();


                        dtChoferes.Rows.Add(row);

                    }
                    dgvChoferes.DataSource = dtChoferes;
                    dgvChoferes.AutoResizeColumns();
                    dgvChoferes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                    if (checkVerInhabilitados.Checked)
                    {/// ver todos       
                        for (int i = 0; i < dgvChoferes.Rows.Count; i++)
                        {
                            DataGridViewRow row = dgvChoferes.Rows[i];
                            if (row.Cells[11].Value.ToString() == "False")
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
            if (dgvChoferes.Rows.Count >= 1)
            {
                if (dgvChoferes.CurrentRow.Cells[11].Value.ToString() == "False")
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
                    txtPiso.Text = dgvChoferes.CurrentRow.Cells[7].Value.ToString();
                    txtDepto.Text = dgvChoferes.CurrentRow.Cells[8].Value.ToString();
                    textBox1.Text = dgvChoferes.CurrentRow.Cells[9].Value.ToString();
                    DateTime fechaNacimiento = DateTime.Parse(dgvChoferes.CurrentRow.Cells[10].Value.ToString());
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
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                try
                {

                    if (Validador.NoExiste(conexion, txtChoferDNI.Text.Trim(), "", "Cli_DNI", "DNI", "Cliente") && NoExiste(conexion, txtChoferDNI.Text.Trim(), dgvChoferes.CurrentRow.Cells[3].Value.ToString(), "Cho_DNI", "DNI") && NoExiste(conexion, txtChoferTelefono.Text.Trim(), dgvChoferes.CurrentRow.Cells[5].Value.ToString(), "Cho_Telefono", "Telefono"))
                    {
                        conexion.Close();
                        guardarChofer();

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

            if (ValidarChofer(txtChoferNombre.Text, txtChoferApellido.Text, txtChoferDNI.Text, txtChoferMail.Text, txtChoferTelefono.Text, txtChoferDireccion.Text, txtChoferAltura.Text, txtChoferNacimiento.Text, txtPiso.Text,txtDepto.Text,textBox1.Text))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;
                    try
                    {
                        string query = String.Format("UPDATE [HAY_TABLA].[Chofer] SET Cho_Nombre = @Nombre, Cho_Apellido = @Apellido, Cho_DNI =@DNI, Cho_Mail=@Mail, Cho_Telefono = @Telefono, Cho_Direccion= @Direccion,Cho_FechaNacimiento = @FechaNacimiento,Cho_Piso= @Piso,Cho_Departamento= @Departamento,Cho_Localidad= @Localidad  WHERE Cho_Id =" + txtIdSeleccionado.Text);


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
                        param.SqlDbType = System.Data.SqlDbType.BigInt;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Direccion", txtChoferDireccion.Text + " " + txtChoferAltura.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        DateTime fechaNacimiento = DateTime.Parse(txtChoferNacimiento.Text);
                        param = new SqlParameter("@FechaNacimiento", fechaNacimiento);
                        param.SqlDbType = System.Data.SqlDbType.DateTime;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Piso", txtPiso.Text);
                        param.SqlDbType = System.Data.SqlDbType.BigInt;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Departamento", txtDepto.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        param = new SqlParameter("@Localidad", textBox1.Text);
                        param.SqlDbType = System.Data.SqlDbType.VarChar;
                        command.Parameters.Add(param);

                        command.ExecuteNonQuery();

                        sqlTransact.Commit();
                        MessageBox.Show("El chofer fue guardado con exito");
                        panelChoferes.Visible = true;
                        panelDatosChoferSeleccionado.Visible = false;
                        btnModificar.Visible = false;
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

        private bool ValidarChofer(string nombre, string apellido, string dni, string email, string telefono, string calle, string altura, string fechaNacimiento,string piso,string departamento,string localidad)
        {
            bool resultadoValidacion = true;
            resultadoValidacion = (Validador.validarStringVacio(email, "Mail") && Validador.validarStringVacio(telefono, "Telefono") && Validador.validarMail(email) && Validador.validarStringVacio(nombre, "Nombre") && Validador.validarStringVacio(apellido, "Apellido") && Validador.validarStringVacio(dni, "DNI") && Validador.validarStringVacio(calle, "Calle") && Validador.validarStringVacio(altura, "Altura") && Validador.validarFecha(fechaNacimiento) && Validador.validarStringVacio(piso, "Piso") && Validador.validarStringVacio(departamento, "Departamento") && Validador.validarStringVacio(localidad, "Localidad"));
            return resultadoValidacion;
        }

        private bool NoExiste(SqlConnection conexionAbierta, string dato, string datoActual, string nombreCampoEnTabla, string nombreDelDato)
        {
            if (dato != "")
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
            else {
                MessageBox.Show(nombreDelDato + " se encuentra vacio");
                return false;
            }
        }

        private void btnEliminarChofer_Click(object sender, EventArgs e)
        {
            if (dgvChoferes.Rows.Count > 1)
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
            else
            {
                MessageBox.Show("Seleccione un Chofer para dar de baja");
            }
        }

        private void btnAltaLogica_Click(object sender, EventArgs e)
        {
            if (dgvChoferes.Rows.Count > 1)
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
            else
            {
                MessageBox.Show("Seleccione un Chofer para dar de alta");
            }

        }

        private void checkVerInhabilitados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarChoferes(); 
        }
    }
}
