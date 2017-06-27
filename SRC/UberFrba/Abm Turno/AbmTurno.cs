using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class AbmTurno : Form
    {

        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }
        public AbmTurno()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            if (checkVerInhabilitados.Checked == true)
            {
                MostrarTurnosInhabilitados();
            }
            else
            {
                MostrarTurnos();
                
            }
            panelDatosSeleccionado.Visible = false;
            dgvTurnos.ReadOnly = true;
        }

        private void AbmTurno_Load(object sender, EventArgs e)
        {

        }
      
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


 
        void MostrarTurnos()
        {
            DataTable dtTurnos = new DataTable("Turnos");

            DataColumn cId = new DataColumn("Id");
            DataColumn cDescripcion = new DataColumn("Descripcion");
            DataColumn cHInicio = new DataColumn("Hora Inicio");
            DataColumn cMnicio = new DataColumn("Min Inicio");
            DataColumn cHFin = new DataColumn("Hora Fin");
            DataColumn cMFin = new DataColumn("Min Fin");
            DataColumn cPrecioBase = new DataColumn("PrecioBase");
            DataColumn cValorKm = new DataColumn("ValorKm");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtTurnos.Columns.Add(cId);
            dtTurnos.Columns.Add(cDescripcion);
            dtTurnos.Columns.Add(cHInicio);
            dtTurnos.Columns.Add(cMnicio);
            dtTurnos.Columns.Add(cHFin);
            dtTurnos.Columns.Add(cMFin);
            dtTurnos.Columns.Add(cPrecioBase);
            dtTurnos.Columns.Add(cValorKm);
            dtTurnos.Columns.Add(cHabilitado);
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT * FROM [HAY_TABLA].[Turno] WHERE Turno_Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                            DataRow row = dtTurnos.NewRow();
                            row["Id"] = dr["Turno_Id"].ToString();
                            row["Descripcion"] = dr["Turno_Descripcion"].ToString();
                            decimal HoraInicio = (decimal)dr["Turno_HoraInicio"];
                            row["Hora Inicio"] = Math.Truncate(HoraInicio / 100);
                            row["Min Inicio"] = HoraInicio % 100;
                            decimal HoraFin = (decimal)dr["Turno_HoraFin"];
                            row["Hora Fin"] = Math.Truncate(HoraFin / 100);
                            row["Min Fin"] = HoraFin % 100;
                            row["PrecioBase"] = dr["Turno_PrecioBase"].ToString();
                            row["ValorKm"] = dr["Turno_ValorKm"].ToString();
                            row["Habilitado"] = dr["Turno_Habilitado"].ToString();
                            dtTurnos.Rows.Add(row);
                        }
                    }

                    dgvTurnos.DataSource = dtTurnos;
                    dgvTurnos.AutoResizeColumns();
                    dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        void MostrarTurnosInhabilitados()
        {
            DataTable dtTurnos = new DataTable("Turnos");

            DataColumn cId = new DataColumn("Id");
            DataColumn cDescripcion = new DataColumn("Descripcion");
            DataColumn cHInicio = new DataColumn("Hora Inicio");
            DataColumn cMnicio = new DataColumn("Min Inicio");
            DataColumn cHFin = new DataColumn("Hora Fin");
            DataColumn cMFin = new DataColumn("Min Fin");
            DataColumn cPrecioBase = new DataColumn("PrecioBase");
            DataColumn cValorKm = new DataColumn("ValorKm");
            DataColumn cHabilitado = new DataColumn("Habilitado");

            dtTurnos.Columns.Add(cId);
            dtTurnos.Columns.Add(cDescripcion);
            dtTurnos.Columns.Add(cHInicio);
            dtTurnos.Columns.Add(cMnicio);
            dtTurnos.Columns.Add(cHFin);
            dtTurnos.Columns.Add(cMFin);
            dtTurnos.Columns.Add(cPrecioBase);
            dtTurnos.Columns.Add(cValorKm);
            dtTurnos.Columns.Add(cHabilitado);
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT * FROM [HAY_TABLA].[Turno]");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                            DataRow row = dtTurnos.NewRow();
                            row["Id"] = dr["Turno_Id"].ToString();
                            row["Descripcion"] = dr["Turno_Descripcion"].ToString();
                            decimal HoraInicio = (decimal)dr["Turno_HoraInicio"];
                            row["Hora Inicio"] = Math.Truncate(HoraInicio / 100);
                            row["Min Inicio"] = HoraInicio % 100;
                            decimal HoraFin = (decimal)dr["Turno_HoraFin"];
                            row["Hora Fin"] = Math.Truncate(HoraFin / 100);
                            row["Min Fin"] = HoraFin % 100;
                            row["PrecioBase"] = dr["Turno_PrecioBase"].ToString();
                            row["ValorKm"] = dr["Turno_ValorKm"].ToString();
                            row["Habilitado"] = dr["Turno_Habilitado"].ToString();
                            dtTurnos.Rows.Add(row);
                        }
                    }
                    dgvTurnos.DataSource = dtTurnos;
                    dgvTurnos.AutoResizeColumns();
                    dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    for (int i = 0; i < dgvTurnos.Rows.Count - 1; i++)
                    {
                        DataGridViewRow row = dgvTurnos.Rows[i];
                        if (row.Cells[8].Value.ToString() == "False")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
     


                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnVerTurnos_Click(object sender, EventArgs e)
        {
            MostrarTurnosInhabilitados();
        }

        private void btnCrearTurno_Click(object sender, EventArgs e)
        {
            AltaTurnos formAltaTurno = new AltaTurnos();
            formAltaTurno.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("EXEC [HAY_TABLA].[bajaLogica] 'TURNO', " + dgvTurnos.CurrentRow.Cells[0].Value.ToString());   
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
            if (checkVerInhabilitados.Checked == true)
            {
                MostrarTurnosInhabilitados();
            }
            else
            {
                MostrarTurnos();
            }
            btnAltaLogica.Visible = false;
            btnModificarTurno.Visible = false;
        }

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
            panelDatosSeleccionado.Visible = true;
            panelDatosSeleccionado.Enabled = true;
            panelListaTurnos.Visible = false;
            btnModificarTurno.Visible = false;
            btnGuardarDatos.Visible = true;
    
        }

        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdTurno.Text = dgvTurnos.CurrentRow.Cells[0].Value.ToString();
            txtDescripcionTurno.Text = dgvTurnos.CurrentRow.Cells[1].Value.ToString();
            numericHoraInicio.Value = Convert.ToInt32(dgvTurnos.CurrentRow.Cells[2].Value);
            numericMinutoInicio.Value = Convert.ToInt32(dgvTurnos.CurrentRow.Cells[3].Value);
            numericHoraFin.Value = Convert.ToInt32(dgvTurnos.CurrentRow.Cells[4].Value);
            numericMinutoFin.Value = Convert.ToInt32(dgvTurnos.CurrentRow.Cells[5].Value);
            numericPrecioBase.Value = Convert.ToDecimal(dgvTurnos.CurrentRow.Cells[6].Value);
            numericValorKm.Value = Convert.ToDecimal(dgvTurnos.CurrentRow.Cells[7].Value);
            bool habilitado = Convert.ToBoolean(dgvTurnos.CurrentRow.Cells[8].Value);
            if (habilitado)
            {
                btnModificarTurno.Visible = true;
                btnAltaLogica.Visible = false;

            }
            else
            {
                btnModificarTurno.Visible = false;
                btnAltaLogica.Visible = true;
            }
            
            panelDatosSeleccionado.Enabled = false;
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

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {

            decimal horaInicio = numericHoraInicio.Value * 100 + numericMinutoInicio.Value;
            decimal horaFin = numericHoraFin.Value * 100 + numericMinutoFin.Value;
            if (ValidarTurno(txtDescripcionTurno.Text, horaInicio, horaFin, numericPrecioBase.Value, numericValorKm.Value))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("UPDATE [HAY_TABLA].Turno SET Turno_HoraInicio = " + horaInicio.ToString() + ", Turno_HoraFin = " + horaFin.ToString() + ", Turno_Descripcion = '" + txtDescripcionTurno.Text + "', Turno_PrecioBase = " + numericPrecioBase.Value.ToString().Replace(",", ".") + ", Turno_ValorKM = " + numericValorKm.Value.ToString().Replace(",", ".") + ",Turno_Habilitado = 1 "  + " WHERE Turno_Id = " + txtIdTurno.Text);
             
                    SqlCommand cmd = new SqlCommand(query, conexion);

                    try
                    {
                        conexion.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (checkVerInhabilitados.Checked == true)
                        {
                            MostrarTurnosInhabilitados();
                        }
                        else {
                            MostrarTurnos();
                        }
                        btnGuardarDatos.Visible = false;
                        btnAltaLogica.Visible = false;
                        btnModificarTurno.Visible = false;
                        panelListaTurnos.Visible = true;
                        panelDatosSeleccionado.Enabled = false;
                        panelDatosSeleccionado.Visible = false;

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private bool ValidarTurno(string descripcion, decimal horaInicio, decimal horaFin, decimal precioBase, decimal valorKm)
        {
            return (Validador.validarStringVacio(descripcion, "Descripcion") && ValidarHorario(horaInicio, horaFin));
        }

        private bool ValidarHorario(decimal horaInicio, decimal horaFin)
        {
            if (horaInicio > horaFin)
            {
                MessageBox.Show("La hora de inicio no puede ser mayor que la hora de fin de turno");
                return false;
            }
            else
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("SELECT [Turno_Id],[Turno_Descripcion],[Turno_HoraInicio],[Turno_HoraFin] FROM [HAY_TABLA].[Turno] WHERE ((" + (horaInicio + 1).ToString() + " BETWEEN Turno_HoraInicio AND Turno_HoraFin ) or (" + (horaFin - 1).ToString() + " BETWEEN Turno_HoraInicio AND Turno_HoraFin)) AND (" + horaInicio.ToString() + " != Turno_HoraInicio AND " + horaFin.ToString() + " !=Turno_HoraFin) AND Turno_Habilitado = 1");
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    try
                    {
                        conexion.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {                      
                            MessageBox.Show("El horario del nuevo turno se superpone con el del turno " + dr["Turno_Descripcion"].ToString());
                            return false;
                        }
                        return true;
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

      

        private void btnVerHabilitados_Click(object sender, EventArgs e)
        {
            MostrarTurnos();
        }

        private void checkVerInhabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVerInhabilitados.Checked == true)
            {
                MostrarTurnosInhabilitados();
            }
            else
            {
                MostrarTurnos();
            }
        }

        private void btnDescartarCambios_Click(object sender, EventArgs e)
        {
            btnGuardarDatos.Visible = false;
            btnModificarTurno.Visible = true;
            panelListaTurnos.Visible = true;
            panelDatosSeleccionado.Enabled = false;
            panelDatosSeleccionado.Visible = false;
        }

        private void btnAltaLogica_Click(object sender, EventArgs e)
        {
            decimal horaInicio = numericHoraInicio.Value * 100 + numericMinutoInicio.Value;
            decimal horaFin = numericHoraFin.Value * 100 + numericMinutoFin.Value;
            if (ValidarAltaLogica(horaInicio, horaFin))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("UPDATE [HAY_TABLA].Turno SET Turno_Habilitado = 1 " + " WHERE Turno_Id = " + txtIdTurno.Text);

                    SqlCommand cmd = new SqlCommand(query, conexion);

                    try
                    {
                        conexion.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (checkVerInhabilitados.Checked == true)
                        {
                            MostrarTurnosInhabilitados();
                        }
                        else
                        {
                            MostrarTurnos();
                        }
                        btnGuardarDatos.Visible = false;
                        btnModificarTurno.Visible = false;
                        btnAltaLogica.Visible = false;
                        panelListaTurnos.Visible = true;
                        panelDatosSeleccionado.Enabled = false;
                        panelDatosSeleccionado.Visible = false;

                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidarAltaLogica(decimal horaInicio, decimal horaFin)
        {
            if (horaInicio > horaFin)
            {
                MessageBox.Show("La hora de inicio no puede ser mayor que la hora de fin de turno");
                return false;
            }
            else
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("SELECT [Turno_Descripcion],[Turno_HoraInicio],[Turno_HoraFin] FROM [HAY_TABLA].[Turno] WHERE ((" + (horaInicio + 1).ToString() + " BETWEEN Turno_HoraInicio AND Turno_HoraFin ) or (" + (horaFin - 1).ToString() + " BETWEEN Turno_HoraInicio AND Turno_HoraFin)OR (" + horaInicio.ToString() + " = Turno_HoraInicio AND " + horaFin.ToString() + " =Turno_HoraFin)) AND Turno_Habilitado = 1");
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    try
                    {
                        conexion.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            MessageBox.Show("El horario del nuevo turno se superpone con el del turno " + dr["Turno_Descripcion"].ToString());
                            return false;
                        }
                        return true;
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
    }
}
