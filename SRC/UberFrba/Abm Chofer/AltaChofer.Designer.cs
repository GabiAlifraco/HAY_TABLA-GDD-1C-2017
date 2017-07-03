namespace UberFrba.Abm_Chofer
{
    partial class AltaChofer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaChofer));
            this.panelDatosNuevoCliente = new System.Windows.Forms.Panel();
            this.listaTurnos = new System.Windows.Forms.CheckedListBox();
            this.txtApellidoNuevo = new System.Windows.Forms.TextBox();
            this.txtNombreNuevo = new System.Windows.Forms.TextBox();
            this.txtAlturaNuevo = new System.Windows.Forms.TextBox();
            this.txtTelefonoNuevo = new System.Windows.Forms.TextBox();
            this.txtChoferDNINuevo = new System.Windows.Forms.TextBox();
            this.btnCancelarCrear = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDireccionNuevo = new System.Windows.Forms.TextBox();
            this.txtMailNuevo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNacimientoNuevo = new System.Windows.Forms.MaskedTextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.panelDatosNuevoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDatosNuevoCliente
            // 
            this.panelDatosNuevoCliente.BackColor = System.Drawing.Color.Transparent;
            this.panelDatosNuevoCliente.Controls.Add(this.listaTurnos);
            this.panelDatosNuevoCliente.Controls.Add(this.txtApellidoNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtNombreNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtAlturaNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtTelefonoNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtChoferDNINuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.btnCancelarCrear);
            this.panelDatosNuevoCliente.Controls.Add(this.label28);
            this.panelDatosNuevoCliente.Controls.Add(this.label25);
            this.panelDatosNuevoCliente.Controls.Add(this.label23);
            this.panelDatosNuevoCliente.Controls.Add(this.txtDireccionNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtMailNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.label14);
            this.panelDatosNuevoCliente.Controls.Add(this.label16);
            this.panelDatosNuevoCliente.Controls.Add(this.label17);
            this.panelDatosNuevoCliente.Controls.Add(this.label18);
            this.panelDatosNuevoCliente.Controls.Add(this.label19);
            this.panelDatosNuevoCliente.Controls.Add(this.label20);
            this.panelDatosNuevoCliente.Controls.Add(this.label21);
            this.panelDatosNuevoCliente.Controls.Add(this.txtNacimientoNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.btnCrear);
            this.panelDatosNuevoCliente.Location = new System.Drawing.Point(51, 12);
            this.panelDatosNuevoCliente.Name = "panelDatosNuevoCliente";
            this.panelDatosNuevoCliente.Size = new System.Drawing.Size(333, 404);
            this.panelDatosNuevoCliente.TabIndex = 64;
            // 
            // listaTurnos
            // 
            this.listaTurnos.FormattingEnabled = true;
            this.listaTurnos.Location = new System.Drawing.Point(23, 173);
            this.listaTurnos.Name = "listaTurnos";
            this.listaTurnos.Size = new System.Drawing.Size(208, 94);
            this.listaTurnos.TabIndex = 65;
            // 
            // txtApellidoNuevo
            // 
            this.txtApellidoNuevo.Location = new System.Drawing.Point(119, 40);
            this.txtApellidoNuevo.MaxLength = 50;
            this.txtApellidoNuevo.Name = "txtApellidoNuevo";
            this.txtApellidoNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoNuevo.TabIndex = 65;
            this.txtApellidoNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtNombreNuevo
            // 
            this.txtNombreNuevo.Location = new System.Drawing.Point(11, 40);
            this.txtNombreNuevo.MaxLength = 50;
            this.txtNombreNuevo.Name = "txtNombreNuevo";
            this.txtNombreNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtNombreNuevo.TabIndex = 0;
            this.txtNombreNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtAlturaNuevo
            // 
            this.txtAlturaNuevo.Location = new System.Drawing.Point(168, 131);
            this.txtAlturaNuevo.MaxLength = 6;
            this.txtAlturaNuevo.Name = "txtAlturaNuevo";
            this.txtAlturaNuevo.Size = new System.Drawing.Size(48, 20);
            this.txtAlturaNuevo.TabIndex = 64;
            this.txtAlturaNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtTelefonoNuevo
            // 
            this.txtTelefonoNuevo.Location = new System.Drawing.Point(119, 86);
            this.txtTelefonoNuevo.MaxLength = 10;
            this.txtTelefonoNuevo.Name = "txtTelefonoNuevo";
            this.txtTelefonoNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonoNuevo.TabIndex = 63;
            this.txtTelefonoNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtChoferDNINuevo
            // 
            this.txtChoferDNINuevo.Location = new System.Drawing.Point(222, 40);
            this.txtChoferDNINuevo.MaxLength = 8;
            this.txtChoferDNINuevo.Name = "txtChoferDNINuevo";
            this.txtChoferDNINuevo.Size = new System.Drawing.Size(100, 20);
            this.txtChoferDNINuevo.TabIndex = 61;
            this.txtChoferDNINuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // btnCancelarCrear
            // 
            this.btnCancelarCrear.Location = new System.Drawing.Point(130, 289);
            this.btnCancelarCrear.Name = "btnCancelarCrear";
            this.btnCancelarCrear.Size = new System.Drawing.Size(101, 23);
            this.btnCancelarCrear.TabIndex = 60;
            this.btnCancelarCrear.Text = "CANCELAR";
            this.btnCancelarCrear.UseVisualStyleBackColor = true;
            this.btnCancelarCrear.Click += new System.EventHandler(this.btnCancelarCrear_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.LemonChiffon;
            this.label28.Location = new System.Drawing.Point(8, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(92, 13);
            this.label28.TabIndex = 59;
            this.label28.Text = "CHOFER NUEVO";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.LemonChiffon;
            this.label25.Location = new System.Drawing.Point(165, 116);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 13);
            this.label25.TabIndex = 58;
            this.label25.Text = "Altura";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.LemonChiffon;
            this.label23.Location = new System.Drawing.Point(59, 116);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 56;
            this.label23.Text = "Calle";
            // 
            // txtDireccionNuevo
            // 
            this.txtDireccionNuevo.Location = new System.Drawing.Point(61, 131);
            this.txtDireccionNuevo.MaxLength = 50;
            this.txtDireccionNuevo.Name = "txtDireccionNuevo";
            this.txtDireccionNuevo.Size = new System.Drawing.Size(101, 20);
            this.txtDireccionNuevo.TabIndex = 51;
            // 
            // txtMailNuevo
            // 
            this.txtMailNuevo.Location = new System.Drawing.Point(12, 86);
            this.txtMailNuevo.MaxLength = 50;
            this.txtMailNuevo.Name = "txtMailNuevo";
            this.txtMailNuevo.Size = new System.Drawing.Size(101, 20);
            this.txtMailNuevo.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LemonChiffon;
            this.label14.Location = new System.Drawing.Point(220, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Fecha Nacimiento:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.LemonChiffon;
            this.label16.Location = new System.Drawing.Point(8, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Direccion:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LemonChiffon;
            this.label17.Location = new System.Drawing.Point(116, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Telefono:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.LemonChiffon;
            this.label18.Location = new System.Drawing.Point(10, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Mail:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.LemonChiffon;
            this.label19.Location = new System.Drawing.Point(221, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "DNI:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.LemonChiffon;
            this.label20.Location = new System.Drawing.Point(115, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Apellido:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.LemonChiffon;
            this.label21.Location = new System.Drawing.Point(8, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "Nombre:";
            // 
            // txtNacimientoNuevo
            // 
            this.txtNacimientoNuevo.Location = new System.Drawing.Point(222, 131);
            this.txtNacimientoNuevo.Mask = "00/00/0000";
            this.txtNacimientoNuevo.Name = "txtNacimientoNuevo";
            this.txtNacimientoNuevo.Size = new System.Drawing.Size(68, 20);
            this.txtNacimientoNuevo.TabIndex = 36;
            this.txtNacimientoNuevo.ValidatingType = typeof(System.DateTime);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(23, 289);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(101, 23);
            this.btnCrear.TabIndex = 28;
            this.btnCrear.Text = "CREAR";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // AltaChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(587, 444);
            this.Controls.Add(this.panelDatosNuevoCliente);
            this.MaximizeBox = false;
            this.Name = "AltaChofer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaChofer";
            this.panelDatosNuevoCliente.ResumeLayout(false);
            this.panelDatosNuevoCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDatosNuevoCliente;
        private System.Windows.Forms.TextBox txtApellidoNuevo;
        private System.Windows.Forms.TextBox txtNombreNuevo;
        private System.Windows.Forms.TextBox txtAlturaNuevo;
        private System.Windows.Forms.TextBox txtTelefonoNuevo;
        private System.Windows.Forms.TextBox txtChoferDNINuevo;
        private System.Windows.Forms.Button btnCancelarCrear;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDireccionNuevo;
        private System.Windows.Forms.TextBox txtMailNuevo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox txtNacimientoNuevo;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.CheckedListBox listaTurnos;
    }
}