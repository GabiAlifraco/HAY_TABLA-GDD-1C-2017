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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmChofer));
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
            this.panelDatosChoferSeleccionado = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
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
            this.panelChoferes = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAltaLogica = new System.Windows.Forms.Button();
            this.checkVerInhabilitados = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).BeginInit();
            this.panelDatosChoferSeleccionado.SuspendLayout();
            this.panelChoferes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltroDNI
            // 
            this.txtFiltroDNI.Location = new System.Drawing.Point(352, 56);
            this.txtFiltroDNI.MaxLength = 10;
            this.txtFiltroDNI.Name = "txtFiltroDNI";
            this.txtFiltroDNI.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDNI.TabIndex = 73;
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(246, 56);
            this.txtFiltroApellido.MaxLength = 50;
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroApellido.TabIndex = 74;
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(140, 56);
            this.txtFiltroNombre.MaxLength = 50;
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 75;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(461, 53);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 77;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.LemonChiffon;
            this.label32.Location = new System.Drawing.Point(352, 40);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 13);
            this.label32.TabIndex = 70;
            this.label32.Text = "DNI:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.LemonChiffon;
            this.label31.Location = new System.Drawing.Point(246, 40);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 13);
            this.label31.TabIndex = 71;
            this.label31.Text = "Apellido:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.LemonChiffon;
            this.label30.Location = new System.Drawing.Point(143, 40);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 13);
            this.label30.TabIndex = 76;
            this.label30.Text = "Nombre:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.LemonChiffon;
            this.label29.Location = new System.Drawing.Point(144, 16);
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
            this.dgvChoferes.AllowUserToAddRows = false;
            this.dgvChoferes.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgvChoferes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoferes.Location = new System.Drawing.Point(3, 79);
            this.dgvChoferes.MultiSelect = false;
            this.dgvChoferes.Name = "dgvChoferes";
            this.dgvChoferes.Size = new System.Drawing.Size(1226, 263);
            this.dgvChoferes.TabIndex = 68;
            this.dgvChoferes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChoferes_CellClick);
            // 
            // panelDatosChoferSeleccionado
            // 
            this.panelDatosChoferSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.panelDatosChoferSeleccionado.Controls.Add(this.textBox1);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtDepto);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtPiso);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtLocalidad);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label10);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label11);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferAltura);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferDireccion);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferTelefono);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferDNI);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferApellido);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferNombre);
            this.panelDatosChoferSeleccionado.Controls.Add(this.btnDescartarCambios);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label27);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label26);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtIdSeleccionado);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label24);
            this.panelDatosChoferSeleccionado.Controls.Add(this.btnGuardarDatos);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label22);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferMail);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label9);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label7);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label6);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label5);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label4);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label3);
            this.panelDatosChoferSeleccionado.Controls.Add(this.label2);
            this.panelDatosChoferSeleccionado.Controls.Add(this.txtChoferNacimiento);
            this.panelDatosChoferSeleccionado.Location = new System.Drawing.Point(58, 51);
            this.panelDatosChoferSeleccionado.Name = "panelDatosChoferSeleccionado";
            this.panelDatosChoferSeleccionado.Size = new System.Drawing.Size(536, 192);
            this.panelDatosChoferSeleccionado.TabIndex = 80;
            this.panelDatosChoferSeleccionado.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(262, 118);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 20);
            this.textBox1.TabIndex = 71;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(132, 118);
            this.txtDepto.MaxLength = 10;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 72;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(8, 118);
            this.txtPiso.MaxLength = 50;
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(101, 20);
            this.txtPiso.TabIndex = 70;
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.AutoSize = true;
            this.txtLocalidad.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtLocalidad.Location = new System.Drawing.Point(260, 102);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(56, 13);
            this.txtLocalidad.TabIndex = 69;
            this.txtLocalidad.Text = "Localidad:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LemonChiffon;
            this.label10.Location = new System.Drawing.Point(129, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 68;
            this.label10.Text = "Departamento:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LemonChiffon;
            this.label11.Location = new System.Drawing.Point(5, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Piso:";
            // 
            // txtChoferAltura
            // 
            this.txtChoferAltura.Location = new System.Drawing.Point(386, 79);
            this.txtChoferAltura.MaxLength = 6;
            this.txtChoferAltura.Name = "txtChoferAltura";
            this.txtChoferAltura.Size = new System.Drawing.Size(48, 20);
            this.txtChoferAltura.TabIndex = 66;
            this.txtChoferAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtChoferDireccion
            // 
            this.txtChoferDireccion.Location = new System.Drawing.Point(262, 79);
            this.txtChoferDireccion.MaxLength = 50;
            this.txtChoferDireccion.Name = "txtChoferDireccion";
            this.txtChoferDireccion.Size = new System.Drawing.Size(101, 20);
            this.txtChoferDireccion.TabIndex = 66;
            this.txtChoferDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtChoferTelefono
            // 
            this.txtChoferTelefono.Location = new System.Drawing.Point(132, 79);
            this.txtChoferTelefono.MaxLength = 10;
            this.txtChoferTelefono.Name = "txtChoferTelefono";
            this.txtChoferTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtChoferTelefono.TabIndex = 66;
            this.txtChoferTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtChoferDNI
            // 
            this.txtChoferDNI.Location = new System.Drawing.Point(131, 40);
            this.txtChoferDNI.MaxLength = 8;
            this.txtChoferDNI.Name = "txtChoferDNI";
            this.txtChoferDNI.Size = new System.Drawing.Size(100, 20);
            this.txtChoferDNI.TabIndex = 66;
            this.txtChoferDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtChoferApellido
            // 
            this.txtChoferApellido.Location = new System.Drawing.Point(385, 41);
            this.txtChoferApellido.MaxLength = 50;
            this.txtChoferApellido.Name = "txtChoferApellido";
            this.txtChoferApellido.Size = new System.Drawing.Size(100, 20);
            this.txtChoferApellido.TabIndex = 66;
            this.txtChoferApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // txtChoferNombre
            // 
            this.txtChoferNombre.Location = new System.Drawing.Point(262, 40);
            this.txtChoferNombre.MaxLength = 50;
            this.txtChoferNombre.Name = "txtChoferNombre";
            this.txtChoferNombre.Size = new System.Drawing.Size(100, 20);
            this.txtChoferNombre.TabIndex = 66;
            this.txtChoferNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // btnDescartarCambios
            // 
            this.btnDescartarCambios.Location = new System.Drawing.Point(277, 144);
            this.btnDescartarCambios.Name = "btnDescartarCambios";
            this.btnDescartarCambios.Size = new System.Drawing.Size(139, 23);
            this.btnDescartarCambios.TabIndex = 62;
            this.btnDescartarCambios.Text = "DESCARTAR CAMBIOS";
            this.btnDescartarCambios.UseVisualStyleBackColor = true;
            this.btnDescartarCambios.Click += new System.EventHandler(this.btnDescartarCambios_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.LemonChiffon;
            this.label27.Location = new System.Drawing.Point(3, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(137, 13);
            this.label27.TabIndex = 61;
            this.label27.Text = "CHOFER SELECCIONADO";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.LemonChiffon;
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
            this.label24.BackColor = System.Drawing.Color.LemonChiffon;
            this.label24.Location = new System.Drawing.Point(382, 63);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 13);
            this.label24.TabIndex = 57;
            this.label24.Text = "Altura";
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.Location = new System.Drawing.Point(47, 144);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(139, 23);
            this.btnGuardarDatos.TabIndex = 27;
            this.btnGuardarDatos.Text = "GUARDAR CAMBIOS";
            this.btnGuardarDatos.UseVisualStyleBackColor = true;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.LemonChiffon;
            this.label22.Location = new System.Drawing.Point(322, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Calle";
            // 
            // txtChoferMail
            // 
            this.txtChoferMail.Location = new System.Drawing.Point(8, 79);
            this.txtChoferMail.MaxLength = 50;
            this.txtChoferMail.Name = "txtChoferMail";
            this.txtChoferMail.Size = new System.Drawing.Size(101, 20);
            this.txtChoferMail.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LemonChiffon;
            this.label9.Location = new System.Drawing.Point(383, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Fecha Nacimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LemonChiffon;
            this.label7.Location = new System.Drawing.Point(260, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Direccion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LemonChiffon;
            this.label6.Location = new System.Drawing.Point(129, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.Location = new System.Drawing.Point(5, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Mail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LemonChiffon;
            this.label4.Location = new System.Drawing.Point(128, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.Location = new System.Drawing.Point(382, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Location = new System.Drawing.Point(258, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre:";
            // 
            // txtChoferNacimiento
            // 
            this.txtChoferNacimiento.Location = new System.Drawing.Point(387, 118);
            this.txtChoferNacimiento.Mask = "00/00/0000";
            this.txtChoferNacimiento.Name = "txtChoferNacimiento";
            this.txtChoferNacimiento.Size = new System.Drawing.Size(62, 20);
            this.txtChoferNacimiento.TabIndex = 14;
            this.txtChoferNacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(31, 348);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(139, 23);
            this.btnModificar.TabIndex = 79;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarChofer
            // 
            this.btnEliminarChofer.Location = new System.Drawing.Point(176, 348);
            this.btnEliminarChofer.Name = "btnEliminarChofer";
            this.btnEliminarChofer.Size = new System.Drawing.Size(172, 23);
            this.btnEliminarChofer.TabIndex = 78;
            this.btnEliminarChofer.Text = "BAJA LOGICA SELECIONADO ";
            this.btnEliminarChofer.UseVisualStyleBackColor = true;
            this.btnEliminarChofer.Visible = false;
            this.btnEliminarChofer.Click += new System.EventHandler(this.btnEliminarChofer_Click);
            // 
            // btnCrearCliente
            // 
            this.btnCrearCliente.Location = new System.Drawing.Point(534, 348);
            this.btnCrearCliente.Name = "btnCrearCliente";
            this.btnCrearCliente.Size = new System.Drawing.Size(172, 23);
            this.btnCrearCliente.TabIndex = 81;
            this.btnCrearCliente.Text = "CREAR CHOFER";
            this.btnCrearCliente.UseVisualStyleBackColor = true;
            this.btnCrearCliente.Click += new System.EventHandler(this.btnCrearCliente_Click);
            // 
            // panelChoferes
            // 
            this.panelChoferes.BackColor = System.Drawing.Color.Transparent;
            this.panelChoferes.Controls.Add(this.button2);
            this.panelChoferes.Controls.Add(this.btnAltaLogica);
            this.panelChoferes.Controls.Add(this.checkVerInhabilitados);
            this.panelChoferes.Controls.Add(this.dgvChoferes);
            this.panelChoferes.Controls.Add(this.btnCrearCliente);
            this.panelChoferes.Controls.Add(this.label29);
            this.panelChoferes.Controls.Add(this.label30);
            this.panelChoferes.Controls.Add(this.btnModificar);
            this.panelChoferes.Controls.Add(this.label31);
            this.panelChoferes.Controls.Add(this.btnEliminarChofer);
            this.panelChoferes.Controls.Add(this.label32);
            this.panelChoferes.Controls.Add(this.txtFiltroDNI);
            this.panelChoferes.Controls.Add(this.btnFiltrar);
            this.panelChoferes.Controls.Add(this.txtFiltroApellido);
            this.panelChoferes.Controls.Add(this.txtFiltroNombre);
            this.panelChoferes.Location = new System.Drawing.Point(29, 12);
            this.panelChoferes.Name = "panelChoferes";
            this.panelChoferes.Size = new System.Drawing.Size(1232, 405);
            this.panelChoferes.TabIndex = 82;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(542, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 24);
            this.button2.TabIndex = 83;
            this.button2.Text = "VACIAR FILTROS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAltaLogica
            // 
            this.btnAltaLogica.Location = new System.Drawing.Point(357, 348);
            this.btnAltaLogica.Name = "btnAltaLogica";
            this.btnAltaLogica.Size = new System.Drawing.Size(170, 23);
            this.btnAltaLogica.TabIndex = 82;
            this.btnAltaLogica.Text = "ALTA LOGICA SELECCIONADO";
            this.btnAltaLogica.UseVisualStyleBackColor = true;
            this.btnAltaLogica.Visible = false;
            this.btnAltaLogica.Click += new System.EventHandler(this.btnAltaLogica_Click);
            // 
            // checkVerInhabilitados
            // 
            this.checkVerInhabilitados.AutoSize = true;
            this.checkVerInhabilitados.Location = new System.Drawing.Point(31, 57);
            this.checkVerInhabilitados.Name = "checkVerInhabilitados";
            this.checkVerInhabilitados.Size = new System.Drawing.Size(103, 17);
            this.checkVerInhabilitados.TabIndex = 69;
            this.checkVerInhabilitados.Text = "Ver inhabilitados";
            this.checkVerInhabilitados.UseVisualStyleBackColor = true;
            this.checkVerInhabilitados.CheckedChanged += new System.EventHandler(this.checkVerInhabilitados_CheckedChanged);
            // 
            // AbmChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1273, 491);
            this.Controls.Add(this.panelChoferes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelDatosChoferSeleccionado);
            this.MaximizeBox = false;
            this.Name = "AbmChofer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AbmChofer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).EndInit();
            this.panelDatosChoferSeleccionado.ResumeLayout(false);
            this.panelDatosChoferSeleccionado.PerformLayout();
            this.panelChoferes.ResumeLayout(false);
            this.panelChoferes.PerformLayout();
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
        private System.Windows.Forms.Panel panelDatosChoferSeleccionado;
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
        private System.Windows.Forms.Panel panelChoferes;
        private System.Windows.Forms.CheckBox checkVerInhabilitados;
        private System.Windows.Forms.Button btnAltaLogica;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label txtLocalidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}