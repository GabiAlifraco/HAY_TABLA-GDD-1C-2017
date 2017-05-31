namespace UberFrba.Abm_Cliente
{
    partial class AbmClientes
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearCliente = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtClienteNacimientoNuevo = new System.Windows.Forms.MaskedTextBox();
            this.txtClienteMailNuevo = new System.Windows.Forms.TextBox();
            this.txtClienteDireccionNuevo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.panelDatosNuevoCliente = new System.Windows.Forms.Panel();
            this.txtClienteApellidoNuevo = new System.Windows.Forms.TextBox();
            this.txtClienteNombreNuevo = new System.Windows.Forms.TextBox();
            this.txtClienteAlturaNuevo = new System.Windows.Forms.TextBox();
            this.txtClienteTelefonoNuevo = new System.Windows.Forms.TextBox();
            this.txtClienteCodigoPostalNuevo = new System.Windows.Forms.TextBox();
            this.txtClienteDNINuevo = new System.Windows.Forms.TextBox();
            this.btnCancelarCrear = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.txtFiltroApellido = new System.Windows.Forms.TextBox();
            this.txtFiltroDNI = new System.Windows.Forms.TextBox();
            this.txtClienteNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClienteMail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnGuardarDatos = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtIdSeleccionado = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnDescartarCambios = new System.Windows.Forms.Button();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.txtClienteApellido = new System.Windows.Forms.TextBox();
            this.txtClienteDNI = new System.Windows.Forms.TextBox();
            this.txtClienteTelefono = new System.Windows.Forms.TextBox();
            this.txtClienteCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtClienteDireccion = new System.Windows.Forms.TextBox();
            this.txtClienteAltura = new System.Windows.Forms.TextBox();
            this.panelDatosClienteSeleccionado = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.panelDatosNuevoCliente.SuspendLayout();
            this.panelDatosClienteSeleccionado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(12, 77);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(1034, 263);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clientes";
            // 
            // btnCrearCliente
            // 
            this.btnCrearCliente.Location = new System.Drawing.Point(461, 346);
            this.btnCrearCliente.Name = "btnCrearCliente";
            this.btnCrearCliente.Size = new System.Drawing.Size(172, 23);
            this.btnCrearCliente.TabIndex = 7;
            this.btnCrearCliente.Text = "CREAR CLIENTE";
            this.btnCrearCliente.UseVisualStyleBackColor = true;
            this.btnCrearCliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(26, 160);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(101, 23);
            this.btnCrear.TabIndex = 28;
            this.btnCrear.Text = "CREAR";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Fecha Nacimiento:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(221, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "Codigo postal:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Direccion:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(116, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Telefono:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Mail:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(221, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "DNI:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(115, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Apellido:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "Nombre:";
            // 
            // txtClienteNacimientoNuevo
            // 
            this.txtClienteNacimientoNuevo.Location = new System.Drawing.Point(222, 131);
            this.txtClienteNacimientoNuevo.Mask = "00/00/0000";
            this.txtClienteNacimientoNuevo.Name = "txtClienteNacimientoNuevo";
            this.txtClienteNacimientoNuevo.Size = new System.Drawing.Size(68, 20);
            this.txtClienteNacimientoNuevo.TabIndex = 36;
            this.txtClienteNacimientoNuevo.ValidatingType = typeof(System.DateTime);
            // 
            // txtClienteMailNuevo
            // 
            this.txtClienteMailNuevo.Location = new System.Drawing.Point(12, 86);
            this.txtClienteMailNuevo.MaxLength = 50;
            this.txtClienteMailNuevo.Name = "txtClienteMailNuevo";
            this.txtClienteMailNuevo.Size = new System.Drawing.Size(101, 20);
            this.txtClienteMailNuevo.TabIndex = 50;
            // 
            // txtClienteDireccionNuevo
            // 
            this.txtClienteDireccionNuevo.Location = new System.Drawing.Point(61, 131);
            this.txtClienteDireccionNuevo.MaxLength = 50;
            this.txtClienteDireccionNuevo.Name = "txtClienteDireccionNuevo";
            this.txtClienteDireccionNuevo.Size = new System.Drawing.Size(101, 20);
            this.txtClienteDireccionNuevo.TabIndex = 51;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(59, 116);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 56;
            this.label23.Text = "Calle";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(165, 116);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 13);
            this.label25.TabIndex = 58;
            this.label25.Text = "Altura";
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Location = new System.Drawing.Point(158, 346);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(172, 23);
            this.btnEliminarCliente.TabIndex = 61;
            this.btnEliminarCliente.Text = "ELIMINAR SELECIONADO ";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Visible = false;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(12, 346);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(139, 23);
            this.btnModificar.TabIndex = 62;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // panelDatosNuevoCliente
            // 
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteApellidoNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteNombreNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteAlturaNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteTelefonoNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteCodigoPostalNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteDNINuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.btnCancelarCrear);
            this.panelDatosNuevoCliente.Controls.Add(this.label28);
            this.panelDatosNuevoCliente.Controls.Add(this.label25);
            this.panelDatosNuevoCliente.Controls.Add(this.label23);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteDireccionNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteMailNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.label14);
            this.panelDatosNuevoCliente.Controls.Add(this.label15);
            this.panelDatosNuevoCliente.Controls.Add(this.label16);
            this.panelDatosNuevoCliente.Controls.Add(this.label17);
            this.panelDatosNuevoCliente.Controls.Add(this.label18);
            this.panelDatosNuevoCliente.Controls.Add(this.label19);
            this.panelDatosNuevoCliente.Controls.Add(this.label20);
            this.panelDatosNuevoCliente.Controls.Add(this.label21);
            this.panelDatosNuevoCliente.Controls.Add(this.txtClienteNacimientoNuevo);
            this.panelDatosNuevoCliente.Controls.Add(this.btnCrear);
            this.panelDatosNuevoCliente.Location = new System.Drawing.Point(370, 369);
            this.panelDatosNuevoCliente.Name = "panelDatosNuevoCliente";
            this.panelDatosNuevoCliente.Size = new System.Drawing.Size(356, 292);
            this.panelDatosNuevoCliente.TabIndex = 63;
            this.panelDatosNuevoCliente.Visible = false;
            // 
            // txtClienteApellidoNuevo
            // 
            this.txtClienteApellidoNuevo.Location = new System.Drawing.Point(119, 40);
            this.txtClienteApellidoNuevo.MaxLength = 50;
            this.txtClienteApellidoNuevo.Name = "txtClienteApellidoNuevo";
            this.txtClienteApellidoNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtClienteApellidoNuevo.TabIndex = 65;
            this.txtClienteApellidoNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtClienteNombreNuevo
            // 
            this.txtClienteNombreNuevo.Location = new System.Drawing.Point(11, 40);
            this.txtClienteNombreNuevo.MaxLength = 50;
            this.txtClienteNombreNuevo.Name = "txtClienteNombreNuevo";
            this.txtClienteNombreNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtClienteNombreNuevo.TabIndex = 0;
            this.txtClienteNombreNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtClienteAlturaNuevo
            // 
            this.txtClienteAlturaNuevo.Location = new System.Drawing.Point(168, 131);
            this.txtClienteAlturaNuevo.MaxLength = 6;
            this.txtClienteAlturaNuevo.Name = "txtClienteAlturaNuevo";
            this.txtClienteAlturaNuevo.Size = new System.Drawing.Size(48, 20);
            this.txtClienteAlturaNuevo.TabIndex = 64;
            this.txtClienteAlturaNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteTelefonoNuevo
            // 
            this.txtClienteTelefonoNuevo.Location = new System.Drawing.Point(119, 86);
            this.txtClienteTelefonoNuevo.MaxLength = 18;
            this.txtClienteTelefonoNuevo.Name = "txtClienteTelefonoNuevo";
            this.txtClienteTelefonoNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtClienteTelefonoNuevo.TabIndex = 63;
            this.txtClienteTelefonoNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteCodigoPostalNuevo
            // 
            this.txtClienteCodigoPostalNuevo.Location = new System.Drawing.Point(223, 86);
            this.txtClienteCodigoPostalNuevo.MaxLength = 10;
            this.txtClienteCodigoPostalNuevo.Name = "txtClienteCodigoPostalNuevo";
            this.txtClienteCodigoPostalNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtClienteCodigoPostalNuevo.TabIndex = 62;
            this.txtClienteCodigoPostalNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteDNINuevo
            // 
            this.txtClienteDNINuevo.Location = new System.Drawing.Point(222, 40);
            this.txtClienteDNINuevo.MaxLength = 10;
            this.txtClienteDNINuevo.Name = "txtClienteDNINuevo";
            this.txtClienteDNINuevo.Size = new System.Drawing.Size(100, 20);
            this.txtClienteDNINuevo.TabIndex = 61;
            this.txtClienteDNINuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // btnCancelarCrear
            // 
            this.btnCancelarCrear.Location = new System.Drawing.Point(149, 160);
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
            this.label28.Location = new System.Drawing.Point(8, 11);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(93, 13);
            this.label28.TabIndex = 59;
            this.label28.Text = "CLIENTE NUEVO";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(125, 14);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 13);
            this.label29.TabIndex = 65;
            this.label29.Text = "Filtros";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(124, 38);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 13);
            this.label30.TabIndex = 66;
            this.label30.Text = "Nombre:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(227, 38);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 13);
            this.label31.TabIndex = 63;
            this.label31.Text = "Apellido:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(333, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 13);
            this.label32.TabIndex = 63;
            this.label32.Text = "DNI:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(442, 51);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 67;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(121, 54);
            this.txtFiltroNombre.MaxLength = 50;
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 66;
            this.txtFiltroNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(227, 54);
            this.txtFiltroApellido.MaxLength = 50;
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroApellido.TabIndex = 66;
            this.txtFiltroApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtFiltroDNI
            // 
            this.txtFiltroDNI.Location = new System.Drawing.Point(333, 54);
            this.txtFiltroDNI.MaxLength = 10;
            this.txtFiltroDNI.Name = "txtFiltroDNI";
            this.txtFiltroDNI.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDNI.TabIndex = 66;
            this.txtFiltroDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteNacimiento
            // 
            this.txtClienteNacimiento.Location = new System.Drawing.Point(118, 233);
            this.txtClienteNacimiento.Mask = "00/00/0000";
            this.txtClienteNacimiento.Name = "txtClienteNacimiento";
            this.txtClienteNacimiento.Size = new System.Drawing.Size(62, 20);
            this.txtClienteNacimiento.TabIndex = 14;
            this.txtClienteNacimiento.ValidatingType = typeof(System.DateTime);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Apellido:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mail:";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Direccion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Codigo postal:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Fecha Nacimiento:";
            // 
            // txtClienteMail
            // 
            this.txtClienteMail.Location = new System.Drawing.Point(7, 117);
            this.txtClienteMail.MaxLength = 50;
            this.txtClienteMail.Name = "txtClienteMail";
            this.txtClienteMail.Size = new System.Drawing.Size(101, 20);
            this.txtClienteMail.TabIndex = 49;
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
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.Location = new System.Drawing.Point(11, 259);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(139, 23);
            this.btnGuardarDatos.TabIndex = 27;
            this.btnGuardarDatos.Text = "GUARDAR CAMBIOS";
            this.btnGuardarDatos.UseVisualStyleBackColor = true;
            this.btnGuardarDatos.Visible = false;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
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
            // txtIdSeleccionado
            // 
            this.txtIdSeleccionado.Enabled = false;
            this.txtIdSeleccionado.Location = new System.Drawing.Point(7, 40);
            this.txtIdSeleccionado.Name = "txtIdSeleccionado";
            this.txtIdSeleccionado.Size = new System.Drawing.Size(100, 20);
            this.txtIdSeleccionado.TabIndex = 59;
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
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(138, 13);
            this.label27.TabIndex = 61;
            this.label27.Text = "CLIENTE SELECCIONADO";
            // 
            // btnDescartarCambios
            // 
            this.btnDescartarCambios.Location = new System.Drawing.Point(156, 259);
            this.btnDescartarCambios.Name = "btnDescartarCambios";
            this.btnDescartarCambios.Size = new System.Drawing.Size(139, 23);
            this.btnDescartarCambios.TabIndex = 62;
            this.btnDescartarCambios.Text = "DESCARTAR CAMBIOS";
            this.btnDescartarCambios.UseVisualStyleBackColor = true;
            this.btnDescartarCambios.Visible = false;
            this.btnDescartarCambios.Click += new System.EventHandler(this.btnDescartarCambios_Click);
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(8, 77);
            this.txtClienteNombre.MaxLength = 50;
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(100, 20);
            this.txtClienteNombre.TabIndex = 66;
            this.txtClienteNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtClienteApellido
            // 
            this.txtClienteApellido.Location = new System.Drawing.Point(131, 78);
            this.txtClienteApellido.MaxLength = 50;
            this.txtClienteApellido.Name = "txtClienteApellido";
            this.txtClienteApellido.Size = new System.Drawing.Size(100, 20);
            this.txtClienteApellido.TabIndex = 66;
            this.txtClienteApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtClienteDNI
            // 
            this.txtClienteDNI.Location = new System.Drawing.Point(131, 40);
            this.txtClienteDNI.MaxLength = 10;
            this.txtClienteDNI.Name = "txtClienteDNI";
            this.txtClienteDNI.Size = new System.Drawing.Size(100, 20);
            this.txtClienteDNI.TabIndex = 66;
            this.txtClienteDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteTelefono
            // 
            this.txtClienteTelefono.Location = new System.Drawing.Point(131, 117);
            this.txtClienteTelefono.MaxLength = 18;
            this.txtClienteTelefono.Name = "txtClienteTelefono";
            this.txtClienteTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtClienteTelefono.TabIndex = 66;
            this.txtClienteTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteCodigoPostal
            // 
            this.txtClienteCodigoPostal.Location = new System.Drawing.Point(8, 233);
            this.txtClienteCodigoPostal.MaxLength = 10;
            this.txtClienteCodigoPostal.Name = "txtClienteCodigoPostal";
            this.txtClienteCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtClienteCodigoPostal.TabIndex = 66;
            this.txtClienteCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtClienteDireccion
            // 
            this.txtClienteDireccion.Location = new System.Drawing.Point(7, 186);
            this.txtClienteDireccion.MaxLength = 50;
            this.txtClienteDireccion.Name = "txtClienteDireccion";
            this.txtClienteDireccion.Size = new System.Drawing.Size(101, 20);
            this.txtClienteDireccion.TabIndex = 66;
            // 
            // txtClienteAltura
            // 
            this.txtClienteAltura.Location = new System.Drawing.Point(118, 186);
            this.txtClienteAltura.MaxLength = 6;
            this.txtClienteAltura.Name = "txtClienteAltura";
            this.txtClienteAltura.Size = new System.Drawing.Size(48, 20);
            this.txtClienteAltura.TabIndex = 66;
            this.txtClienteAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // panelDatosClienteSeleccionado
            // 
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteAltura);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteDireccion);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteCodigoPostal);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteTelefono);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteDNI);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteApellido);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteNombre);
            this.panelDatosClienteSeleccionado.Controls.Add(this.btnDescartarCambios);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label27);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label26);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtIdSeleccionado);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label24);
            this.panelDatosClienteSeleccionado.Controls.Add(this.btnGuardarDatos);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label22);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteMail);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label9);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label8);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label7);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label6);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label5);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label4);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label3);
            this.panelDatosClienteSeleccionado.Controls.Add(this.label2);
            this.panelDatosClienteSeleccionado.Controls.Add(this.txtClienteNacimiento);
            this.panelDatosClienteSeleccionado.Location = new System.Drawing.Point(12, 369);
            this.panelDatosClienteSeleccionado.Name = "panelDatosClienteSeleccionado";
            this.panelDatosClienteSeleccionado.Size = new System.Drawing.Size(343, 292);
            this.panelDatosClienteSeleccionado.TabIndex = 64;
            this.panelDatosClienteSeleccionado.Visible = false;
            // 
            // AbmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 741);
            this.Controls.Add(this.txtFiltroDNI);
            this.Controls.Add(this.txtFiltroApellido);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.panelDatosClienteSeleccionado);
            this.Controls.Add(this.panelDatosNuevoCliente);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminarCliente);
            this.Controls.Add(this.btnCrearCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClientes);
            this.Name = "AbmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AbmClientes";
            this.Load += new System.EventHandler(this.AbmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.panelDatosNuevoCliente.ResumeLayout(false);
            this.panelDatosNuevoCliente.PerformLayout();
            this.panelDatosClienteSeleccionado.ResumeLayout(false);
            this.panelDatosClienteSeleccionado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearCliente;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox txtClienteNacimientoNuevo;
        private System.Windows.Forms.TextBox txtClienteMailNuevo;
        private System.Windows.Forms.TextBox txtClienteDireccionNuevo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Panel panelDatosNuevoCliente;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnCancelarCrear;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtClienteDNINuevo;
        private System.Windows.Forms.TextBox txtClienteAlturaNuevo;
        private System.Windows.Forms.TextBox txtClienteTelefonoNuevo;
        private System.Windows.Forms.TextBox txtClienteCodigoPostalNuevo;
        private System.Windows.Forms.TextBox txtClienteNombreNuevo;
        private System.Windows.Forms.TextBox txtClienteApellidoNuevo;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.TextBox txtFiltroApellido;
        private System.Windows.Forms.TextBox txtFiltroDNI;
        private System.Windows.Forms.MaskedTextBox txtClienteNacimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClienteMail;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnGuardarDatos;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtIdSeleccionado;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnDescartarCambios;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.TextBox txtClienteApellido;
        private System.Windows.Forms.TextBox txtClienteDNI;
        private System.Windows.Forms.TextBox txtClienteTelefono;
        private System.Windows.Forms.TextBox txtClienteCodigoPostal;
        private System.Windows.Forms.TextBox txtClienteDireccion;
        private System.Windows.Forms.TextBox txtClienteAltura;
        private System.Windows.Forms.Panel panelDatosClienteSeleccionado;
    }
}