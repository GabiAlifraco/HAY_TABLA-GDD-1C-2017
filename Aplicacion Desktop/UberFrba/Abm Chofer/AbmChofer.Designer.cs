namespace UberFrba.Abm_Chofer
{
    partial class AbmChofer
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
            this.txtFiltroDNI = new System.Windows.Forms.TextBox();
            this.txtFiltroApellido = new System.Windows.Forms.TextBox();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChoferes = new System.Windows.Forms.DataGridView();
            this.panelDatosClienteSeleccionado = new System.Windows.Forms.Panel();
            this.txtChoferAltura = new System.Windows.Forms.TextBox();
            this.txtChoferDireccion = new System.Windows.Forms.TextBox();
            this.txtChoferTelefono = new System.Windows.Forms.TextBox();
            this.txtChoferDNI = new System.Windows.Forms.TextBox();
            this.txtChoferApellido = new System.Windows.Forms.TextBox();
            this.txtChoferNombre = new System.Windows.Forms.TextBox();
            this.btnDescartarCambios = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtIdSeleccionado = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnGuardarDatos = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtChoferMail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChoferNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarChofer = new System.Windows.Forms.Button();
            this.btnCrearCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).BeginInit();
            this.panelDatosClienteSeleccionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltroDNI
            // 
            this.txtFiltroDNI.Location = new System.Drawing.Point(244, 72);
            this.txtFiltroDNI.MaxLength = 10;
            this.txtFiltroDNI.Name = "txtFiltroDNI";
            this.txtFiltroDNI.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDNI.TabIndex = 73;
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(138, 72);
            this.txtFiltroApellido.MaxLength = 50;
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroApellido.TabIndex = 74;
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(32, 72);
            this.txtFiltroNombre.MaxLength = 50;
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 75;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(353, 69);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 77;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(244, 56);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 13);
            this.label32.TabIndex = 70;
            this.label32.Text = "DNI:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(138, 56);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 13);
            this.label31.TabIndex = 71;
            this.label31.Text = "Apellido:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(35, 56);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 13);
            this.label30.TabIndex = 76;
            this.label30.Text = "Nombre:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(36, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 13);
            this.label29.TabIndex = 72;
            this.label29.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-76, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Clientes";
            // 
            // dgvChoferes
            // 
            this.dgvChoferes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoferes.Location = new System.Drawing.Point(-77, 95);
            this.dgvChoferes.Name = "dgvChoferes";
            this.dgvChoferes.Size = new System.Drawing.Size(1034, 263);
            this.dgvChoferes.TabIndex = 68;
            // 
            // panelDatosClienteSeleccionado
            // 
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferAltura);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferDireccion);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferTelefono);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferDNI);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferApellido);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferNombre);
            this.panelDatosClienteSeleccionado.Controls.Add(this.btnDescartarCambios);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label27);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label26);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtIdSeleccionado);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label24);
            this.panelDatosClienteSeleccionado.Controls.Add(this.btnGuardarDatos);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label22);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferMail);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label9);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label7);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label6);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label5);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label4);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label3);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label2);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtChoferNacimiento);
            this.panelDatosClienteSeleccionado.Location = new System.Drawing.Point(12, 387);
            this.panelDatosClienteSeleccionado.Name = "panelDatosClienteSeleccionado";
            this.panelDatosClienteSeleccionado.Size = new System.Drawing.Size(318, 262);
            this.panelDatosClienteSeleccionado.TabIndex = 80;
            this.panelDatosClienteSeleccionado.Visible = false;
            // 
            // txtChoferAltura
            // 
            this.txtChoferAltura.Location = new System.Drawing.Point(118, 186);
            this.txtChoferAltura.MaxLength = 6;
            this.txtChoferAltura.Name = "txtChoferAltura";
            this.txtChoferAltura.Size = new System.Drawing.Size(48, 20);
            this.txtChoferAltura.TabIndex = 66;
            // 
            // txtChoferDireccion
            // 
            this.txtChoferDireccion.Location = new System.Drawing.Point(7, 186);
            this.txtChoferDireccion.MaxLength = 50;
            this.txtChoferDireccion.Name = "txtChoferDireccion";
            this.txtChoferDireccion.Size = new System.Drawing.Size(101, 20);
            this.txtChoferDireccion.TabIndex = 66;
            // 
            // txtChoferTelefono
            // 
            this.txtChoferTelefono.Location = new System.Drawing.Point(131, 117);
            this.txtChoferTelefono.MaxLength = 18;
            this.txtChoferTelefono.Name = "txtChoferTelefono";
            this.txtChoferTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtChoferTelefono.TabIndex = 66;
            // 
            // txtChoferDNI
            // 
            this.txtChoferDNI.Location = new System.Drawing.Point(131, 40);
            this.txtChoferDNI.MaxLength = 10;
            this.txtChoferDNI.Name = "txtChoferDNI";
            this.txtChoferDNI.Size = new System.Drawing.Size(100, 20);
            this.txtChoferDNI.TabIndex = 66;
            // 
            // txtChoferApellido
            // 
            this.txtChoferApellido.Location = new System.Drawing.Point(131, 78);
            this.txtChoferApellido.MaxLength = 50;
            this.txtChoferApellido.Name = "txtChoferApellido";
            this.txtChoferApellido.Size = new System.Drawing.Size(100, 20);
            this.txtChoferApellido.TabIndex = 66;
            // 
            // txtChoferNombre
            // 
            this.txtChoferNombre.Location = new System.Drawing.Point(8, 77);
            this.txtChoferNombre.MaxLength = 50;
            this.txtChoferNombre.Name = "txtChoferNombre";
            this.txtChoferNombre.Size = new System.Drawing.Size(100, 20);
            this.txtChoferNombre.TabIndex = 66;
            // 
            // btnDescartarCambios
            // 
            this.btnDescartarCambios.Location = new System.Drawing.Point(163, 212);
            this.btnDescartarCambios.Name = "btnDescartarCambios";
            this.btnDescartarCambios.Size = new System.Drawing.Size(139, 23);
            this.btnDescartarCambios.TabIndex = 62;
            this.btnDescartarCambios.Text = "DESCARTAR CAMBIOS";
            this.btnDescartarCambios.UseVisualStyleBackColor = true;
            this.btnDescartarCambios.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(137, 13);
            this.label27.TabIndex = 61;
            this.label27.Text = "CHOFER SELECCIONADO";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(16, 13);
            this.label26.TabIndex = 60;
            this.label26.Text = "Id";
            // 
            // txtIdSeleccionado
            // 
            this.txtIdSeleccionado.Enabled = false;
            this.txtIdSeleccionado.Location = new System.Drawing.Point(7, 40);
            this.txtIdSeleccionado.Name = "txtIdSeleccionado";
            this.txtIdSeleccionado.Size = new System.Drawing.Size(100, 20);
            this.txtIdSeleccionado.TabIndex = 59;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(115, 170);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 13);
            this.label24.TabIndex = 57;
            this.label24.Text = "Altura";
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.Location = new System.Drawing.Point(7, 212);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(139, 23);
            this.btnGuardarDatos.TabIndex = 27;
            this.btnGuardarDatos.Text = "GUARDAR CAMBIOS";
            this.btnGuardarDatos.UseVisualStyleBackColor = true;
            this.btnGuardarDatos.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 170);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Calle";
            // 
            // txtChoferMail
            // 
            this.txtChoferMail.Location = new System.Drawing.Point(7, 117);
            this.txtChoferMail.MaxLength = 50;
            this.txtChoferMail.Name = "txtChoferMail";
            this.txtChoferMail.Size = new System.Drawing.Size(101, 20);
            this.txtChoferMail.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Fecha Nacimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Direccion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre:";
            // 
            // txtChoferNacimiento
            // 
            this.txtChoferNacimiento.Location = new System.Drawing.Point(186, 186);
            this.txtChoferNacimiento.Mask = "00/00/0000";
            this.txtChoferNacimiento.Name = "txtChoferNacimiento";
            this.txtChoferNacimiento.Size = new System.Drawing.Size(62, 20);
            this.txtChoferNacimiento.TabIndex = 14;
            this.txtChoferNacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 364);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(139, 23);
            this.btnModificar.TabIndex = 79;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            // 
            // btnEliminarChofer
            // 
            this.btnEliminarChofer.Location = new System.Drawing.Point(158, 364);
            this.btnEliminarChofer.Name = "btnEliminarChofer";
            this.btnEliminarChofer.Size = new System.Drawing.Size(172, 23);
            this.btnEliminarChofer.TabIndex = 78;
            this.btnEliminarChofer.Text = "ELIMINAR SELECIONADO ";
            this.btnEliminarChofer.UseVisualStyleBackColor = true;
            this.btnEliminarChofer.Visible = false;
            // 
            // btnCrearCliente
            // 
            this.btnCrearCliente.Location = new System.Drawing.Point(336, 364);
            this.btnCrearCliente.Name = "btnCrearCliente";
            this.btnCrearCliente.Size = new System.Drawing.Size(172, 23);
            this.btnCrearCliente.TabIndex = 81;
            this.btnCrearCliente.Text = "CREAR CLIENTE";
            this.btnCrearCliente.UseVisualStyleBackColor = true;
            this.btnCrearCliente.Click += new System.EventHandler(this.btnCrearCliente_Click);
            // 
            // AbmChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 695);
            this.Controls.Add(this.btnCrearCliente);
            this.Controls.Add(this.panelDatosClienteSeleccionado);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminarChofer);
            this.Controls.Add(this.txtFiltroDNI);
            this.Controls.Add(this.txtFiltroApellido);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChoferes);
            this.Name = "AbmChofer";
            this.Text = "AbmChofer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).EndInit();
            this.panelDatosClienteSeleccionado.ResumeLayout(false);
            this.panelDatosClienteSeleccionado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroDNI;
        private System.Windows.Forms.TextBox txtFiltroApellido;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChoferes;
        private System.Windows.Forms.Panel panelDatosClienteSeleccionado;
        private System.Windows.Forms.TextBox txtChoferAltura;
        private System.Windows.Forms.TextBox txtChoferDireccion;
        private System.Windows.Forms.TextBox txtChoferTelefono;
        private System.Windows.Forms.TextBox txtChoferDNI;
        private System.Windows.Forms.TextBox txtChoferApellido;
        private System.Windows.Forms.TextBox txtChoferNombre;
        private System.Windows.Forms.Button btnDescartarCambios;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtIdSeleccionado;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnGuardarDatos;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtChoferMail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtChoferNacimiento;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarChofer;
        private System.Windows.Forms.Button btnCrearCliente;
    }
}