using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public class DBAccess
    {
        public string Conexion { get; set; }

        public DBAccess()
        {
            Conexion = @"" + cadenaConexion() + "";
        }

        public string cadenaConexion()
        {
            string user = "";
            string pass = "";
            string dtSrc = "";
            string iniCtlg = "";
            StreamReader config = new StreamReader("../../configuracion.txt");
            string buffer = "";
            buffer = config.ReadLine();
            while (buffer != null)
            {
                if (buffer.Substring(0, 4) == "Data")
                {
                    dtSrc = buffer.Substring(13);
                }

                if (buffer.Substring(0, 4) == "Init")
                {
                    iniCtlg = buffer.Substring(17);
                }

                if (buffer.Substring(0, 4) == "User")
                {
                    user = buffer.Substring(9);
                }
                if (buffer.Substring(0, 4) == "Pass")
                {
                    pass = buffer.Substring(10);
                }
                buffer = config.ReadLine();
            }
            config.Close();
            return "Data Source=" + dtSrc + ";Initial Catalog=" + iniCtlg + ";User ID=" + user + ";Password=" + pass;
        }

        public string fechaCompleta()
        {
            string fecha;
            StreamReader config = new StreamReader("../../configuracion.txt");
            string buffer = "";
            buffer = config.ReadLine();
            fecha = buffer.Substring(7, 10);
            config.Close();
            return fecha;
        }

        public int fechaAño()
        {
            int fecha;
            StreamReader config = new StreamReader("../../configuracion.txt");
            string buffer = "";
            buffer = config.ReadLine();
            fecha = Int32.Parse(buffer.Substring(13, 4));
            config.Close();
            return fecha;
        }

        public int fechaMes()
        {
            int fecha;
            StreamReader config = new StreamReader("../../configuracion.txt");
            string buffer = "";
            buffer = config.ReadLine();
            fecha = Int32.Parse(buffer.Substring(10, 2));
            config.Close();
            return fecha;
        }

        public int fechaDia()
        {
            int fecha;
            StreamReader config = new StreamReader("../../configuracion.txt");
            string buffer = "";
            buffer = config.ReadLine();
            fecha = Int32.Parse(buffer.Substring(7, 2));
            config.Close();
            return fecha;
        }

    }
}
