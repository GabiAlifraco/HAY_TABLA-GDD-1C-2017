﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UberFrba
{
    public class ValidacionesAbm
    {
        public DBAccess Access { get; set; }
        public ValidacionesAbm()
        {
            Access = new DBAccess();
        }


        public bool validarStringVacio(string unString, string nombreDelCampo)
        {
            if (unString.Length > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show(nombreDelCampo + " se encuentra vacio");
                return false;
            }
        }

        public bool validarFecha(string fecha)
        {
            DateTime value;
            if (!DateTime.TryParse(fecha, out value))
            {
                MessageBox.Show("La fecha de nacimiento no es valida");
                return false;
            }
            else
            {
                if (value.Year > 1753)
                {
                    DateTime hoy = new DateTime(Access.fechaAño(), Access.fechaMes(), Access.fechaDia());
                    if (hoy > value)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La fecha de nacimiento es mayor al la fecha actual");
                        return false;
                    }
                }
                else {
                    MessageBox.Show("La fecha de nacimiento no es valida");
                    return false;
                }
            }
        }

        public bool validarFechaCampo(string fecha, string nombreDelCampo)
        {
            DateTime value;
            if (!DateTime.TryParse(fecha, out value))
            {
                MessageBox.Show(nombreDelCampo + " no es valida");
                return false;
            }
            else
            {
                if (value.Year > 1753)
                {
                    DateTime hoy = new DateTime(Access.fechaAño(), Access.fechaMes(), Access.fechaDia());
                    if (hoy > value)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(nombreDelCampo + " es mayor al la fecha actual");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(nombreDelCampo + " no es valida");
                    return false;
                }
            }
        }

        public bool validarMail(string email)
        {
            if (email.Length > 0)
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(email);
                    return true;
                }
                catch
                {
                    MessageBox.Show("El mail no es valido");
                    return false;
                }
            }
            else { return true; }

        }
        public bool VerificarActivoRol(int id_rol)
        {
            bool activo = false;
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction sqlTransact = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = sqlTransact;
                try
                {
                    string query = String.Format("SELECT rol.Habilitado FROM [HAY_TABLA].[ROL] rol WHERE rol.Id_Rol=" + id_rol);
                    command.CommandText = query;
                    activo = (bool)command.ExecuteScalar();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        return activo;
        }

        public bool validarFecha(int dia, int mes, int año)
        {

            return true;

        }
    }
}
