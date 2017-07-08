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
        private List<KeyValuePair<int, string>> listaKVPTurnos = new List<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> listaKVPTurnosSeleccionados = new List<KeyValuePair<int, string>>();
        public AbmAutomovil()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            dgvAutomovil.ReadOnly = true;
            panelDatosSeleccionado.Visible = false;
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

            if (Validador.VerificarActivoRol(3))
            {
                comboChofer.Enabled = true;
                btn_nuevo.Enabled = true;
            }
            else
            {
                comboChofer.Enabled = false;
                btn_nuevo.Enabled = false;
                MessageBox.Show("El ROL CHOFER esta INHABILITADO por lo cual no hay choferes HABILITADOS, por favor habilitelo desde la seccion ABM-ROL para poder crear automoviles y/o modificar la asignacion de sus choferes");
            }
           
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
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtAutomoviles.Columns.Add(cId);
            dtAutomoviles.Columns.Add(cPatente);
            dtAutomoviles.Columns.Add(cMarca);
            dtAutomoviles.Columns.Add(cModelo);
            dtAutomoviles.Columns.Add(cLicencia);
            dtAutomoviles.Columns.Add(cRodado);
            dtAutomoviles.Columns.Add(cChofer);
            dtAutomoviles.Columns.Add(cHabilitado);

            listaDePatentes.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query;
                string query2;
                if (checkVerInhabilitados.Checked)
                {
                    query = String.Format("SELECT A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado," +
                    " cho.Cho_Nombre + ' ' + cho.Cho_Apellido AS Nombre_y_Apellido_Chofer,A.Auto_Habilitado AS habilitado FROM [HAY_TABLA].[Automovil] A" +
                    " JOIN [HAY_TABLA].AsignacionDeTurnos asig ON asig.Auto_Id = A.Auto_id" +
                    " JOIN [HAY_TABLA].Chofer cho ON asig.Cho_Id = cho.Cho_Id" +
                    " WHERE Auto_Marca LIKE '%" + comboFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%' AND cho.Cho_Nombre + ' ' + cho.Cho_Apellido LIKE '%" + txtFiltroChofer.Text.Trim() + "%'" +
                    " GROUP BY A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado,cho.Cho_Nombre,cho.Cho_Apellido,A.Auto_Habilitado" + " ORDER BY A.Auto_Id DESC"
                    );


                    query2 = String.Format("SELECT A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado,A.Auto_Habilitado AS habilitado FROM [HAY_TABLA].[Automovil] A " +
                    "JOIN [HAY_TABLA].AsignacionDeTurnos asig ON asig.Auto_Id = A.Auto_id " +
                    "WHERE NOT EXISTS(SELECT * FROM[HAY_TABLA].[Chofer] c WHERE c.Cho_Id = asig.Cho_Id) AND Auto_Marca LIKE '" + comboFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%'" +
                    "GROUP BY A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado,A.Auto_Habilitado ORDER BY A.Auto_Id DESC");
                }
                else
                {
                    query = String.Format("SELECT A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado," +
                    " cho.Cho_Nombre + ' ' + cho.Cho_Apellido AS Nombre_y_Apellido_Chofer,A.Auto_Habilitado AS habilitado FROM [HAY_TABLA].[Automovil] A" +
                    " JOIN [HAY_TABLA].AsignacionDeTurnos asig ON asig.Auto_Id = A.Auto_id" +
                    " JOIN [HAY_TABLA].Chofer cho ON asig.Cho_Id = cho.Cho_Id" +
                    " WHERE Auto_Marca LIKE '%" + comboFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%' AND cho.Cho_Nombre + ' ' + cho.Cho_Apellido LIKE '%" + txtFiltroChofer.Text.Trim() + "%'" + "AND A.Auto_Habilitado=1 " +
                    " GROUP BY A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado,cho.Cho_Nombre,cho.Cho_Apellido,A.Auto_Habilitado" + " ORDER BY A.Auto_Id DESC");


                    query2 = String.Format("SELECT A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado,A.Auto_Habilitado AS habilitado FROM [HAY_TABLA].[Automovil] A " +
                    "JOIN [HAY_TABLA].AsignacionDeTurnos asig ON asig.Auto_Id = A.Auto_id " +
                    "WHERE NOT EXISTS(SELECT * FROM[HAY_TABLA].[Chofer] c WHERE c.Cho_Id = asig.Cho_Id) AND Auto_Marca LIKE '" + comboFiltroMarca.Text.Trim() + "%' AND Auto_Modelo LIKE '%" + txtFiltroModelo.Text.Trim() + "%' AND Auto_Patente LIKE '%" + txtFiltroPatente.Text.Trim() + "%' AND A.Auto_Habilitado = 1 " +
                    "GROUP BY A.Auto_Id,Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado,A.Auto_Habilitado ORDER BY A.Auto_Id DESC");
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
                        row["Habilitado"] = dr["habilitado"].ToString();

                        listaDePatentes.Add(dr["Auto_Patente"].ToString());

                        dtAutomoviles.Rows.Add(row);

                    }
                    dr.Close();

                    if (txtFiltroChofer.Text == "")
                    {//Si no filtra por chofer entonces muestros los que no tienen chofer
                        cmd = new SqlCommand(query2, conexion);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            DataRow row = dtAutomoviles.NewRow();
                            row["Id"] = dr["Auto_Id"].ToString();
                            row["Patente"] = dr["Auto_Patente"].ToString();
                            row["Marca"] = dr["Auto_Marca"].ToString();
                            row["Modelo"] = dr["Auto_Modelo"].ToString();
                            row["Licencia"] = dr["Auto_Licencia"].ToString();
                            row["Rodado"] = dr["Auto_Rodado"].ToString();
                            row["Chofer"] = "SIN CHOFER";
                            row["Habilitado"] = dr["habilitado"].ToString();

                            listaDePatentes.Add(dr["Auto_Patente"].ToString());

                            dtAutomoviles.Rows.Add(row);

                        }
                    }


                    dgvAutomovil.DataSource = dtAutomoviles;
                    dgvAutomovil.AutoResizeColumns();
                    dgvAutomovil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    btn_modificar.Visible = false;
                    dgvAutomovil.CurrentCell = dgvAutomovil.Rows[0].Cells[0];

                    if (checkVerInhabilitados.Checked)
                    {/// ver todos       
                        for (int i = 0; i < dgvAutomovil.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = dgvAutomovil.Rows[i];
                            if (row.Cells[7].Value.ToString() == "False")
                            {
                                row.DefaultCellStyle.BackColor = Color.LightSalmon;
                            }
                            else
                            {
                                row.DefaultCellStyle.BackColor = Color.LimeGreen;
                            }      
                        }
                    }
                    if (dgvAutomovil.CurrentRow.Cells[7].Value.ToString().Equals("True"))
                    {
                        btn_eliminar.Text = "Inhabilitar";
                    }
                    else
                    {
                        btn_eliminar.Text = "Habilitar";
                    }
                    if (dgvAutomovil.Rows.Count > 1){ btn_eliminar.Visible = true;}
                    else { btn_eliminar.Visible = false; }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            txtIdSeleccionado.Text = dgvAutomovil.CurrentRow.Cells[0].Value.ToString();
            txtPatente.Text = dgvAutomovil.CurrentRow.Cells[1].Value.ToString();
            comboMarca.Text = dgvAutomovil.CurrentRow.Cells[2].Value.ToString();
            txtModelo.Text = dgvAutomovil.CurrentRow.Cells[3].Value.ToString();
            txtLicencia.Text = dgvAutomovil.CurrentRow.Cells[4].Value.ToString();
            txtRodado.Text = dgvAutomovil.CurrentRow.Cells[5].Value.ToString();
            comboChofer.Text = dgvAutomovil.CurrentRow.Cells[6].Value.ToString();

            mostrarTurnosEnModificar();
            cargar_choferesEnModificar();
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
                //string query = String.Format("DELETE FROM [HAY_TABLA].[Automovil] WHERE Auto_Id =" + txtIdSeleccionado.Text);
                string query;

                if (dgvAutomovil.CurrentRow.Cells[7].Value.ToString().Equals("True"))
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
            //comboTurno.Items.Clear();
            comboMarca.SelectedItem = null;
            comboChofer.SelectedItem = null;
            //comboTurno.SelectedItem = null;
            //comboTurno.Items.Clear();
            //comboTurno.Enabled = false;

            mostrarTurnos();
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

            for (int i = listaTurnos.Items.Count - 1; i >= 0; i--)
            {
                listaTurnos.Items.RemoveAt(i);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listaTurnos.Items.Count; i++)
                listaTurnos.SetItemChecked(i, false); 
            
            txtPatente.Text = "";
            comboMarca.Text = "";
            txtModelo.Text = "";
            txtLicencia.Text = "";
            txtRodado.Text = "";
            comboMarca.SelectedItem = null;
            comboChofer.SelectedItem = null;

        }

        private void btn_guardar_modificar_Click(object sender, EventArgs e)
        {


            if (Validar(txtPatente.Text, comboMarca.Text, txtModelo.Text, txtLicencia.Text, txtRodado.Text, comboChofer.Text, listaTurnos.CheckedItems.Count) )
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string patentevieja = dgvAutomovil.CurrentRow.Cells[1].Value.ToString();

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
                        if (NoExiste(conexion, txtPatente.Text.Trim(), dgvAutomovil.CurrentRow.Cells[1].Value.ToString(), "Auto_Patente", "Patente", "Automovil", sqlTransact))
                        {

                            string queryidChoferviejo = String.Format("SELECT TOP 1 [Cho_Id] FROM [HAY_TABLA].[AsignacionDeTurnos] WHERE Auto_Id = " + txtIdSeleccionado.Text);
                            command5.CommandText = queryidChoferviejo;
                            Int32 idChoferV = (Int32)command5.ExecuteScalar();

                            KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)comboChofer.SelectedItem;

                            string query = "SELECT TOP 1 Au.Auto_Id,Au.Auto_Patente FROM[HAY_TABLA].[Automovil] Au JOIN [HAY_TABLA].[AsignacionDeTurnos] A ON Au.Auto_Id = A.Auto_Id WHERE A.Cho_Id = " + choferSeleccionado.Key.ToString();
                            SqlCommand cmd = new SqlCommand(query, conexion);
                            cmd.Transaction = sqlTransact;
                            SqlDataReader dr = cmd.ExecuteReader();
                            string patenteDelAutoActual = "";
                            while (dr.Read())
                            {
                                patenteDelAutoActual = dr["Auto_Patente"].ToString();
                            }
                            dr.Close();

                            if (patenteDelAutoActual != "" && choferSeleccionado.Key != idChoferV)
                            {
                                DialogResult dialogResult = MessageBox.Show("Los choferes no pueden tener mas de un auto asignado al mismo tiempo: El chofer '" + choferSeleccionado.Value + "' tiene asignado el auto con patente '" + patenteDelAutoActual + "', al asignarle el nuevo auto perdera la asignacion del actual.¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    //el auto del chofer nuevo queda huerfano
                                    query = String.Format("UPDATE [HAY_TABLA].[AsignacionDeTurnos] SET Cho_Id = 0 WHERE Cho_Id = " + choferSeleccionado.Key);
                                    command3.CommandText = query;
                                    command3.ExecuteNonQuery();

                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    return;
                                }
                            }

                            query = String.Format("UPDATE [HAY_TABLA].[Automovil] SET Auto_Patente='" + txtPatente.Text.Trim() + "',Auto_Marca='" + comboMarca.Text.Trim() + "',Auto_Modelo='" + txtModelo.Text.Trim() + "',Auto_Licencia='" + txtLicencia.Text.Trim() + "',Auto_Rodado='" + txtRodado.Text.Trim() + "' WHERE Auto_Id =" + txtIdSeleccionado.Text);
                            command.CommandText = query;
                            command.ExecuteNonQuery();

                            //borro todas las asignaciones que tenia el auto que estoy modificando, despues las voy a insertar con su nuevo chofer
                            query = String.Format("DELETE FROM [HAY_TABLA].[AsignacionDeTurnos] WHERE Auto_Id = " + txtIdSeleccionado.Text);
                            command3.CommandText = query;
                            command3.ExecuteNonQuery();

                            foreach (KeyValuePair<int, string> turno in listaTurnos.CheckedItems)
                            {
                                string query2 = String.Format("INSERT INTO [HAY_TABLA].[AsignacionDeTurnos] (Turno_Id, Cho_Id,Auto_Id) VALUES (" + turno.Key.ToString() + "," + choferSeleccionado.Key + "," + txtIdSeleccionado.Text + ")");
                                command2.CommandText = query2;
                                command2.ExecuteNonQuery();

                            }

                            sqlTransact.Commit();
                            MessageBox.Show("La modificacion de los datos se ha realizado exitosamente");
                            MostrarAutomoviles();
                            panelDatosSeleccionado.Visible = false;
                            panel1.Visible = true;
                            listaDeTurnos.Clear();
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

        public bool NoExiste(SqlConnection conexionAbierta, string dato, string datoActual, string nombreCampoEnTabla, string nombreDelDato, string nombreTabla, SqlTransaction sqlTransact)
        {
            if (dato == datoActual)
            {
                return true;
            }
            else
            {
                SqlCommand command = conexionAbierta.CreateCommand();
                command.Transaction = sqlTransact;
                string querycmd = String.Format("SELECT * FROM [HAY_TABLA].[" + nombreTabla + "] WHERE " + nombreCampoEnTabla + " = '" + dato +"'", conexionAbierta);
                command.CommandText = querycmd;
                SqlDataReader dr2 = command.ExecuteReader();
                try
                {
                    while (dr2.Read())
                    {
                        MessageBox.Show(nombreDelDato + "'" + dato + "' ya se encuentra registrado en el sistema");
                        return false;
                    }
                    dr2.Close();
                    return true;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
        }

        private bool Validar(string patente, string marca, string modelo, string licencia, string rodado, string chofer, int cantidadTurnos)
        {
            bool resultadoValidacion = true;
            resultadoValidacion = (Validador.validarStringVacio(patente, "Patente") && Validador.validarStringVacio(marca, "Marca") && Validador.validarStringVacio(modelo, "Modelo") && Validador.validarStringVacio(licencia, "Licencia") && Validador.validarStringVacio(rodado, "Rodado") && Validador.validarStringVacio(chofer, "Chofer") && (cantidadTurnos > 0));
            if (cantidadTurnos == 0)
            {
                MessageBox.Show("El automovil no tiene ningun turno asignado");
            }
            return resultadoValidacion;
        }

        private void dgvAutomovil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_modificar.Visible = true;
            txtIdSeleccionado.Text = dgvAutomovil.CurrentRow.Cells[0].Value.ToString();
            txtPatente.Text = dgvAutomovil.CurrentRow.Cells[1].Value.ToString();
            comboMarca.Text = dgvAutomovil.CurrentRow.Cells[2].Value.ToString();
            txtModelo.Text = dgvAutomovil.CurrentRow.Cells[3].Value.ToString();
            txtLicencia.Text = dgvAutomovil.CurrentRow.Cells[4].Value.ToString();
            txtRodado.Text = dgvAutomovil.CurrentRow.Cells[5].Value.ToString();
            comboChofer.Text = dgvAutomovil.CurrentRow.Cells[6].Value.ToString();
            if (dgvAutomovil.CurrentRow.Cells[7].Value.ToString().Equals("True"))
            {
                btn_eliminar.Text = "Inhabilitar";
                btn_modificar.Visible = true;
            }
            else
            {
                btn_modificar.Visible = false;
                btn_eliminar.Text = "Habilitar";
            }

        }

        private bool validarChoferSinAuto()
        {
            //    if (dato == datoActual)
            //   {
            //       return true;
            //  }
            // else
            //{

            KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)comboChofer.SelectedItem;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                try
                {
                    string query = "SELECT TOP 1 Au.Auto_Id,Au.Auto_Patente FROM[HAY_TABLA].[Automovil] Au JOIN [HAY_TABLA].[AsignacionDeTurnos] A ON Au.Auto_Id = A.Auto_Id WHERE A.Cho_Id = " + choferSeleccionado.Key.ToString();
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DialogResult dialogResult = MessageBox.Show("Los choferes no pueden tener mas de un auto asignado al mismo tiempo: El chofer '" + choferSeleccionado.Value + "' tiene asignado al auto con patente '" + dr["Auto_Patente"].ToString() + "'", "Advertencia", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            return true;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return false;
                        }
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
            //   }
        }

        private void btn_guardar_nuevo_Click(object sender, EventArgs e)
        {

            if (Validar(txtPatente.Text, comboMarca.Text, txtModelo.Text, txtLicencia.Text, txtRodado.Text, comboChofer.Text, listaTurnos.CheckedItems.Count))
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
                        if (NoExiste(conexion, txtPatente.Text.Trim(), "", "Auto_Patente", "Patente", "Automovil", sqlTransact))
                        {
                            KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)comboChofer.SelectedItem;
                            string query = "SELECT TOP 1 Au.Auto_Id,Au.Auto_Patente FROM[HAY_TABLA].[Automovil] Au JOIN [HAY_TABLA].[AsignacionDeTurnos] A ON Au.Auto_Id = A.Auto_Id WHERE A.Cho_Id = " + choferSeleccionado.Key.ToString();
                            SqlCommand cmd = new SqlCommand(query, conexion);
                            cmd.Transaction = sqlTransact;
                            SqlDataReader dr = cmd.ExecuteReader();
                            string patenteDelAutoActual = "";
                            while (dr.Read())
                            {
                                patenteDelAutoActual = dr["Auto_Patente"].ToString();
                            }
                            dr.Close();
                            if (patenteDelAutoActual != "")
                            {
                                DialogResult dialogResult = MessageBox.Show("Los choferes no pueden tener mas de un auto asignado al mismo tiempo: El chofer '" + choferSeleccionado.Value + "' tiene asignado el auto con patente '" + patenteDelAutoActual + "', al asignarle el nuevo auto perdera la asignacion del actual.¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    query = String.Format("UPDATE [HAY_TABLA].[AsignacionDeTurnos] SET Cho_Id = 0 WHERE Cho_Id = " + choferSeleccionado.Key.ToString());
                                    //query = String.Format("DELETE FROM [HAY_TABLA].[AsignacionDeTurnos] WHERE Cho_Id = " + choferSeleccionado.Key.ToString());
                                    command3.CommandText = query;
                                    command3.ExecuteNonQuery();

                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    return;
                                }
                            }


                            query = String.Format("INSERT INTO [HAY_TABLA].[Automovil] (Auto_Patente,Auto_Marca,Auto_Modelo,Auto_Licencia,Auto_Rodado) OUTPUT Inserted.Auto_Id VALUES (");
                            query += "'" + txtPatente.Text.Trim() + "','" + comboMarca.Text.Trim() + "','" + txtModelo.Text.Trim() + "','" + txtLicencia.Text.Trim() + "','" + txtRodado.Text.Trim() + "')";
                            command3.CommandText = query;
                            Int32 idAuto = (Int32)command3.ExecuteScalar();

                            foreach (KeyValuePair<int, string> turno in listaTurnos.CheckedItems)
                            {
                                string query2 = String.Format("INSERT INTO [HAY_TABLA].[AsignacionDeTurnos] (Turno_Id, Cho_Id,Auto_Id) VALUES (" + turno.Key.ToString() + "," + choferSeleccionado.Key + "," + idAuto + ")");
                                command2.CommandText = query2;
                                command2.ExecuteNonQuery();

                            }

                            sqlTransact.Commit();
                            MessageBox.Show("Se ha agregado un automovil exitosamente");
                            MostrarAutomoviles();
                            panelDatosSeleccionado.Visible = false;
                            panel1.Visible = true;
                            cargar_marcas();
                            cargar_choferes();
                            return;
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
                //string query = String.Format("SELECT  Cho_Nombre + ' ' + Cho_Apellido AS Nombre_y_Apellido_Chofer FROM [HAY_TABLA].[Chofer] c WHERE NOT EXISTS(SELECT * FROM [HAY_TABLA].[AsignacionDeTurnos] a WHERE A.Cho_Id = c.Cho_Id)");
                string query = String.Format("SELECT C.Cho_Id, Cho_Nombre + ' ' + Cho_Apellido AS Nombre_y_Apellido_Chofer FROM[HAY_TABLA].[Chofer] C JOIN[HAY_TABLA].[Usuarios] U ON CONVERT(varchar(30), C.Cho_DNI) = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] UR ON UR.Nombre_Usuario = U.Usu_Username WHERE UR.Id_Rol = 3 AND UR.Habilitado = 1");

                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboChofer.Items.Add(new KeyValuePair<int, string>((int)dr["Cho_Id"], dr["Nombre_y_Apellido_Chofer"].ToString()));

                    }

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargar_choferesEnModificar()
        {
            comboChofer.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                //  string query = String.Format("SELECT  Cho_Nombre + ' ' + Cho_Apellido AS Nombre_y_Apellido_Chofer FROM [HAY_TABLA].[Chofer] c WHERE Cho_Id = " + "(SELECT TOP 1 a.Cho_Id FROM [HAY_TABLA].[AsignacionDeTurnos] a WHERE a.Auto_Id = " + dgvAutomovil.CurrentRow.Cells[0].Value.ToString() + ") OR NOT EXISTS(SELECT * FROM [HAY_TABLA].[AsignacionDeTurnos] a WHERE A.Cho_Id = c.Cho_Id)");
                string query = String.Format("SELECT C.Cho_Id, Cho_Nombre + ' ' + Cho_Apellido AS Nombre_y_Apellido_Chofer FROM[HAY_TABLA].[Chofer] C JOIN[HAY_TABLA].[Usuarios] U ON CONVERT(varchar(30), C.Cho_DNI) = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] UR ON UR.Nombre_Usuario = U.Usu_Username WHERE UR.Id_Rol = 3 AND UR.Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboChofer.Items.Add(new KeyValuePair<int, string>((int)dr["Cho_Id"], dr["Nombre_y_Apellido_Chofer"].ToString()));
                    }
                    dr.Close();


                    query = String.Format("SELECT TOP 1 C.Cho_Id, Cho_Nombre + ' ' + Cho_Apellido AS Nombre_y_Apellido_Chofer FROM[HAY_TABLA].[Chofer] C JOIN [HAY_TABLA].[AsignacionDeTurnos] A ON C.Cho_Id = A.Cho_Id WHERE A.Auto_Id = " + txtIdSeleccionado.Text);
                    cmd = new SqlCommand(query, conexion);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboChofer.Text = new KeyValuePair<int, string>((int)dr["Cho_Id"], dr["Nombre_y_Apellido_Chofer"].ToString()).ToString();
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
            //labelNota.Visible = true;
        }



        private void checkVerInhabilitados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarAutomoviles();
        }

        private void mostrarTurnos()
        {
            listaKVPTurnos.Clear();
            listaKVPTurnosSeleccionados.Clear();
            listaTurnos.Items.Clear();
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT [Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion]FROM[HAY_TABLA].[Turno] WHERE Turno_Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                            listaKVPTurnos.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()));
                            listaTurnos.Items.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString()));
                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void mostrarTurnosEnModificar()
        {
            listaKVPTurnos.Clear();
            listaKVPTurnosSeleccionados.Clear();
            listaTurnos.Items.Clear();

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT Turno.[Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion] FROM[HAY_TABLA].[AsignacionDeTurnos] INNER JOIN[HAY_TABLA].Turno ON Turno.Turno_Id = AsignacionDeTurnos.Turno_Id WHERE AsignacionDeTurnos.Auto_Id = " + dgvAutomovil.CurrentRow.Cells[0].Value.ToString() + " AND Turno_Habilitado = 1");
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
                string query = String.Format("SELECT [Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion] FROM [HAY_TABLA].[Turno]  where Turno_Habilitado = 1");
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
                            if (listaKVPTurnosSeleccionados.Contains(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString())))
                            {
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
        private void soloLetrasYnumeros_noCaracteresEspeciales(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsWhiteSpace(e.KeyChar)))
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsNumber(e.KeyChar)))
                {
                    MessageBox.Show("No se permiten caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }

            }
        }

    }
}
