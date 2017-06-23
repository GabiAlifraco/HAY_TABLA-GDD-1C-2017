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

namespace UberFrba.Abm_Turno
{
    public partial class AltaTurnos : Form
    {
        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }
        public AltaTurnos()
        {
            InitializeComponent();
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
        }

        private void btnCrearTurno_Click(object sender, EventArgs e)
        {
            decimal horaInicio = numericHoraInicio.Value * 100 + numericMinutoInicio.Value;
            decimal horaFin = numericHoraFin.Value * 100 + numericMinutoFin.Value;
            if (ValidarTurno(txtDescripcionTurno.Text, horaInicio, horaFin, numericPrecioBase.Value, numericValorKm.Value))
            {
                using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query = String.Format("INSERT INTO [HAY_TABLA].Turno (Turno_HoraInicio, Turno_HoraFin, Turno_Descripcion, Turno_ValorKM, Turno_PrecioBase) VALUES (" + horaInicio.ToString() + "," + horaFin.ToString() + ",'" + txtDescripcionTurno.Text + "'," + numericValorKm.Value.ToString().Replace(",", ".") + "," + numericPrecioBase.Value.ToString().Replace(",", ".") + ")");

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
                    string query = String.Format("SELECT [Turno_Descripcion],[Turno_HoraInicio],[Turno_HoraFin] FROM [HAY_TABLA].[Turno] WHERE ((" + horaInicio.ToString() + " BETWEEN Turno_HoraInicio AND Turno_HoraFin ) or (" + horaFin.ToString() + " BETWEEN Turno_HoraInicio AND Turno_HoraFin)) AND " + horaInicio.ToString() + " NOT IN (Turno_HoraInicio,Turno_HoraFin) AND " + horaFin.ToString() + " NOT IN (Turno_HoraInicio,Turno_HoraFin)");
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

    }
}