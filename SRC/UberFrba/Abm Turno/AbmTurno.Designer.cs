namespace UberFrba.Abm_Turno
{
    partial class AbmTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmTurno));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.btnCrearTurno = new System.Windows.Forms.Button();
            this.btnModificarTurno = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionTurno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericValorKm = new System.Windows.Forms.NumericUpDown();
            this.numericPrecioBase = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdTurno = new System.Windows.Forms.TextBox();
            this.panelDatosSeleccionado = new System.Windows.Forms.Panel();
            this.btnDescartarCambios = new System.Windows.Forms.Button();
            this.numericMinutoFin = new System.Windows.Forms.NumericUpDown();
            this.btnGuardarDatos = new System.Windows.Forms.Button();
            this.numericHoraFin = new System.Windows.Forms.NumericUpDown();
            this.numericMinutoInicio = new System.Windows.Forms.NumericUpDown();
            this.numericHoraInicio = new System.Windows.Forms.NumericUpDown();
            this.panelListaTurnos = new System.Windows.Forms.Panel();
            this.btnAltaLogica = new System.Windows.Forms.Button();
            this.checkVerInhabilitados = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecioBase)).BeginInit();
            this.panelDatosSeleccionado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraInicio)).BeginInit();
            this.panelListaTurnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "ABM TURNOS";
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(14, 34);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(710, 176);
            this.dgvTurnos.TabIndex = 2;
            this.dgvTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellClick);
            // 
            // btnCrearTurno
            // 
            this.btnCrearTurno.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCrearTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearTurno.Location = new System.Drawing.Point(14, 219);
            this.btnCrearTurno.Name = "btnCrearTurno";
            this.btnCrearTurno.Size = new System.Drawing.Size(170, 36);
            this.btnCrearTurno.TabIndex = 3;
            this.btnCrearTurno.Text = "CREAR";
            this.btnCrearTurno.UseVisualStyleBackColor = false;
            this.btnCrearTurno.Click += new System.EventHandler(this.btnCrearTurno_Click);
            // 
            // btnModificarTurno
            // 
            this.btnModificarTurno.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnModificarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarTurno.Location = new System.Drawing.Point(541, 219);
            this.btnModificarTurno.Name = "btnModificarTurno";
            this.btnModificarTurno.Size = new System.Drawing.Size(169, 36);
            this.btnModificarTurno.TabIndex = 4;
            this.btnModificarTurno.Text = "MODIFICAR";
            this.btnModificarTurno.UseVisualStyleBackColor = false;
            this.btnModificarTurno.Click += new System.EventHandler(this.btnModificarTurno_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LemonChiffon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(190, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "BAJA LOGICA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripcion";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDescripcionTurno
            // 
            this.txtDescripcionTurno.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtDescripcionTurno.Location = new System.Drawing.Point(234, 37);
            this.txtDescripcionTurno.Name = "txtDescripcionTurno";
            this.txtDescripcionTurno.Size = new System.Drawing.Size(153, 20);
            this.txtDescripcionTurno.TabIndex = 7;
            this.txtDescripcionTurno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hora Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hora Fin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(261, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Valor KM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Precio Base";
            // 
            // numericValorKm
            // 
            this.numericValorKm.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericValorKm.DecimalPlaces = 2;
            this.numericValorKm.Location = new System.Drawing.Point(246, 154);
            this.numericValorKm.Name = "numericValorKm";
            this.numericValorKm.Size = new System.Drawing.Size(128, 20);
            this.numericValorKm.TabIndex = 18;
            this.numericValorKm.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericPrecioBase
            // 
            this.numericPrecioBase.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericPrecioBase.DecimalPlaces = 2;
            this.numericPrecioBase.Location = new System.Drawing.Point(79, 155);
            this.numericPrecioBase.Name = "numericPrecioBase";
            this.numericPrecioBase.Size = new System.Drawing.Size(120, 20);
            this.numericPrecioBase.TabIndex = 18;
            this.numericPrecioBase.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Id";
            // 
            // txtIdTurno
            // 
            this.txtIdTurno.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtIdTurno.Location = new System.Drawing.Point(60, 37);
            this.txtIdTurno.Name = "txtIdTurno";
            this.txtIdTurno.ReadOnly = true;
            this.txtIdTurno.Size = new System.Drawing.Size(153, 20);
            this.txtIdTurno.TabIndex = 21;
            // 
            // panelDatosSeleccionado
            // 
            this.panelDatosSeleccionado.BackColor = System.Drawing.Color.Transparent;
            this.panelDatosSeleccionado.Controls.Add(this.btnDescartarCambios);
            this.panelDatosSeleccionado.Controls.Add(this.numericMinutoFin);
            this.panelDatosSeleccionado.Controls.Add(this.btnGuardarDatos);
            this.panelDatosSeleccionado.Controls.Add(this.numericHoraFin);
            this.panelDatosSeleccionado.Controls.Add(this.txtIdTurno);
            this.panelDatosSeleccionado.Controls.Add(this.numericMinutoInicio);
            this.panelDatosSeleccionado.Controls.Add(this.label2);
            this.panelDatosSeleccionado.Controls.Add(this.numericHoraInicio);
            this.panelDatosSeleccionado.Controls.Add(this.label8);
            this.panelDatosSeleccionado.Controls.Add(this.txtDescripcionTurno);
            this.panelDatosSeleccionado.Controls.Add(this.numericPrecioBase);
            this.panelDatosSeleccionado.Controls.Add(this.label3);
            this.panelDatosSeleccionado.Controls.Add(this.numericValorKm);
            this.panelDatosSeleccionado.Controls.Add(this.label4);
            this.panelDatosSeleccionado.Controls.Add(this.label5);
            this.panelDatosSeleccionado.Controls.Add(this.label6);
            this.panelDatosSeleccionado.Location = new System.Drawing.Point(132, 54);
            this.panelDatosSeleccionado.Name = "panelDatosSeleccionado";
            this.panelDatosSeleccionado.Size = new System.Drawing.Size(454, 290);
            this.panelDatosSeleccionado.TabIndex = 22;
            // 
            // btnDescartarCambios
            // 
            this.btnDescartarCambios.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnDescartarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescartarCambios.Location = new System.Drawing.Point(234, 192);
            this.btnDescartarCambios.Name = "btnDescartarCambios";
            this.btnDescartarCambios.Size = new System.Drawing.Size(153, 34);
            this.btnDescartarCambios.TabIndex = 28;
            this.btnDescartarCambios.Text = "VOLVER";
            this.btnDescartarCambios.UseVisualStyleBackColor = false;
            this.btnDescartarCambios.Click += new System.EventHandler(this.btnDescartarCambios_Click);
            // 
            // numericMinutoFin
            // 
            this.numericMinutoFin.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericMinutoFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericMinutoFin.Location = new System.Drawing.Point(308, 94);
            this.numericMinutoFin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinutoFin.Name = "numericMinutoFin";
            this.numericMinutoFin.Size = new System.Drawing.Size(49, 20);
            this.numericMinutoFin.TabIndex = 27;
            // 
            // btnGuardarDatos
            // 
            this.btnGuardarDatos.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGuardarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDatos.Location = new System.Drawing.Point(60, 192);
            this.btnGuardarDatos.Name = "btnGuardarDatos";
            this.btnGuardarDatos.Size = new System.Drawing.Size(153, 34);
            this.btnGuardarDatos.TabIndex = 23;
            this.btnGuardarDatos.Text = "GUARDAR";
            this.btnGuardarDatos.UseVisualStyleBackColor = false;
            this.btnGuardarDatos.Click += new System.EventHandler(this.btnGuardarDatos_Click);
            // 
            // numericHoraFin
            // 
            this.numericHoraFin.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericHoraFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericHoraFin.Location = new System.Drawing.Point(253, 94);
            this.numericHoraFin.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericHoraFin.Name = "numericHoraFin";
            this.numericHoraFin.Size = new System.Drawing.Size(49, 20);
            this.numericHoraFin.TabIndex = 26;
            // 
            // numericMinutoInicio
            // 
            this.numericMinutoInicio.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericMinutoInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericMinutoInicio.Location = new System.Drawing.Point(143, 94);
            this.numericMinutoInicio.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinutoInicio.Name = "numericMinutoInicio";
            this.numericMinutoInicio.Size = new System.Drawing.Size(49, 20);
            this.numericMinutoInicio.TabIndex = 25;
            // 
            // numericHoraInicio
            // 
            this.numericHoraInicio.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericHoraInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericHoraInicio.Location = new System.Drawing.Point(88, 94);
            this.numericHoraInicio.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericHoraInicio.Name = "numericHoraInicio";
            this.numericHoraInicio.Size = new System.Drawing.Size(49, 20);
            this.numericHoraInicio.TabIndex = 24;
            // 
            // panelListaTurnos
            // 
            this.panelListaTurnos.BackColor = System.Drawing.Color.Transparent;
            this.panelListaTurnos.Controls.Add(this.btnAltaLogica);
            this.panelListaTurnos.Controls.Add(this.checkVerInhabilitados);
            this.panelListaTurnos.Controls.Add(this.btnModificarTurno);
            this.panelListaTurnos.Controls.Add(this.button1);
            this.panelListaTurnos.Controls.Add(this.dgvTurnos);
            this.panelListaTurnos.Controls.Add(this.btnCrearTurno);
            this.panelListaTurnos.Location = new System.Drawing.Point(7, 62);
            this.panelListaTurnos.Name = "panelListaTurnos";
            this.panelListaTurnos.Size = new System.Drawing.Size(738, 264);
            this.panelListaTurnos.TabIndex = 23;
            this.panelListaTurnos.Paint += new System.Windows.Forms.PaintEventHandler(this.panelListaTurnos_Paint);
            // 
            // btnAltaLogica
            // 
            this.btnAltaLogica.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnAltaLogica.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaLogica.Location = new System.Drawing.Point(366, 219);
            this.btnAltaLogica.Name = "btnAltaLogica";
            this.btnAltaLogica.Size = new System.Drawing.Size(169, 36);
            this.btnAltaLogica.TabIndex = 24;
            this.btnAltaLogica.Text = "ALTA LOGICA";
            this.btnAltaLogica.UseVisualStyleBackColor = false;
            this.btnAltaLogica.Visible = false;
            this.btnAltaLogica.Click += new System.EventHandler(this.btnAltaLogica_Click);
            // 
            // checkVerInhabilitados
            // 
            this.checkVerInhabilitados.AutoSize = true;
            this.checkVerInhabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVerInhabilitados.Location = new System.Drawing.Point(14, 4);
            this.checkVerInhabilitados.Name = "checkVerInhabilitados";
            this.checkVerInhabilitados.Size = new System.Drawing.Size(145, 24);
            this.checkVerInhabilitados.TabIndex = 7;
            this.checkVerInhabilitados.Text = "Ver inhabilitados";
            this.checkVerInhabilitados.UseVisualStyleBackColor = true;
            this.checkVerInhabilitados.CheckedChanged += new System.EventHandler(this.checkVerInhabilitados_CheckedChanged);
            // 
            // AbmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(760, 354);
            this.Controls.Add(this.panelListaTurnos);
            this.Controls.Add(this.panelDatosSeleccionado);
            this.Controls.Add(this.label1);
            this.Name = "AbmTurno";
            this.Text = "AbmTurno";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecioBase)).EndInit();
            this.panelDatosSeleccionado.ResumeLayout(false);
            this.panelDatosSeleccionado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraInicio)).EndInit();
            this.panelListaTurnos.ResumeLayout(false);
            this.panelListaTurnos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Button btnCrearTurno;
        private System.Windows.Forms.Button btnModificarTurno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcionTurno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericValorKm;
        private System.Windows.Forms.NumericUpDown numericPrecioBase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdTurno;
        private System.Windows.Forms.Panel panelDatosSeleccionado;
        private System.Windows.Forms.Button btnGuardarDatos;
        private System.Windows.Forms.NumericUpDown numericHoraInicio;
        private System.Windows.Forms.NumericUpDown numericMinutoInicio;
        private System.Windows.Forms.NumericUpDown numericMinutoFin;
        private System.Windows.Forms.NumericUpDown numericHoraFin;
        private System.Windows.Forms.Panel panelListaTurnos;
        private System.Windows.Forms.CheckBox checkVerInhabilitados;
        private System.Windows.Forms.Button btnDescartarCambios;
        private System.Windows.Forms.Button btnAltaLogica;
    }
}