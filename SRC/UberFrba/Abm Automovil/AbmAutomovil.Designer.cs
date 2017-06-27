namespace UberFrba.Abm_Automovil
{
    partial class AbmAutomovil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmAutomovil));
            this.txtFiltroPatente = new System.Windows.Forms.TextBox();
            this.txtFiltroModelo = new System.Windows.Forms.TextBox();
            this.txtFiltroMarca = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.dgvAutomovil = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFiltroChofer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatosSeleccionado = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboChofer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.txtClienteCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtRodado = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.btnDescartarCambios = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtIdSeleccionado = new System.Windows.Forms.TextBox();
            this.btnGuardarDatos = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClienteNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomovil)).BeginInit();
            this.panelDatosSeleccionado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltroPatente
            // 
            this.txtFiltroPatente.Location = new System.Drawing.Point(212, 42);
            this.txtFiltroPatente.MaxLength = 10;
            this.txtFiltroPatente.Name = "txtFiltroPatente";
            this.txtFiltroPatente.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroPatente.TabIndex = 71;
            // 
            // txtFiltroModelo
            // 
            this.txtFiltroModelo.Location = new System.Drawing.Point(109, 42);
            this.txtFiltroModelo.MaxLength = 50;
            this.txtFiltroModelo.Name = "txtFiltroModelo";
            this.txtFiltroModelo.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroModelo.TabIndex = 72;
            // 
            // txtFiltroMarca
            // 
            this.txtFiltroMarca.Location = new System.Drawing.Point(7, 42);
            this.txtFiltroMarca.MaxLength = 50;
            this.txtFiltroMarca.Name = "txtFiltroMarca";
            this.txtFiltroMarca.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroMarca.TabIndex = 73;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFiltrar.Location = new System.Drawing.Point(433, 34);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(103, 33);
            this.btnFiltrar.TabIndex = 75;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.LemonChiffon;
            this.label32.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label32.Location = new System.Drawing.Point(209, 26);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 13);
            this.label32.TabIndex = 68;
            this.label32.Text = "Patente:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.LemonChiffon;
            this.label31.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label31.Location = new System.Drawing.Point(106, 26);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(45, 13);
            this.label31.TabIndex = 69;
            this.label31.Text = "Modelo:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.LemonChiffon;
            this.label30.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label30.Location = new System.Drawing.Point(4, 26);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 13);
            this.label30.TabIndex = 74;
            this.label30.Text = "Marca:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.LemonChiffon;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label29.Location = new System.Drawing.Point(3, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(95, 20);
            this.label29.TabIndex = 70;
            this.label29.Text = "Busqueda:";
            // 
            // dgvAutomovil
            // 
            this.dgvAutomovil.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgvAutomovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutomovil.Location = new System.Drawing.Point(0, 68);
            this.dgvAutomovil.Name = "dgvAutomovil";
            this.dgvAutomovil.Size = new System.Drawing.Size(729, 242);
            this.dgvAutomovil.TabIndex = 76;
            this.dgvAutomovil.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutomovil_CellClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(557, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 33);
            this.button1.TabIndex = 77;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFiltroChofer
            // 
            this.txtFiltroChofer.Location = new System.Drawing.Point(318, 42);
            this.txtFiltroChofer.MaxLength = 10;
            this.txtFiltroChofer.Name = "txtFiltroChofer";
            this.txtFiltroChofer.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroChofer.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(315, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Chofer:";
            // 
            // panelDatosSeleccionado
            // 
            this.panelDatosSeleccionado.BackColor = System.Drawing.Color.LemonChiffon;
            this.panelDatosSeleccionado.Controls.Add(this.button2);
            this.panelDatosSeleccionado.Controls.Add(this.comboTurno);
            this.panelDatosSeleccionado.Controls.Add(this.label10);
            this.panelDatosSeleccionado.Controls.Add(this.comboChofer);
            this.panelDatosSeleccionado.Controls.Add(this.label7);
            this.panelDatosSeleccionado.Controls.Add(this.button5);
            this.panelDatosSeleccionado.Controls.Add(this.button4);
            this.panelDatosSeleccionado.Controls.Add(this.button3);
            this.panelDatosSeleccionado.Controls.Add(this.comboMarca);
            this.panelDatosSeleccionado.Controls.Add(this.txtClienteCodigoPostal);
            this.panelDatosSeleccionado.Controls.Add(this.txtRodado);
            this.panelDatosSeleccionado.Controls.Add(this.txtPatente);
            this.panelDatosSeleccionado.Controls.Add(this.txtLicencia);
            this.panelDatosSeleccionado.Controls.Add(this.txtModelo);
            this.panelDatosSeleccionado.Controls.Add(this.btnDescartarCambios);
            this.panelDatosSeleccionado.Controls.Add(this.label27);
            this.panelDatosSeleccionado.Controls.Add(this.label26);
            this.panelDatosSeleccionado.Controls.Add(this.txtIdSeleccionado);
            this.panelDatosSeleccionado.Controls.Add(this.btnGuardarDatos);
            this.panelDatosSeleccionado.Controls.Add(this.label9);
            this.panelDatosSeleccionado.Controls.Add(this.label8);
            this.panelDatosSeleccionado.Controls.Add(this.label6);
            this.panelDatosSeleccionado.Controls.Add(this.label5);
            this.panelDatosSeleccionado.Controls.Add(this.label4);
            this.panelDatosSeleccionado.Controls.Add(this.label3);
            this.panelDatosSeleccionado.Controls.Add(this.label2);
            this.panelDatosSeleccionado.Controls.Add(this.txtClienteNacimiento);
            this.panelDatosSeleccionado.Location = new System.Drawing.Point(189, 156);
            this.panelDatosSeleccionado.Name = "panelDatosSeleccionado";
            this.panelDatosSeleccionado.Size = new System.Drawing.Size(475, 170);
            this.panelDatosSeleccionado.TabIndex = 81;
            this.panelDatosSeleccionado.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(385, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 89;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_guardar_nuevo_Click);
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(195, 131);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(154, 21);
            this.comboTurno.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(192, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "Turno:";
            // 
            // comboChofer
            // 
            this.comboChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChofer.FormattingEnabled = true;
            this.comboChofer.Location = new System.Drawing.Point(12, 130);
            this.comboChofer.Name = "comboChofer";
            this.comboChofer.Size = new System.Drawing.Size(154, 21);
            this.comboChofer.TabIndex = 86;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 85;
            this.label7.Text = "Chofer:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(385, 119);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 33);
            this.button5.TabIndex = 84;
            this.button5.Text = "Volver";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(385, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 33);
            this.button4.TabIndex = 83;
            this.button4.Text = "Borrar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(385, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 33);
            this.button3.TabIndex = 82;
            this.button3.Text = "Guardar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_guardar_modificar_Click);
            // 
            // comboMarca
            // 
            this.comboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(263, 47);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(100, 21);
            this.comboMarca.TabIndex = 67;
            // 
            // txtClienteCodigoPostal
            // 
            this.txtClienteCodigoPostal.Location = new System.Drawing.Point(8, 233);
            this.txtClienteCodigoPostal.MaxLength = 10;
            this.txtClienteCodigoPostal.Name = "txtClienteCodigoPostal";
            this.txtClienteCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtClienteCodigoPostal.TabIndex = 66;
            // 
            // txtRodado
            // 
            this.txtRodado.Location = new System.Drawing.Point(263, 88);
            this.txtRodado.MaxLength = 10;
            this.txtRodado.Name = "txtRodado";
            this.txtRodado.Size = new System.Drawing.Size(100, 20);
            this.txtRodado.TabIndex = 66;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(135, 48);
            this.txtPatente.MaxLength = 10;
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 66;
            // 
            // txtLicencia
            // 
            this.txtLicencia.Location = new System.Drawing.Point(135, 88);
            this.txtLicencia.MaxLength = 26;
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(100, 20);
            this.txtLicencia.TabIndex = 66;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(10, 88);
            this.txtModelo.MaxLength = 50;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 66;
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
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(87, 20);
            this.label27.TabIndex = 61;
            this.label27.Text = "Automovil";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 33);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(19, 13);
            this.label26.TabIndex = 60;
            this.label26.Text = "Id:";
            // 
            // txtIdSeleccionado
            // 
            this.txtIdSeleccionado.Enabled = false;
            this.txtIdSeleccionado.Location = new System.Drawing.Point(11, 48);
            this.txtIdSeleccionado.Name = "txtIdSeleccionado";
            this.txtIdSeleccionado.Size = new System.Drawing.Size(100, 20);
            this.txtIdSeleccionado.TabIndex = 59;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Codigo postal:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Rodado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Marca:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Patente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Licencia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Modelo:";
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
            // btn_nuevo
            // 
            this.btn_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_nuevo.Location = new System.Drawing.Point(78, 317);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(141, 33);
            this.btn_nuevo.TabIndex = 82;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_eliminar.Location = new System.Drawing.Point(248, 318);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(141, 33);
            this.btn_eliminar.TabIndex = 83;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modificar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_modificar.Location = new System.Drawing.Point(424, 318);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(141, 33);
            this.btn_modificar.TabIndex = 84;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btn_modificar);
            this.panel1.Controls.Add(this.txtFiltroMarca);
            this.panel1.Controls.Add(this.btn_eliminar);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.btn_nuevo);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.dgvAutomovil);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtFiltroChofer);
            this.panel1.Controls.Add(this.txtFiltroModelo);
            this.panel1.Controls.Add(this.btnFiltrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.txtFiltroPatente);
            this.panel1.Location = new System.Drawing.Point(98, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 378);
            this.panel1.TabIndex = 85;
            // 
            // AbmAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(857, 469);
            this.Controls.Add(this.panelDatosSeleccionado);
            this.Controls.Add(this.panel1);
            this.Name = "AbmAutomovil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abm automovil";
            this.Load += new System.EventHandler(this.AbmAutomovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomovil)).EndInit();
            this.panelDatosSeleccionado.ResumeLayout(false);
            this.panelDatosSeleccionado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroPatente;
        private System.Windows.Forms.TextBox txtFiltroModelo;
        private System.Windows.Forms.TextBox txtFiltroMarca;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView dgvAutomovil;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFiltroChofer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDatosSeleccionado;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.TextBox txtClienteCodigoPostal;
        private System.Windows.Forms.TextBox txtRodado;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Button btnDescartarCambios;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtIdSeleccionado;
        private System.Windows.Forms.Button btnGuardarDatos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtClienteNacimiento;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboChofer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;

    }
}