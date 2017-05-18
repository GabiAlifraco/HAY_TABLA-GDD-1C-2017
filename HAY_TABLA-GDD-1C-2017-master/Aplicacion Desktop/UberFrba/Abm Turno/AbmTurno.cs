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
        public AbmTurno()
        {
            InitializeComponent();
            Access = new DBAccess();
            MostrarTurnos();
            dateTimePickerHoraInicio.Format = DateTimePickerFormat.Time;
            dateTimePickerHoraInicio.ShowUpDown = true;
            dateTimePickerHoraFin.Format = DateTimePickerFormat.Time;
            dateTimePickerHoraFin.ShowUpDown = true;
        }

        private void AbmTurno_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdTurno.Text = dgvTurnos.CurrentRow.Cells[0].Value.ToString();
            txtDescripcionTurno.Text = dgvTurnos.CurrentRow.Cells[1].Value.ToString();
            dateTimePickerHoraInicio.Value = DateTime.Today.AddHours(Convert.ToInt64(dgvTurnos.CurrentRow.Cells[2].Value));
            dateTimePickerHoraFin.Value = DateTime.Today.AddHours(Convert.ToInt64(dgvTurnos.CurrentRow.Cells[3].Value));
            numericPrecioBase.Value = Convert.ToDecimal(dgvTurnos.CurrentRow.Cells[4].Value);
            numericValorKm.Value = Convert.ToDecimal(dgvTurnos.CurrentRow.Cells[5].Value);

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
            DataColumn cInicio = new DataColumn("Inicio");
            DataColumn cFin = new DataColumn("Fin");
            DataColumn cPrecioBase = new DataColumn("PrecioBase");
            DataColumn cValorKm = new DataColumn("ValorKm");

            dtTurnos.Columns.Add(cId);
            dtTurnos.Columns.Add(cDescripcion);
            dtTurnos.Columns.Add(cInicio);
            dtTurnos.Columns.Add(cFin);
            dtTurnos.Columns.Add(cPrecioBase);
            dtTurnos.Columns.Add(cValorKm);
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT * FROM[GD2017].[dbo].[Turno]");
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
                            row["Inicio"] = dr["Turno_HoraInicio"].ToString();
                            row["Fin"] = dr["Turno_HoraFin"].ToString();
                            row["PrecioBase"] = dr["Turno_PrecioBase"].ToString();
                            row["ValorKm"] = dr["Turno_ValorKm"].ToString();
                            dtTurnos.Rows.Add(row);
                        }
                    }
                    dgvTurnos.DataSource = dtTurnos;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarTurno()
        {
            if (txtDescripcionTurno.Text.Equals(""))
            {
                MessageBox.Show("La descripcion no puede quedar vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((dateTimePickerHoraFin.Value.Hour * 10000 + dateTimePickerHoraFin.Value.Minute * 100 + dateTimePickerHoraFin.Value.Second)
                <
                (dateTimePickerHoraInicio.Value.Hour * 10000 + dateTimePickerHoraInicio.Value.Minute * 100 + dateTimePickerHoraInicio.Value.Second))
            {
                MessageBox.Show("La hora de fin no puede ser menor a la hora de inicio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void btnVerTurnos_Click(object sender, EventArgs e)
        {
            
        }



        private void btnCrearTurno_Click(object sender, EventArgs e)
        {

            if (ValidarTurno())
            {
                Turno turnoNuevo = new Turno(txtDescripcionTurno.Text, dateTimePickerHoraInicio.Value, dateTimePickerHoraFin.Value, numericPrecioBase.Value, numericValorKm.Value);

                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("INSERT INTO Turno (Turno_HoraInicio, Turno_HoraFin, Turno_Descripcion, Turno_ValorKM, Turno_PrecioBase) VALUES (" + turnoNuevo.HoraInicio.Hour + "," + turnoNuevo.HoraFin.Hour + ",'" + turnoNuevo.Descripcion + "'," + turnoNuevo.ValorKm.ToString().Replace(",", ".") + "," + turnoNuevo.PrecioBase.ToString().Replace(",", ".") + ")");

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
                MostrarTurnos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("DELETE FROM Turno WHERE Turno_Id =" + dgvTurnos.CurrentRow.Cells[0].Value.ToString());
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
            MostrarTurnos();
        }

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
            if (ValidarTurno())
            {
                Turno turnoModificar = new Turno(txtDescripcionTurno.Text, dateTimePickerHoraInicio.Value, dateTimePickerHoraFin.Value, numericPrecioBase.Value, numericValorKm.Value);
                turnoModificar.Id = Convert.ToInt32(txtIdTurno.Text);
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("UPDATE Turno SET Turno_HoraInicio = " + turnoModificar.HoraInicio.Hour + ", Turno_HoraFin = " + turnoModificar.HoraFin.Hour + ", Turno_Descripcion = '" + turnoModificar.Descripcion + "', Turno_PrecioBase = " + turnoModificar.PrecioBase.ToString().Replace(",", ".") + ", Turno_ValorKM = " +  turnoModificar.ValorKm.ToString().Replace(",", ".") + " WHERE Turno_Id = " + turnoModificar.Id);
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
                MostrarTurnos();
            }
        }
    }
}
