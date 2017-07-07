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
            AbmChofer formChofer = new AbmChofer();
            formChofer.Show();
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
                    string query = String.Format("INSERT INTO [HAY_TABLA].[Chofer] (Cho_Nombre, Cho_Apellido, Cho_DNI, Cho_Mail, Cho_Telefono, Cho_Direccion, Cho_FechaNacimiento,Cho_Piso,Cho_Departamento,Cho_Localidad) VALUES (@Nombre,@Apellido,@DNI,@Mail,@Telefono,@Direccion,@FechaNacimiento,@Piso,@Departamento,@Localidad) ");
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


            if (ValidarChofer(txtNombreNuevo.Text, txtApellidoNuevo.Text, txtChoferDNINuevo.Text, txtMailNuevo.Text, txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtAlturaNuevo.Text, txtNacimientoNuevo.Text, txtPiso.Text, txtDepto.Text, textBox1.Text))
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

                            AbmChofer formChofer = new AbmChofer();
                            formChofer.Show();
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




        private bool ValidarChofer(string nombre, string apellido, string dni, string email, string telefono, string calle, string altura, string fechaNacimiento,string piso,string departamento,string localidad)
        {
            bool resultadoValidacion = true;
            resultadoValidacion = (Validador.validarStringVacio(email, "Mail") && Validador.validarStringVacio(telefono, "Telefono") && Validador.validarMail(email) && Validador.validarStringVacio(nombre, "Nombre") && Validador.validarStringVacio(apellido, "Apellido") && Validador.validarStringVacio(dni, "DNI") && Validador.validarStringVacio(calle, "Calle") && Validador.validarStringVacio(altura, "Altura") && Validador.validarFecha(fechaNacimiento) && Validador.validarStringVacio(piso, "Piso") && Validador.validarStringVacio(departamento, "Departamento") && Validador.validarStringVacio(localidad, "Localidad"));
            return resultadoValidacion;
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void datosAleatorios() {
            Random rnd = new Random();
            string aleatorio1 = RandomPassword.Generate();
            string aleatorio2 = RandomPassword.Generate();
            string aleatorio3 = RandomPassword.Generate();
            int dni_aleatorio = rnd.Next(16000000, 45000000);
            int telefono_aleatorio = rnd.Next(1500000000, 1599999999);
            int altura = rnd.Next(0000, 9999);
            int dia, mes, anno;
            Random rand = new Random();
            anno = 1 + rand.Next(1950, 2016);
            mes = 1 + rand.Next(10, 12);
            dia = 1 + rand.Next(10, 28);
            string fechaJunta = (dia.ToString() + mes.ToString() + anno.ToString());

            int piso = rnd.Next(0, 99);
            string departamento = RandomPassword.Generate();
            string localidad = RandomPassword.Generate();

            txtNombreNuevo.Text = aleatorio1;
            txtApellidoNuevo.Text = aleatorio2;
            txtMailNuevo.Text = aleatorio1 + "_" + aleatorio2 + "@gmail.com";
            txtDireccionNuevo.Text = aleatorio3;
            txtChoferDNINuevo.Text = dni_aleatorio.ToString();
            txtTelefonoNuevo.Text = telefono_aleatorio.ToString();
            txtAlturaNuevo.Text = altura.ToString();
            txtNacimientoNuevo.Text = fechaJunta;
            txtPiso.Text = piso.ToString();
            txtDepto.Text = departamento;
            textBox1.Text = localidad;
        }

        private void btnDatosAleatorios_Click(object sender, EventArgs e)
        {
            datosAleatorios();
        }
    }
}
