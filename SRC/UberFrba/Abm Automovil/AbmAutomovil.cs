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
        public List<string> listaDePatentes = new List<string>();
        public List<string> listaDeTurnos = new List<string>();
        public AbmAutomovil()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            dgvAutomovil.ReadOnly = true;
            panelDatosSeleccionado.Visible = false;
            labelNota.Visible = false;
            MostrarAutomoviles();
            cargar_marcas();
            cargar_choferes();
            //cargar_turnos();
            dgvAutomovil.CurrentCell = dgvAutomovil.Rows[0].Cells[0];
            txtIdSeleccionado.Text = dgvAutomovil.CurrentRow.Cells[0].Value.ToString();
            txtPatente.Text = dgvAutomovil.CurrentRow.Cells[1].Value.ToString();
            comboMarca.Text = dgvAutomovil.CurrentRow.Cells[2].Value.ToString();
            comboMarca.SelectedItem = dgvAutomovil.CurrentRow.Cells[2].Value.ToString();
            txtModelo.Text = dgvAutomovil.CurrentRow.Cells[3].Value.ToString();
            txtLicencia.Text = dgvAutomovil.CurrentRow.Cells[4].Value.ToString();
            txtRodado.Text = dgvAutomovil.CurrentRow.Cells[5].Value.ToString();
            comboChofer.Text = dgvAutomovil.CurrentRow.Cells[6].Value.ToString();
            comboChofer.SelectedItem = dgvAutomovil.CurrentRow.Cells[6].Value.ToString();
            comboTurno.Text = dgvAutomovil.CurrentRow.Cells[7].Value.ToString();
            comboTurno.SelectedItem = dgvAutomovil.CurrentRow.Cells[7].Value.ToString();
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
            DataColumn cHabilitado = new DataColumn("Habilitado");
            
            dtAutomoviles.Columns.Add(cId);
            dtAutomoviles.Columns.Add(cPatente);
            dtAutomoviles.Columns.Add(cMarca);
            dtAutomoviles.Columns.Add(cModelo);
            dtAutomoviles.Columns.Add(cLicencia);
            dtAutomoviles.Columns.Add(cRodado);
            dtAutomoviles.Columns.Add(cChofer);
            dtAutomoviles.Columns.Add(cTurno);
            dtAutomoviles.Columns.Add(cHabilitado);

            listaDePatentes.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query;
                if (checkVerInhabilitados.Checked)
                {
                    query = String.Format("SELECT A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado," +
                    " cho.Cho_Nombre + ' ' + cho.Cho_Apellido AS Nombre_y_Apellido_Chofer ,T.Turno_Descripcion AS turno,A.Auto_Habilitado AS habilitado FROM [HAY_TABLA].[Automovil] A" +
                    " JOIN [HAY_TABLA].AsignacionDeTurnos asig ON asig.Auto_Id = A.Auto_id" +
                    " JOIN [HAY_TABLA].Chofer cho ON asig.Cho_Id = cho.Cho_Id" +
                    " JOIN [HAY_TABLA].Turno T ON T.Turno_Id = asig.Turno_Id" +
                    " WHERE Auto_Marca LIKE '" + comboFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%' AND cho.Cho_Nombre + ' ' + cho.Cho_Apellido LIKE '%" + txtFiltroChofer.Text.Trim() + "%'" + "ORDER BY A.Auto_Id,asig.Turno_Id DESC");
                }
                else
                {
                    query = String.Format("SELECT A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado," +
                    " cho.Cho_Nombre + ' ' + cho.Cho_Apellido AS Nombre_y_Apellido_Chofer ,T.Turno_Descripcion AS turno,A.Auto_Habilitado AS habilitado FROM [HAY_TABLA].[Automovil] A" +
                    " JOIN [HAY_TABLA].AsignacionDeTurnos asig ON asig.Auto_Id = A.Auto_id" +
                    " JOIN [HAY_TABLA].Chofer cho ON asig.Cho_Id = cho.Cho_Id" +
                    " JOIN [HAY_TABLA].Turno T ON T.Turno_Id = asig.Turno_Id" +
                    " WHERE Auto_Marca LIKE '" + comboFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%' AND cho.Cho_Nombre + ' ' + cho.Cho_Apellido LIKE '%" + txtFiltroChofer.Text.Trim() + "%'" + "AND A.Auto_Habilitado=1 " + "ORDER BY A.Auto_Id,asig.Turno_Id DESC");
                }
                    
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
                        row["Chofer"] = dr["Nombre_y_Apellido_Chofer"].ToString();
                        row["Turno"] = dr["turno"].ToString();
                        row["Habilitado"] = dr["habilitado"].ToString();

                        listaDePatentes.Add(dr["Auto_Patente"].ToString());

                        dtAutomoviles.Rows.Add(row);

                    }
                    dgvAutomovil.DataSource = dtAutomoviles;
                    dgvAutomovil.AutoResizeColumns();
                    dgvAutomovil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvAutomovil.CurrentCell = dgvAutomovil.Rows[0].Cells[0];

                    if (checkVerInhabilitados.Checked)
                    {/// ver todos       
                        for (int i = 0; i < dgvAutomovil.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = dgvAutomovil.Rows[i];
                            if (row.Cells[8].Value.ToString() == "False")
                            {
                                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.LimeGreen;
                            }

                            

                            if (dgvAutomovil.CurrentRow.Cells[8].Value.ToString().Equals("True"))
                            {
                                btn_eliminar.Text = "Inhabilitar";
                            }
                            else
                            {
                                btn_eliminar.Text = "Habilitar";
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

        private void btn_modificar_Click(object sender, EventArgs e)
        {

            comboTurno.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("  SELECT [Turno_Descripcion] FROM [HAY_TABLA].[Turno] turno JOIN [HAY_TABLA].[AsignacionDeTurnos] asig ON asig.Turno_Id=turno.Turno_Id JOIN [HAY_TABLA].[Chofer] chofer ON chofer.Cho_Id=asig.Cho_Id WHERE [Cho_Nombre] + ' ' + [Cho_Apellido]='" + comboChofer.Text + "' ORDER BY turno.Turno_Id DESC ");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboTurno.Items.Add(dr["Turno_Descripcion"].ToString());
                        listaDeTurnos.Add(dr["Turno_Descripcion"].ToString());
                    }
                    
                    comboTurno.SelectedItem = dgvAutomovil.CurrentRow.Cells[7].Value.ToString();

                    panelDatosSeleccionado.Visible = true;
                    panel1.Visible = false;
                    button2.Visible = false; //Pongo invisible el boton que tiene el insert
                    button3.Visible = true; //Pongo visible el boton que tiene el update
                    label27.Text = "Modificar Automovil";
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                //string query = String.Format("DELETE FROM [HAY_TABLA].[Automovil] WHERE Auto_Id =" + txtIdSeleccionado.Text);
                string query;

                if (dgvAutomovil.CurrentRow.Cells[8].Value.ToString().Equals("True"))
                {
                    query = String.Format("EXEC [HAY_TABLA].[bajaLogicaAutomovil] " + dgvAutomovil.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    query = String.Format("EXEC [HAY_TABLA].[altaLogicaAutomovil] " + dgvAutomovil.CurrentRow.Cells[0].Value.ToString());
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
            comboTurno.Items.Clear();
            comboMarca.SelectedItem = null;
            comboChofer.SelectedItem = null;
            comboTurno.SelectedItem = null;
            comboTurno.Items.Clear();
                        
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            MostrarAutomoviles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboFiltroMarca.SelectedItem = null;
           // comboFiltroMarca.Items.Clear();
            txtFiltroModelo.Text = "";
            txtFiltroPatente.Text = "";
            txtFiltroChofer.Text = "";
            MostrarAutomoviles();
            //cargar_marcas();
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
                    string idchoferviejo =dgvAutomovil.CurrentRow.Cells[6].Value.ToString();
                    string idturnoviejo = dgvAutomovil.CurrentRow.Cells[7].Value.ToString();
                    string patentevieja = dgvAutomovil.CurrentRow.Cells[1].Value.ToString();
                    listaDeTurnos.RemoveAll(x => x == (dgvAutomovil.CurrentRow.Cells[7].Value.ToString()));
                    
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
                    command.Transaction = sqlTransact;
                    SqlCommand command2 = conexion.CreateCommand();
                    command2.Transaction = sqlTransact;
                    SqlCommand command3 = conexion.CreateCommand();
                    command3.Transaction = sqlTransact;
                    SqlCommand command4 = conexion.CreateCommand();
                    command4.Transaction = sqlTransact;
                    SqlCommand command5 = conexion.CreateCommand();
                    command5.Transaction = sqlTransact;
                    SqlCommand command6 = conexion.CreateCommand();
                    command6.Transaction = sqlTransact;
                    /* command7 = conexion.CreateCommand();
                    command7.Transaction = sqlTransact;*/
                    SqlCommand command8 = conexion.CreateCommand();
                    command8.Transaction = sqlTransact;
                    /*SqlCommand command9 = conexion.CreateCommand();
                    command9.Transaction = sqlTransact;*/
                    SqlCommand command10 = conexion.CreateCommand();
                    command10.Transaction = sqlTransact;
                    try
                    {
                        string query = String.Format("UPDATE [HAY_TABLA].[Automovil] SET Auto_Patente='" + txtPatente.Text.Trim() + "',Auto_Marca='" + comboMarca.Text.Trim() + "',Auto_Modelo='" + txtModelo.Text.Trim() + "',Auto_Licencia='" + txtLicencia.Text.Trim() + "',Auto_Rodado='" + txtRodado.Text.Trim() + "' WHERE Auto_Id =" + txtIdSeleccionado.Text);
                        command.CommandText = query;

                        string queryidChoferviejo = String.Format("SELECT Cho_Id FROM [HAY_TABLA].Chofer WHERE [Cho_Nombre] + ' ' + [Cho_Apellido] ='" + idchoferviejo + "'");
                        string queryidTurnoviejo = String.Format("SELECT Turno_Id FROM [HAY_TABLA].Turno WHERE Turno_Descripcion ='" + idturnoviejo + "'");
                        command5.CommandText = queryidChoferviejo;
                        command6.CommandText = queryidTurnoviejo;
                        Int32 idChoferV = (Int32)command5.ExecuteScalar();
                        Int32 idTurnoV = (Int32)command6.ExecuteScalar();

                        string queryidChofernuevo = String.Format("SELECT Cho_Id FROM [HAY_TABLA].Chofer WHERE [Cho_Nombre] + ' ' + [Cho_Apellido] ='" + comboChofer.Text.Trim() + "'");
                        string queryidTurnonuevo = String.Format("SELECT Turno_Id FROM [HAY_TABLA].Turno WHERE Turno_Descripcion ='" + comboTurno.Text.Trim() + "'");
                        command3.CommandText = queryidChofernuevo;
                        command4.CommandText = queryidTurnonuevo;

                        Int32 idChofer = (Int32)command3.ExecuteScalar();
                        Int32 idTurno = (Int32)command4.ExecuteScalar();

                        string query2 = String.Format("UPDATE[HAY_TABLA].[AsignacionDeTurnos] SET Auto_Id = 0 WHERE Turno_Id = " + idTurnoV + " AND Cho_Id = " + idChoferV);
                      // string query2 = String.Format("DELETE FROM [HAY_TABLA].[AsignacionDeTurnos] WHERE Turno_Id=" + idTurnoV + " AND Cho_Id=" + idChoferV + " AND Auto_Id=" + txtIdSeleccionado.Text);
                        command2.CommandText = query2;

                       
                        string query3 = String.Format("UPDATE [HAY_TABLA].[AsignacionDeTurnos] SET Auto_Id = " + txtIdSeleccionado.Text + " WHERE Turno_Id =" + idTurno + "AND Cho_Id =" + idChofer);
                        //string query3 = String.Format("INSERT INTO [HAY_TABLA].[AsignacionDeTurnos] VALUES (" + idTurno + "," + idChofer + "," + txtIdSeleccionado.Text + ")");
                        command8.CommandText = query3;

                        /*
                         * 
                        string query3 = String.Format("UPDATE [HAY_TABLA].[AsignacionDeTurnos] SET Auto_Id = " + txtIdSeleccionado.Text + " WHERE Turno_Id = " + idTurno + ", Cho_Id = " + idChofer + "," + txtIdSeleccionado.Text + ")");
                        command8.CommandText = query3;
                         * **/

                        /*string query4 = String.Format("SELECT COUNT(*) FROM [HAY_TABLA].[AsignacionDeTurnos] WHERE Turno_Id=" + idTurno + "AND Auto_Id=" + txtIdSeleccionado.Text);
                        command7.CommandText = query4;
                        Int32 cantidadDeIgualesTurnos = (Int32)command7.ExecuteScalar();

                        string query5 = String.Format("SELECT COUNT(*) FROM [HAY_TABLA].[Automovil] WHERE Auto_Patente='" + txtPatente.Text + "'");
                        command9.CommandText = query5;
                        Int32 cantidadDeIgualesPatentes = (Int32)command9.ExecuteScalar();
                        */
                        string query6 = String.Format("SELECT DISTINCT Auto_Patente FROM [HAY_TABLA].[Automovil] auto JOIN [HAY_TABLA].[AsignacionDeTurnos] asig ON (auto.Auto_Id=asig.Auto_Id) JOIN [HAY_TABLA].[Chofer] chofer ON (chofer.Cho_Id=asig.Cho_Id) WHERE [Cho_Nombre] + ' ' + [Cho_Apellido] ='" + comboChofer.Text + "'");
                        command10.CommandText = query6;
                        string patenteQuePosee = (string)command10.ExecuteScalar();

                            command.ExecuteNonQuery();
                            command2.ExecuteNonQuery();
                            command8.ExecuteNonQuery();
                            command10.ExecuteNonQuery();
                            
                            if (((patentevieja != txtPatente.Text && listaDePatentes.Contains(txtPatente.Text)) || ((txtPatente.Text != patenteQuePosee) && (!idchoferviejo.Equals(comboChofer.Text))) || (listaDeTurnos.Contains(comboTurno.Text)))&& patenteQuePosee != null)
                                {
                                    if (patentevieja != txtPatente.Text && listaDePatentes.Contains(txtPatente.Text))
                                    {
                                        MessageBox.Show("La patente ya ha sido registrada por otro automovil");
                                        sqlTransact.Rollback();
                                        return;
                                    }

                                    if ((txtPatente.Text != patenteQuePosee) && (!idchoferviejo.Equals(comboChofer.Text)))
                                    {
                                        MessageBox.Show("El chofer ya posee otro automovil");
                                        sqlTransact.Rollback();
                                        return;
                                    }
                                    if (listaDeTurnos.Contains(comboTurno.Text))
                                    {
                                        MessageBox.Show("El chofer ya posee automovil en ese turno");
                                        sqlTransact.Rollback();
                                    }
                            }
                            else
                            {
                                if (idTurnoV == idTurno) {
                                    sqlTransact.Commit();
                                    MessageBox.Show("La modificacion de los datos se ha realizado exitosamente");
                                    MostrarAutomoviles();
                                    panelDatosSeleccionado.Visible = false;
                                    panel1.Visible = true;
                                    listaDeTurnos.Clear();
                                } else {
                                MessageBox.Show("Los cambios de auto deben ser dentro del mismo turno");
                            }   
                            }
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlTransact.Rollback();
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
            resultadoValidacion = (Validador.validarStringVacio(patente, "Patente") && Validador.validarStringVacio(marca, "Marca") && Validador.validarStringVacio(modelo, "Modelo") && Validador.validarStringVacio(licencia, "Licencia") && Validador.validarStringVacio(rodado, "Rodado") && Validador.validarStringVacio(chofer, "Chofer") && Validador.validarStringVacio(turno, "Turno"));
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
            if (dgvAutomovil.CurrentRow.Cells[8].Value.ToString().Equals("True"))
            {
                btn_eliminar.Text = "Inhabilitar";
            }
            else
            {
                btn_eliminar.Text = "Habilitar";
            }
                               
        }
        private void btn_guardar_nuevo_Click(object sender, EventArgs e)
        {
        if (Validar(txtPatente.Text, comboMarca.Text, txtModelo.Text, txtLicencia.Text, txtRodado.Text, comboChofer.Text, comboTurno.Text))
            {
                 using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    conexion.Open();
                    SqlTransaction sqlTransact = conexion.BeginTransaction();
                    SqlCommand command = conexion.CreateCommand();
					command.Transaction = sqlTransact;
					SqlCommand command2 = conexion.CreateCommand();
					command2.Transaction = sqlTransact;
					SqlCommand command3 = conexion.CreateCommand();
					command3.Transaction = sqlTransact;
					SqlCommand command4 = conexion.CreateCommand();
					command4.Transaction = sqlTransact;
					SqlCommand command6 = conexion.CreateCommand();
					command6.Transaction = sqlTransact;
					try
                    {
						string query = String.Format("SELECT DISTINCT Auto_Patente FROM [HAY_TABLA].[Automovil] auto JOIN [HAY_TABLA].[AsignacionDeTurnos] asig ON (auto.Auto_Id=asig.Auto_Id) JOIN [HAY_TABLA].[Chofer] chofer ON (chofer.Cho_Id=asig.Cho_Id) WHERE [Cho_Nombre] + ' ' + [Cho_Apellido] ='" + comboChofer.Text + "'");
                        command.CommandText = query;
                        string patenteQuePosee = (string)command.ExecuteScalar();
						
						string queryidChofernuevo = String.Format("SELECT Cho_Id FROM [HAY_TABLA].Chofer WHERE [Cho_Nombre] + ' ' + [Cho_Apellido] ='" + comboChofer.Text.Trim() + "'");
                        command4.CommandText = queryidChofernuevo;
                        Int32 idChofer = (Int32)command4.ExecuteScalar();

                        string query3 = String.Format("INSERT INTO [HAY_TABLA].[Automovil] (Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado) OUTPUT Inserted.Auto_Id VALUES (");
                        query3 += "'" + txtPatente.Text.Trim() + "','" + comboMarca.Text.Trim() + "','" + txtModelo.Text.Trim() + "','" + txtLicencia.Text.Trim() + "','" + txtRodado.Text.Trim() + "')";
                        command3.CommandText = query3;
                        Int32 idAuto = (Int32)command3.ExecuteScalar();

                        string query2 = String.Format("UPDATE [HAY_TABLA].[AsignacionDeTurnos] SET Auto_Id=" +  idAuto + "WHERE Cho_Id=" + idChofer);
                        command2.CommandText = query2;
                        command2.ExecuteNonQuery();

						 if ((listaDePatentes.Contains(txtPatente.Text)) || (patenteQuePosee != null) )
						{
							if (listaDePatentes.Contains(txtPatente.Text))
							{
							MessageBox.Show("La patente ya ha sido registrada por otro automovil");
                            sqlTransact.Rollback();
                            return;
                            }
                            if (patenteQuePosee != null)
							{
							MessageBox.Show("El chofer ya posee otro automovil");
                            sqlTransact.Rollback();
							}
						}
						else
                            {
                                sqlTransact.Commit();
                                MessageBox.Show("Se ha agregado un automovil exitosamente");
                                MostrarAutomoviles();
                                panelDatosSeleccionado.Visible = false;
                                panel1.Visible = true;
								cargar_marcas();
								cargar_choferes();
                            }
					}
					catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlTransact.Rollback();
                    }
                }
            }
        }

        private void cargar_marcas()
        {
            comboMarca.Items.Clear();
            comboFiltroMarca.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT DISTINCT Auto_Marca FROM [HAY_TABLA].[Automovil]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboMarca.Items.Add(dr["Auto_Marca"].ToString());
                        comboFiltroMarca.Items.Add(dr["Auto_Marca"].ToString());
                    }

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cargar_choferes()
        {
            comboChofer.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT  Cho_Nombre + ' ' + Cho_Apellido AS Nombre_y_Apellido_Chofer FROM [HAY_TABLA].[Chofer]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboChofer.Items.Add(dr["Nombre_y_Apellido_Chofer"].ToString());
                    }

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cargar_turnos()
        {
            comboTurno.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT  Turno_Descripcion AS turno FROM [HAY_TABLA].[Turno]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboTurno.Items.Add(dr["turno"].ToString());
                    }

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboChofer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboTurno.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("  SELECT [Turno_Descripcion] FROM [HAY_TABLA].[Turno] turno JOIN [HAY_TABLA].[AsignacionDeTurnos] asig ON asig.Turno_Id=turno.Turno_Id JOIN [HAY_TABLA].[Chofer] chofer ON chofer.Cho_Id=asig.Cho_Id WHERE [Cho_Nombre] + ' ' + [Cho_Apellido]='" + comboChofer.Text + "' ORDER BY turno.Turno_Id DESC ");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboTurno.Items.Add(dr["Turno_Descripcion"].ToString());
                        listaDeTurnos.Add(dr["Turno_Descripcion"].ToString());
                    }
                   
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboTurno_MouseEnter(object sender, EventArgs e)
        {
            labelNota.Visible = true;
        }

        private void comboTurno_MouseLeave(object sender, EventArgs e)
        {
            labelNota.Visible = false;
        }

        private void checkVerInhabilitados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAutomoviles();
        }
    }
}
