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
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Facturacion;
using UberFrba.Listado_Estadistico;
using UberFrba.Registro_Viajes;
using UberFrba.Rendicion_Viajes;

namespace UberFrba.Menu
{
    public partial class MenuFuncionesDelRol : Form
    {
        public DBAccess Access { get; set; }
        public ValidacionesAbm Validador { get; set; }
        private string idUsuario = "";
        private int idRol;

        public MenuFuncionesDelRol(string idUser, int idRolUsuario)
        {
            InitializeComponent();
            idUsuario = idUser;
            idRol = idRolUsuario;
            Access = new DBAccess();
            Validador = new ValidacionesAbm();
            MostrarFunciones(idRol.ToString());
        }

        private void MostrarFunciones(string idRol)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {

                string query = String.Format("SELECT F.Descripcion, F.Id_Funcionalidad FROM[HAY_TABLA].[FUNCIONALIDAD_POR_ROL] FR INNER JOIN [HAY_TABLA].[FUNCIONALIDAD] AS F ON F.Id_Funcionalidad = FR.Id_Funcionalidad  WHERE FR.Id_Rol =" + idRol);
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBoxFunciones.Items.Add((dr["Descripcion"].ToString()));
                    }


                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void MenuFuncionesDelRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (listBoxFunciones.SelectedItem.ToString())
            {
                case "ABM de Cliente":
                    if (Validador.VerificarActivoRol(2))
                    {
                        AbmClientes formularioClientes = new AbmClientes();
                        formularioClientes.Show();
                    }
                    else
                    {
                        MessageBox.Show("El ROL CLIENTE esta INHABILITADO, por favor habilitelo desde la seccion ABM-ROL");
                    }
                    
                    break;
                case "ABM de Chofer":
                    if (Validador.VerificarActivoRol(3))
                    {
                        AbmChofer formularioChofer = new AbmChofer();
                        formularioChofer.Show();
                    }
                    else
                    {
                        MessageBox.Show("El ROL CHOFER esta INHABILITADO, por favor habilitelo desde la seccion ABM-ROL");
                    }
                    break;
                case "ABM de Automóvil":
                    AbmAutomovil formularioAutomovil = new AbmAutomovil();
                    formularioAutomovil.Show();
                    break;
                case "Abm Turno":
                    AbmTurno formTurnos = new AbmTurno();
                    formTurnos.Show();
                    break;
                case "ABM de Rol":
                    AbmRol formRoles = new AbmRol();
                    formRoles.Show();
                    break;
                case "Registro de Viajes":
                    if (Validador.VerificarActivoRol(2) && Validador.VerificarActivoRol(3))
                    {
                        AltaViajes formAltaViajes = new AltaViajes();
                        formAltaViajes.Show();
                    }
                    else if (!Validador.VerificarActivoRol(3))
                    {
                        MessageBox.Show("No se puede REGISTRAR UN VIAJE si el ROL CHOFER esta INHABILITADO, por favor habilitelo desde la seccion ABM-ROL");
                    }
                    else if (!Validador.VerificarActivoRol(2))
                    {
                        MessageBox.Show("No se puede REGISTRAR UN VIAJE si el ROL CLIENTE esta INHABILITADO, por favor habilitelo desde la seccion ABM-ROL");
                    }
                    break;
                    
                    
                case "Facturación a Cliente":
                    if (Validador.VerificarActivoRol(2))
                    {
                        frmFacturacion formFacutracion = new frmFacturacion();
                        formFacutracion.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la FACTURACION porque el ROL CLIENTE esta INHABILITADO, por favor habilitelo desde la seccion ABM-ROL");
                    }
                    
                    break;
                case "Rendición de cuenta del chofer":
                    if (Validador.VerificarActivoRol(3))
                    {
                        frmRendicion formRendicion = new frmRendicion();
                        formRendicion.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la RENDICION porque el ROL CHOFER esta INHABILITADO, por favor habilitelo desde la seccion ABM-ROL");
                    }
                    break;
                case "Listado Estadístico":
                    ListadoEstadistico formListadoEstadistico = new ListadoEstadistico();
                    formListadoEstadistico.Show();
                    break;
                case "Ver Viajes":
                    VerViajes formVerViajes = new VerViajes(idUsuario, idRol);
                    formVerViajes.Show();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
    }
}
