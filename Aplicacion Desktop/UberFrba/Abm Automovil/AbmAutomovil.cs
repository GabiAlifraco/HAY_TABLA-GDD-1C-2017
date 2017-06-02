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

namespace UberFrba.Abm_Automovil
{
    public partial class AbmAutomovil : Form
    {
        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }

        public AbmAutomovil()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            dgvAutomovil.ReadOnly = true;
            panelDatosSeleccionado.Visible = false;
            MostrarAutomoviles();
            cargar_marcas();
        }

        private void MostrarAutomoviles()
        {
            DataTable dtAutomoviles = new DataTable("Automoviles");

            DataColumn cId = new DataColumn("Id");
            DataColumn cPatente = new DataColumn("Patente");
            DataColumn cMarca = new DataColumn("Marca");
            DataColumn cModelo = new DataColumn("Modelo");
            DataColumn cLicencia = new DataColumn("Licencia");
            DataColumn cRodado = new DataColumn("Rodado");
            DataColumn cChofer = new DataColumn("Chofer");
            DataColumn cTurno = new DataColumn("Turno");

            dtAutomoviles.Columns.Add(cId);
            dtAutomoviles.Columns.Add(cPatente);
            dtAutomoviles.Columns.Add(cMarca);
            dtAutomoviles.Columns.Add(cModelo);
            dtAutomoviles.Columns.Add(cLicencia);
            dtAutomoviles.Columns.Add(cRodado);
            dtAutomoviles.Columns.Add(cChofer);
            dtAutomoviles.Columns.Add(cTurno);

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                //Falta el filtro por chofer
                string query = String.Format("SELECT * FROM [HAY_TABLA].[Automovil] WHERE Auto_Marca LIKE '" + txtFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%' ");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        DataRow row = dtAutomoviles.NewRow();
                        row["Id"] = dr["Auto_Id"].ToString();
                        row["Patente"] = dr["Auto_Patente"].ToString();
                        row["Marca"] = dr["Auto_Marca"].ToString();
                        row["Modelo"] = dr["Auto_Modelo"].ToString();
                        row["Licencia"] = dr["Auto_Licencia"].ToString();
                        row["Rodado"] = dr["Auto_Rodado"].ToString();
                        //row["Chofer"] = dr["Auto_Chofer"].ToString();
                        //row["Turno"] = dr["Auto_Turno"].ToString();

                        dtAutomoviles.Rows.Add(row);

                    }
                    dgvAutomovil.DataSource = dtAutomoviles;
                    dgvAutomovil.AutoResizeColumns();
                    dgvAutomovil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            
            panelDatosSeleccionado.Visible = true;
            panel1.Visible = false;
            button2.Visible = false; //Pongo invisible el boton que tiene el insert
            button3.Visible = true; //Pongo visible el boton que tiene el update
            label27.Text = "Modificar Automovil";
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("DELETE FROM [HAY_TABLA].[Automovil] WHERE Auto_Id =" + txtIdSeleccionado.Text);
                MessageBox.Show(query);
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
            MostrarAutomoviles();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panelDatosSeleccionado.Visible = true;
            button2.Visible = true; //Pongo visible el boton que tiene el insert
            button3.Visible = false; //Pongo invisible el boton que tiene el update

            label27.Text = "Agregar Automovil";
            txtIdSeleccionado.Text = "";
            txtPatente.Text = "";
            comboMarca.Text = "";
            txtModelo.Text = "";
            txtLicencia.Text = "";
            txtRodado.Text = "";
            comboChofer.Text = "";
            comboTurno.Text = "";
                        
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            MostrarAutomoviles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFiltroMarca.Text = "";
            txtFiltroModelo.Text = "";
            txtFiltroPatente.Text = "";
            txtFiltroChofer.Text = "";
            MostrarAutomoviles();
        }

        private void AbmAutomovil_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelDatosSeleccionado.Visible = false;
            panel1.Visible = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            txtIdSeleccionado.Text = "";
            txtPatente.Text = "";
            comboMarca.Text = "";
            txtModelo.Text = "";
            txtLicencia.Text = "";
            txtRodado.Text = "";
            comboChofer.Text = "";
            comboTurno.Text = "";

        }

        private void btn_guardar_modificar_Click(object sender, EventArgs e)
        {
            if (Validar(txtPatente.Text, comboMarca.Text, txtModelo.Text, txtLicencia.Text, txtRodado.Text, comboChofer.Text, comboTurno.Text))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("UPDATE [HAY_TABLA].[Automovil] SET Auto_Patente='" + txtPatente.Text.Trim() + "',Auto_Marca='" + comboMarca.Text.Trim() + "',Auto_Modelo='" + txtModelo.Text.Trim() + "',Auto_Licencia='" + txtLicencia.Text.Trim() + "',Auto_Rodado='" + txtRodado.Text.Trim() + "' WHERE Auto_Id =" + txtIdSeleccionado.Text);
                    MessageBox.Show(query);
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    try
                    {
                        conexion.Open();
                        if (NoExiste(conexion, txtPatente.Text.Trim(), dgvAutomovil.CurrentRow.Cells[1].Value.ToString(), "Auto_Patente", "Patente"))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            MessageBox.Show("La modificacion de los datos se ha realizado exitosamente");

                            MostrarAutomoviles();
                            panelDatosSeleccionado.Visible = false;
                            panel1.Visible = true;
                           
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM [HAY_TABLA].[Automovil] WHERE " + nombreCampoEnTabla + " ='" + dato + "'" , conexionAbierta);
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
        private bool Validar(string patente, string marca, string modelo, string licencia, string rodado, string chofer, string turno)
        {
            bool resultadoValidacion = true;
            resultadoValidacion = (Validador.validarStringVacio(patente, "Patente") && Validador.validarStringVacio(marca, "Marca") && Validador.validarStringVacio(modelo, "Modelo") && Validador.validarStringVacio(licencia, "Licencia") && Validador.validarStringVacio(rodado, "Rodado"));
            //Falta agregar && Validador.validarStringVacio(chofer, "Chofer") && Validador.validarStringVacio(turno, "Turno")
            //Eso lo hacemos cuando resolvamos el problema de los choferes y turnos en esta tabla
            return resultadoValidacion;
        }

        private void dgvAutomovil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdSeleccionado.Text = dgvAutomovil.CurrentRow.Cells[0].Value.ToString();
            txtPatente.Text = dgvAutomovil.CurrentRow.Cells[1].Value.ToString();
            comboMarca.Text = dgvAutomovil.CurrentRow.Cells[2].Value.ToString();
            txtModelo.Text = dgvAutomovil.CurrentRow.Cells[3].Value.ToString();
            txtLicencia.Text = dgvAutomovil.CurrentRow.Cells[4].Value.ToString();
            txtRodado.Text = dgvAutomovil.CurrentRow.Cells[5].Value.ToString();
            comboChofer.Text = dgvAutomovil.CurrentRow.Cells[6].Value.ToString();
            comboTurno.Text = dgvAutomovil.CurrentRow.Cells[7].Value.ToString();
                               
        }
        private void btn_guardar_nuevo_Click(object sender, EventArgs e)
        {
        if (Validar(txtPatente.Text, comboMarca.Text, txtModelo.Text, txtLicencia.Text, txtRodado.Text, comboChofer.Text, comboTurno.Text))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("INSERT INTO [HAY_TABLA].[Automovil] (Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado) VALUES (");
                    query += "'" + txtPatente.Text.Trim() + "','" + comboMarca.Text.Trim() + "','" + txtModelo.Text.Trim() + "','" + txtLicencia.Text.Trim() + "','" + txtRodado.Text.Trim() + "')";
                    MessageBox.Show(query);
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    try
                    {
                        conexion.Open();
                        if (NoExiste(conexion, txtPatente.Text.Trim(), dgvAutomovil.CurrentRow.Cells[1].Value.ToString(), "Auto_Patente", "Patente"))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            MessageBox.Show("Se ha agregado un automovil exitosamente");
                            MostrarAutomoviles();
                            panelDatosSeleccionado.Visible = false;
                            panel1.Visible = true;

                        }
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cargar_marcas()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                //Falta el filtro por chofer
                string query = String.Format("SELECT Nombre_Marca FROM [HAY_TABLA].[MARCA]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboMarca.Items.Add(dr["Nombre_Marca"].ToString());
                    }

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
