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

namespace UberFrba.Registro_Viajes
{
    
    public partial class AltaViajes : Form
    {
        public decimal valorDelKm = 0;
        public decimal precioBase = 0;
        public ValidacionesAbm Validador { get; set; }
        public DBAccess Access { get; set; }
        public AltaViajes()
        {
            InitializeComponent();

            Access = new DBAccess();
            cargarChoferes();
            cargarClientes();
            Validador = new ValidacionesAbm();
        }

        private void cargarChoferes() {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

                
                string query = String.Format("SELECT* FROM[HAY_TABLA].[Chofer] C JOIN[HAY_TABLA].[Usuarios] U ON CONVERT(varchar(30), C.Cho_DNI) = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] UR ON UR.Nombre_Usuario = U.Usu_Username WHERE UR.Id_Rol = 3 AND UR.Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBoxChoferes.Items.Add(new KeyValuePair<int, string>((int)dr["Cho_Id"], dr["Cho_Nombre"].ToString() + " " + dr["Cho_Apellido"].ToString()));
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cargarClientes()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT* FROM[HAY_TABLA].[Cliente] C JOIN[HAY_TABLA].[Usuarios] U ON CONVERT(varchar(30), C.Cli_DNI) = U.Usu_Username JOIN[HAY_TABLA].[USUARIO_POR_ROL] UR ON UR.Nombre_Usuario = U.Usu_Username WHERE UR.Id_Rol = 2 AND UR.Habilitado = 1");
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBoxCliente.Items.Add(new KeyValuePair<int, string>((int)dr["Cli_Id"], dr["CLI_Nombre"].ToString() + " " + dr["Cli_Apellido"].ToString()));
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTurnosDelChofer();
        }

        void cargarTurnosDelChofer() {
            listBoxTurnos.Items.Clear();
            txtAuto.Text = "";
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                string query = String.Format("SELECT Turno.[Turno_Id],[Turno_HoraInicio],[Turno_HoraFin],[Turno_Descripcion] FROM[HAY_TABLA].[AsignacionDeTurnos] INNER JOIN[HAY_TABLA].Turno ON Turno.Turno_Id = AsignacionDeTurnos.Turno_Id WHERE Turno_Habilitado = 1 AND AsignacionDeTurnos.Cho_Id = " + choferSeleccionado.Key.ToString());
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr["Turno_Descripcion"].ToString() != "")
                        {
                          
                            decimal HoraInicio = (decimal)dr["Turno_HoraInicio"];
                            decimal HInicio = Math.Truncate(HoraInicio / 100);
                            string Minicio = (HoraInicio % 100).ToString();
                            decimal HoraFin = (decimal)dr["Turno_HoraFin"];
                            decimal HFin = Math.Truncate(HoraFin / 100);
                            string MFin = (HoraFin % 100).ToString();

                            if (Minicio.Length == 1) { Minicio = "0" + Minicio; }
                            if (MFin.Length == 1) { MFin = "0" + MFin; }

                            listBoxTurnos.Items.Add(new KeyValuePair<int, string>((int)dr["Turno_Id"], dr["Turno_Descripcion"].ToString() + " " + HInicio.ToString() + ":" + Minicio.ToString() + " a " + HFin.ToString() + ":" + MFin.ToString()));

                        }
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAutoDelChoferEnEseTurno();
        }

        void CargarAutoDelChoferEnEseTurno()
        {
            txtAuto.Text = "";
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                KeyValuePair<int, string> turnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;
                //
                string query = String.Format("SELECT [Auto_Patente] FROM [HAY_TABLA].[AsignacionDeTurnos] INNER JOIN[HAY_TABLA].Automovil ON Automovil.Auto_Id = AsignacionDeTurnos.Auto_Id WHERE AsignacionDeTurnos.Cho_Id = " + choferSeleccionado.Key.ToString() + "AND Auto_Habilitado = 1 AND AsignacionDeTurnos.Turno_Id =" + turnoSeleccionado.Key.ToString());
                SqlCommand cmd2 = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        txtAuto.Text = dr["Auto_Patente"].ToString();
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (NoHayCamposVacios() && Validador.validarFechaCampo(txtFyHinicio.Text, "La fecha de inicio") && Validador.validarFechaCampo(txtFyHfin.Text, "La fecha de fin"))
            {// Si no hay campos vacios
                DateTime Finicio;
                DateTime.TryParse(txtFyHinicio.Text, out Finicio);
                DateTime Ffin;
                DateTime.TryParse(txtFyHfin.Text, out Ffin);
                if (ValidarViaje(Finicio, Ffin)) {
                    //Guardo el viaje bien piola
                    using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                    {
                        conexion.Open();
                        SqlTransaction sqlTransact = conexion.BeginTransaction();
                        SqlCommand command = conexion.CreateCommand();
                        command.Transaction = sqlTransact;
                        try
                        {
                            KeyValuePair<int, string> choferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                            KeyValuePair<int, string> turnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;
                            KeyValuePair<int, string> clienteSeleccionado = (KeyValuePair<int, string>)listBoxCliente.SelectedItem;
                            string query = String.Format("INSERT INTO [HAY_TABLA].Viaje (Vi_IdChofer, Vi_IdCliente,Vi_AutoPatente, Vi_IdTurno,Vi_CantKilometros,Vi_Inicio,Vi_Fin,Vi_ImporteTotal) VALUES (@IdChofer, @IdCliente,@AutoPatente, @IdTurno,@CantKilometros,@Inicio,@Fin,@ImporteTotal)");
                           
                            command.CommandText = query;

                            SqlParameter param = new SqlParameter("@IdChofer", choferSeleccionado.Key.ToString());
                            param.SqlDbType = System.Data.SqlDbType.Int;
                            command.Parameters.Add(param);

                            param = new SqlParameter("@IdCliente", clienteSeleccionado.Key.ToString());
                            param.SqlDbType = System.Data.SqlDbType.Int;
                            command.Parameters.Add(param);

                            param = new SqlParameter("@AutoPatente", txtAuto.Text);
                            param.SqlDbType = System.Data.SqlDbType.VarChar;
                            command.Parameters.Add(param);

                            param = new SqlParameter("@IdTurno", turnoSeleccionado.Key.ToString());
                            param.SqlDbType = System.Data.SqlDbType.VarChar;
                            command.Parameters.Add(param);

                            param = new SqlParameter("@CantKilometros", txtCantidadKm.Text);
                            param.SqlDbType = System.Data.SqlDbType.Int;
                            command.Parameters.Add(param);
                            
                            param = new SqlParameter("@Inicio", DateTime.Parse(txtFyHinicio.Text));
                            param.SqlDbType = System.Data.SqlDbType.DateTime;
                            command.Parameters.Add(param);


                            param = new SqlParameter("@Fin", DateTime.Parse(txtFyHfin.Text));
                            param.SqlDbType = System.Data.SqlDbType.DateTime;
                            command.Parameters.Add(param);

                            decimal importe = precioBase + valorDelKm * Convert.ToInt64(txtCantidadKm.Text);
                            param = new SqlParameter("@ImporteTotal", importe);
                            param.SqlDbType = System.Data.SqlDbType.Decimal;
                            command.Parameters.Add(param);
                          
                            command.ExecuteNonQuery();
                            sqlTransact.Commit();
                            MessageBox.Show("El viaje fue registrado con exito");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error");
                            sqlTransact.Rollback();
                        }

                    }
                }

            }
        }



        public bool ValidarViaje(DateTime Finicio, DateTime Ffinal) {
            return (ValidarInicioFin(Finicio,  Ffinal) && ValidarHorarioDentroDelTurno(Finicio) && ValidarChoferNoRealizoOtroVieajeEnEseMomento(Finicio, Ffinal) && ValidarClienteNoRealizoOtroVieajeEnEseMomento(Finicio, Ffinal));
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


        private bool ValidarHorarioDentroDelTurno(DateTime inicio) {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                KeyValuePair<int, string> TurnoSeleccionado = (KeyValuePair<int, string>)listBoxTurnos.SelectedItem;
                string query = String.Format("SELECT * FROM [HAY_TABLA].[Turno] WHERE Turno_Id =" + TurnoSeleccionado.Key.ToString());
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        valorDelKm = (decimal)dr["Turno_ValorKM"];
                        precioBase = (decimal)dr["Turno_PrecioBase"];
                        decimal HoraInicioTurno = (decimal)dr["Turno_HoraInicio"];
                        decimal HoraFinTurno = (decimal)dr["Turno_HoraFin"];
                        if (HoraInicioTurno < 25)
                        {
                            HoraInicioTurno = HoraInicioTurno * 100;
                        }
                        if (HoraFinTurno < 25)
                        {
                            HoraFinTurno = HoraFinTurno * 100;
                        }
                        decimal HoraInicioViaje = inicio.Hour * 100 + inicio.Minute;
                        if (HoraInicioTurno <= HoraInicioViaje) {
                            if (HoraFinTurno > HoraInicioViaje)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("La hora de fin del viaje no esta dentro del horario del turno");
                                return false;
                            }
                        }else
                        {
                            MessageBox.Show("La hora de inicio del viaje no esta dentro del horario del turno");
                            return false;
                        }
                    }
                    MessageBox.Show("Ha ocurrido un error");
                    return false;
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        }

        private bool ValidarChoferNoRealizoOtroVieajeEnEseMomento(DateTime inicio, DateTime final) {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {

                    string fechaInicio = inicio.Year.ToString() + "-" + inicio.Month.ToString() + "-" + inicio.Day.ToString() + " " + inicio.Hour.ToString() + ":" + inicio.Minute.ToString();
                    string fechaFin = final.Year.ToString() + "-" + final.Month.ToString() + "-" + final.Day.ToString() + " " + final.Hour.ToString() + ":" + final.Minute.ToString();
                    //string fechaFin = inicio.Date.ToString("yyyy-MM-dd HH:mm");
                    KeyValuePair<int, string> ChoferSeleccionado = (KeyValuePair<int, string>)listBoxChoferes.SelectedItem;
                    string query = "SELECT count(*) FROM HAY_TABLA.Viaje V WHERE Vi_IdChofer = " + ChoferSeleccionado.Key;
                    query += " AND ((Vi_Inicio BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "') OR  (Vi_Fin BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "')";
                    query += " OR ('" + fechaInicio + "' BETWEEN Vi_Inicio AND Vi_Fin) OR ('" + fechaFin + "' BETWEEN Vi_Inicio AND Vi_Fin))";

                    command.CommandText = query;

                    int cantFilas = (int)command.ExecuteScalar();
                    if (cantFilas > 0) {
                        MessageBox.Show("El viaje que se quiere crear se superpone con un viaje realizado por el chofer");
                        return false;
                    }else
                    {
                        return true;
                    }
                 
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private bool ValidarClienteNoRealizoOtroVieajeEnEseMomento(DateTime inicio, DateTime fin) {

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {

                    string fechaInicio = inicio.Year.ToString() + "-" + inicio.Month.ToString() + "-" + inicio.Day.ToString() + " " + inicio.Hour.ToString() + ":" + inicio.Minute.ToString();
                    string fechaFin = fin.Year.ToString() + "-" + fin.Month.ToString() + "-" + fin.Day.ToString() + " " + fin.Hour.ToString() + ":" + fin.Minute.ToString();
                    //string fechaFin = inicio.Date.ToString("yyyy-MM-dd HH:mm");
                    KeyValuePair<int, string> ClienteSeleccionado = (KeyValuePair<int, string>)listBoxCliente.SelectedItem;
                    string query = "SELECT count(*) FROM HAY_TABLA.Viaje V WHERE Vi_IdCliente = " + ClienteSeleccionado.Key.ToString();
                    query += " AND ((Vi_Inicio BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "') OR  (Vi_Fin BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "')";
                    query += " OR ('" + fechaInicio + "' BETWEEN Vi_Inicio AND Vi_Fin) OR ('" + fechaFin + "' BETWEEN Vi_Inicio AND Vi_Fin))";

                    command.CommandText = query;

                    int cantFilas = (int)command.ExecuteScalar();
                    if (cantFilas > 0)
                    {
                        MessageBox.Show("El viaje que se quiere crear se superpone con un viaje realizado por el cliente");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private bool NoHayCamposVacios()
        {
            if (listBoxChoferes.SelectedIndex != -1) {
                if (listBoxTurnos.SelectedIndex != -1)
                {
                    if (listBoxCliente.SelectedIndex != -1)
                    {
                        if (Validador.validarStringVacio(txtCantidadKm.Text, "Cantidad de kilometros"))
                        {
                            if (txtAuto.Text != "")
                            {
                                return true;
                            }
                            else {
                                MessageBox.Show("El chofer no posee un automovil habilitado para realizar el viaje");
                            }
                        }
                    }else
                    {
                        MessageBox.Show("Debe seleccionar un cliente");
                        return false;
                    }
                }
                else{
                    MessageBox.Show("Debe seleccionar un turno");
                    return false;
                }
            }else{
                    MessageBox.Show("Debe seleccionar un chofer");
                    return false;
            }
            return false;
         
            
        }

        private bool ValidarInicioFin(DateTime inicio, DateTime final){
            if(inicio >= final){
                MessageBox.Show("La fecha y hora de fin del viaje debe ser mayor que la de inicio");
                return false;
            }else{
                return true;
            }
        }

    }
}
