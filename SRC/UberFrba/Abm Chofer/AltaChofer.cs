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
    public partial class AltaChofer : Form
    {
        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }
        public AltaChofer()
        {
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            InitializeComponent();

        }

        private void btnCancelarCrear_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void crearChofer()
        {



            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                //SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                //command.Transaction = sqlTransact;
                try
                {
                    //string query = String.Format("INSERT INTO [HAY_TABLA].[Chofer] (Cho_Nombre, Cho_Apellido, Cho_DNI, Cho_Mail, Cho_Telefono, Cho_Direccion, Cho_FechaNacimiento) OUTPUT Inserted.Cho_Id VALUES (@Nombre,@Apellido,@DNI,@Mail,@Telefono,@Direccion,@FechaNacimiento) ");
                    string query = String.Format("INSERT INTO [HAY_TABLA].[Chofer] (Cho_Nombre, Cho_Apellido, Cho_DNI, Cho_Mail, Cho_Telefono, Cho_Direccion, Cho_FechaNacimiento) VALUES (@Nombre,@Apellido,@DNI,@Mail,@Telefono,@Direccion,@FechaNacimiento) ");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@Nombre", txtNombreNuevo.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Apellido", txtApellidoNuevo.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@DNI", txtChoferDNINuevo.Text);
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Mail", txtMailNuevo.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Telefono", txtTelefonoNuevo.Text);
                    param.SqlDbType = System.Data.SqlDbType.BigInt;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Direccion", txtDireccionNuevo.Text + " " + txtAlturaNuevo.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    DateTime fechaNacimiento = DateTime.Parse(txtNacimientoNuevo.Text);
                    param = new SqlParameter("@FechaNacimiento", fechaNacimiento);
                    param.SqlDbType = System.Data.SqlDbType.DateTime;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    //                    SqlDataReader dr = command.ExecuteReader();
                    //                  dr.Close();
                    // int idChofer = (int)command.ExecuteScalar();


                    //sqlTransact.Commit();
                    MessageBox.Show("El chofer fue creado con exito");
                    MessageBox.Show("Se creo un usuario con username:'" + txtChoferDNINuevo.Text + "' password:'" + txtChoferDNINuevo.Text + "' y rol 'Chofer'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                    //sqlTransact.Rollback();
                }
                conexion.Close();
            }
        }

        // conexion.Open();
        /*
         * 
         * INSERT INTO [HAY_TABLA].Chofer (Cho_Nombre)
OUTPUT Inserted.Cho_Id
VALUES('bob');
         * */


        private void btnCrear_Click(object sender, EventArgs e)
        {


            if (ValidarChofer(txtNombreNuevo.Text, txtApellidoNuevo.Text, txtChoferDNINuevo.Text, txtMailNuevo.Text, txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtAlturaNuevo.Text, txtNacimientoNuevo.Text))
            {

                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    try
                    {

                        if (Validador.NoExiste(conexion, txtChoferDNINuevo.Text.Trim(), "", "Cho_DNI", "DNI","Chofer") && Validador.NoExiste(conexion, txtTelefonoNuevo.Text.Trim(), "", "Cho_Telefono", "Telefono","Chofer") && Validador.NoExiste(conexion, txtChoferDNINuevo.Text.Trim(), "", "Cli_DNI", "DNI", "Cliente"))
                        {
                            conexion.Close();
                            crearChofer();
                            this.Close();
                        }

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            resultadoValidacion = (Validador.validarStringVacio(email, "Mail") && Validador.validarStringVacio(telefono,"Telefono") && Validador.validarMail(email) && Validador.validarStringVacio(nombre, "Nombre") && Validador.validarStringVacio(apellido, "Apellido") && Validador.validarStringVacio(dni, "DNI") && Validador.validarStringVacio(calle, "Calle") && Validador.validarStringVacio(altura, "Altura") && Validador.validarFecha(fechaNacimiento));
            return resultadoValidacion;
        }




    }
}
