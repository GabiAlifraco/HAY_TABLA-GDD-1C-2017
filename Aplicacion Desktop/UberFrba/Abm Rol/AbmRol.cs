using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class AbmRol : Form
    {
        public AbmRol()
        {
            InitializeComponent();
        }

        private void btnAltaDeRol_Click(object sender, EventArgs e)
        {
            AltaDeRol formAltaDeRol = new AltaDeRol();
            formAltaDeRol.Show();
        }
    }
}
