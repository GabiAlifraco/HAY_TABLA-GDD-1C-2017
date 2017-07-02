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

namespace UberFrba.Abm_Cliente
{
    public partial class AbmClientes : Form
    {
        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }
        public AbmClientes()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            checkVerInhabilitados.Checked = false;
            camposHabilitados(false);
            dgvClientes.ReadOnly = true;
            MostrarClientes();

        }



       



        #region ABM

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarCliente(txtClienteNombreNuevo.Text, txtClienteApellidoNuevo.Text, txtClienteDNINuevo.Text, txtClienteMailNuevo.Text, txtClienteTelefonoNuevo.Text, txtClienteDireccionNuevo.Text, txtClienteAlturaNuevo.Text, txtClienteCodigoPostalNuevo.Text, txtClienteNacimientoNuevo.Text))
            {

                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {


                    DateTime fechaNacimiento = DateTime.Parse(txtClienteNacimientoNuevo.Text);

                    string query = String.Format("INSERT INTO [HAY_TABLA].[Cliente] (Cli_Nombre,Cli_Apellido,Cli_DNI,Cli_Mail,Cli_Telefono,Cli_Direccion,Cli_CodigoPostal,Cli_FechaNacimiento) VALUES (");
                    query += "'" + txtClienteNombreNuevo.Text.Trim() + "','" + txtClienteApellidoNuevo.Text.Trim() + "'," + txtClienteDNINuevo.Text.Trim() + ",'" + txtClienteMailNuevo.Text.Trim() + "'," + txtClienteTelefonoNuevo.Text.Trim() + ",'" + txtClienteDireccionNuevo.Text.Trim() + " " + txtClienteAlturaNuevo.Text.Trim() + "'," + txtClienteCodigoPostalNuevo.Text.Trim() + ",'" + fechaNacimiento.Date.Month.ToString() + "/" + fechaNacimiento.Date.Day.ToString() + "/" + fechaNacimiento.Date.Year.ToString() + "')";
  
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    try
                    {
                        conexion.Open();

                        if (NoExiste(conexion, txtClienteDNINuevo.Text.Trim(), "", "Cli_DNI", "DNI") && NoExiste(conexion, txtClienteTelefonoNuevo.Text.Trim(), "", "Cli_Telefono", "Telefono"))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            MessageBox.Show("El cliente fue creado exitosamente");
                            MessageBox.Show("Se creo un usuario con username:'" + txtClienteDNINuevo.Text + "' password:'" + txtClienteDNINuevo.Text + "' y rol 'cliente'");
                            estadoInicial();
                        }
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("EXEC [HAY_TABLA].[bajaLogicaRolDelUsuario] 2," + dgvClientes.CurrentRow.Cells[3].Value.ToString());
    
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
            estadoInicial();
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            if (ValidarCliente(txtClienteNombre.Text, txtClienteApellido.Text, txtClienteDNI.Text, txtClienteMail.Text, txtClienteTelefono.Text, txtClienteDireccion.Text, txtClienteAltura.Text, txtClienteCodigoPostal.Text, txtClienteNacimiento.Text))
            {

                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                   
                    string query = String.Format("UPDATE [HAY_TABLA].[Cliente] SET Cli_Nombre = " + "'" + txtClienteNombre.Text.Trim() + "',Cli_Apellido =" + "'" + txtClienteApellido.Text.Trim() + "'," + "Cli_DNI =" + txtClienteDNI.Text.Trim() + ",Cli_Mail='" + txtClienteMail.Text.Trim() + "',Cli_Telefono=" + txtClienteTelefono.Text.Trim() + ",Cli_Direccion= '" + txtClienteDireccion.Text.Trim() + " " + txtClienteAltura.Text.Trim() + "',Cli_CodigoPostal =" + txtClienteCodigoPostal.Text.Trim() + ",Cli_FechaNacimiento = @FechaNacimiento WHERE Cli_Id =" + txtIdSeleccionado.Text);
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandText = query;

                    DateTime fechaNacimiento = DateTime.Parse(txtClienteNacimiento.Text);
                    SqlParameter param = new SqlParameter("@FechaNacimiento", fechaNacimiento);
                    param.SqlDbType = System.Data.SqlDbType.DateTime;
                    cmd.Parameters.Add(param);
                   

                    try
                    {
                        conexion.Open();
                        if (NoExiste(conexion, txtClienteDNI.Text.Trim(), dgvClientes.CurrentRow.Cells[3].Value.ToString(), "Cli_DNI", "DNI") && NoExiste(conexion, txtClienteTelefono.Text.Trim(), dgvClientes.CurrentRow.Cells[5].Value.ToString(), "Cli_Telefono", "Telefono"))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            estadoInicial();
                        }
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow.Cells[9].Value.ToString() == "False")
            {
                panelDatosClienteSeleccionado.Visible = false;
                btnModificar.Visible = false;
                btnEliminarCliente.Visible = false;
                btnAltaLogica.Visible = true;
            }else
            {
                txtIdSeleccionado.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtClienteNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtClienteApellido.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtClienteDNI.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtClienteMail.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtClienteTelefono.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                string dir = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                txtClienteDireccion.Text = dir.Substring(0, dir.LastIndexOf(" "));
                txtClienteAltura.Text = dir.Substring(dir.LastIndexOf(" "), (dir.Length - dir.LastIndexOf(" ")));
                txtClienteCodigoPostal.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
                DateTime fechaNacimiento = DateTime.Parse(dgvClientes.CurrentRow.Cells[8].Value.ToString());
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
                txtClienteNacimiento.Text = fNacimiento;
                panelDatosClienteSeleccionado.Visible = true;
                panelDatosNuevoCliente.Visible = false;
                btnCrearCliente.Visible = true;
                btnAltaLogica.Visible = false;
                btnEliminarCliente.Visible = true;
                btnModificar.Visible = true;
                btnGuardarDatos.Visible = false;
                btnDescartarCambios.Visible = false;
                camposHabilitados(false);
            }
        }


        void MostrarClientes()
        {
            DataTable dtClientes = new DataTable("Clientes");

            DataColumn cId = new DataColumn("Id");
            DataColumn cNombre = new DataColumn("Nombre");
            DataColumn cApellido = new DataColumn("Apellido");
            DataColumn cDNI = new DataColumn("DNI");
            DataColumn cMail = new DataColumn("Mail");
            DataColumn cTelefono = new DataColumn("Telefono");
            DataColumn cDireccion = new DataColumn("Direccion");
            DataColumn cCodigoPostal = new DataColumn("CodigoPostal");
            DataColumn cFechaNacimiento = new DataColumn("FechaNacimiento");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtClientes.Columns.Add(cId);
            dtClientes.Columns.Add(cNombre);
            dtClientes.Columns.Add(cApellido);
            dtClientes.Columns.Add(cDNI);
            dtClientes.Columns.Add(cMail);
            dtClientes.Columns.Add(cTelefono);
            dtClientes.Columns.Add(cDireccion);
            dtClientes.Columns.Add(cCodigoPostal);
            dtClientes.Columns.Add(cFechaNacimiento);
            dtClientes.Columns.Add(cHabilitado);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query;
                if (checkVerInhabilitados.Checked)
                {/// ver todos
                    if (txtFiltroDNI.Text == "") {
                        query = String.Format("SELECT * FROM [HAY_TABLA].[Cliente] c JOIN[HAY_TABLA].[Usuarios] U ON c.Cli_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Id_Rol = 2 AND Cli_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cli_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
                    }
                    else
                    {
                        query = String.Format("SELECT * FROM [HAY_TABLA].[Cliente] c JOIN[HAY_TABLA].[Usuarios] U ON c.Cli_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Id_Rol = 2 AND Cli_DNI = " + txtFiltroDNI.Text.Trim() + " AND  Cli_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cli_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
                    }
                }
                else {//ver solo habilitados
                    if (txtFiltroDNI.Text == "")
                    {
                        query = String.Format("SELECT * FROM [HAY_TABLA].[Cliente] c JOIN[HAY_TABLA].[Usuarios] U ON c.Cli_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Habilitado = 1  AND Id_Rol = 2 AND Cli_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cli_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
                    }
                    else
                    {
                        query = String.Format("SELECT * FROM [HAY_TABLA].[Cliente] c JOIN[HAY_TABLA].[Usuarios] U ON c.Cli_Usuario = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] ur ON u.Usu_Username = ur.Nombre_Usuario WHERE Habilitado = 1  AND Id_Rol = 2 AND Cli_DNI = " + txtFiltroDNI.Text.Trim() + " AND Cli_Nombre LIKE '%" + txtFiltroNombre.Text.Trim() + "%' AND Cli_Apellido LIKE '%" + txtFiltroApellido.Text.Trim() + "%' ");
                    }
                   
                }
               
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        DataRow row = dtClientes.NewRow();
                        row["Id"] = dr["Cli_Id"].ToString();
                        row["Nombre"] = dr["Cli_Nombre"].ToString();
                        row["Apellido"] = dr["Cli_Apellido"].ToString();
                        row["DNI"] = dr["Cli_DNI"].ToString();
                        row["Mail"] = dr["Cli_Mail"].ToString();
                        row["Telefono"] = dr["Cli_Telefono"].ToString();
                        row["Direccion"] = dr["Cli_Direccion"].ToString();
                        row["CodigoPostal"] = dr["Cli_CodigoPostal"].ToString();
                        row["FechaNacimiento"] = dr["Cli_FechaNacimiento"].ToString();
                        row["Habilitado"] = dr["Habilitado"].ToString();

                        dtClientes.Rows.Add(row);

                    }
                    dgvClientes.DataSource = dtClientes;
                    dgvClientes.AutoResizeColumns();
                    dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    if (checkVerInhabilitados.Checked)
                    {/// ver todos       
                        for (int i = 0; i < dgvClientes.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = dgvClientes.Rows[i];
                            if (row.Cells[9].Value.ToString() == "False")
                            {
                                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                            }
                            else {
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
        #endregion

        #region Validaciones

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



    private bool DniNoExiste(SqlConnection conexionAbierta, string DNI, string DNIActual)
        {
            if (DNI == DNIActual)
            {
                return true;
            }else {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [HAY_TABLA].[Cliente] WHERE Cli_DNI =" + DNI, conexionAbierta);
                SqlDataReader dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        MessageBox.Show("El dni " + DNI + " ya se encuentra registrado en el sistema");
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

        private bool NoExiste(SqlConnection conexionAbierta, string dato, string datoActual, string nombreCampoEnTabla, string nombreDelDato)
        {
            if (dato == datoActual)
            {
                return true;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [HAY_TABLA].[Cliente] WHERE " + nombreCampoEnTabla + " = " + dato, conexionAbierta);
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




        private bool ValidarCliente(string nombre, string apellido, string dni, string email, string telefono, string calle, string altura, string codigoPostal, string fechaNacimiento)
        {
            bool resultadoValidacion = true;
            resultadoValidacion = (Validador.validarMail(email) && Validador.validarStringVacio(telefono, "Telefono") && Validador.validarStringVacio(nombre, "Nombre") && Validador.validarStringVacio(apellido, "Apellido") && Validador.validarStringVacio(dni, "DNI") && Validador.validarStringVacio(calle, "Calle") && Validador.validarStringVacio(altura, "Altura") && Validador.validarStringVacio(codigoPostal, "Codigo Postal") && Validador.validarFecha(fechaNacimiento));
            return resultadoValidacion;
        }

        
        #endregion

        #region manejoInterfaz


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            estadoInicial();
            MostrarClientes();
        }

        public void camposHabilitados(bool estado)
        {
            txtClienteNombre.Enabled = estado;
            txtClienteApellido.Enabled = estado;
            txtClienteDNI.Enabled = estado;
            txtClienteMail.Enabled = estado;
            txtClienteTelefono.Enabled = estado;
            txtClienteDireccion.Enabled = estado;
            txtClienteAltura.Enabled = estado;
            txtClienteCodigoPostal.Enabled = estado;
            txtClienteNacimiento.Enabled = estado;
        }


        public void limpiarCamposNuevoCliente()
        {
            txtClienteNombreNuevo.Text = "";
            txtClienteApellidoNuevo.Text = "";
            txtClienteDNINuevo.Text = "";
            txtClienteMailNuevo.Text = "";
            txtClienteTelefonoNuevo.Text = "";
            txtClienteDireccionNuevo.Text = "";
            txtClienteAlturaNuevo.Text = "";
            txtClienteCodigoPostalNuevo.Text = "";
            txtClienteNacimientoNuevo.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            camposHabilitados(true);
            panelDatosClienteSeleccionado.Visible = true;
            btnModificar.Visible = false;
            btnEliminarCliente.Visible = false;
            btnGuardarDatos.Visible = true;
            btnDescartarCambios.Visible = true;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCamposNuevoCliente();
            btnCrearCliente.Visible = false;
            btnEliminarCliente.Visible = false;
            btnModificar.Visible = false;
            panelDatosNuevoCliente.Visible = true;
            panelDatosClienteSeleccionado.Visible = false;
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }



        private void btnCancelarCrear_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void estadoInicial()
        {
            MostrarClientes();
            limpiarCamposNuevoCliente();
            camposHabilitados(false);
            panelDatosNuevoCliente.Visible = false;
            panelDatosClienteSeleccionado.Visible = false;
            btnEliminarCliente.Visible = false;
            btnModificar.Visible = false;
            btnCrearCliente.Visible = true;
            btnAltaLogica.Visible = false;

        }


        #endregion

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AbmClientes_Load(object sender, EventArgs e)
        {

        }

        private void checkVerInhabilitados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void btnAltaLogica_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("EXEC [HAY_TABLA].[altaLogicaRolDelUsuario] 2," + dgvClientes.CurrentRow.Cells[3].Value.ToString());
                
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
            estadoInicial();
        }
    }
}
