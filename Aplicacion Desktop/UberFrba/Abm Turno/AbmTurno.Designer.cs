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
            this.btnVerTurnos = new System.Windows.Forms.Button();
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
            this.dateTimePickerHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHoraFin = new System.Windows.Forms.DateTimePicker();
            this.numericValorKm = new System.Windows.Forms.NumericUpDown();
            this.numericPrecioBase = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdTurno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecioBase)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerTurnos
            // 
            this.btnVerTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTurnos.Location = new System.Drawing.Point(33, 54);
            this.btnVerTurnos.Name = "btnVerTurnos";
            this.btnVerTurnos.Size = new System.Drawing.Size(238, 36);
            this.btnVerTurnos.TabIndex = 0;
            this.btnVerTurnos.Text = "VER TURNOS";
            this.btnVerTurnos.UseVisualStyleBackColor = true;
            this.btnVerTurnos.Click += new System.EventHandler(this.btnVerTurnos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "ABM TURNOS";
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(33, 96);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(575, 241);
            this.dgvTurnos.TabIndex = 2;
            this.dgvTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellClick);
            // 
            // btnCrearTurno
            // 
            this.btnCrearTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearTurno.Location = new System.Drawing.Point(645, 385);
            this.btnCrearTurno.Name = "btnCrearTurno";
            this.btnCrearTurno.Size = new System.Drawing.Size(238, 36);
            this.btnCrearTurno.TabIndex = 3;
            this.btnCrearTurno.Text = "CREAR";
            this.btnCrearTurno.UseVisualStyleBackColor = true;
            this.btnCrearTurno.Click += new System.EventHandler(this.btnCrearTurno_Click);
            // 
            // btnModificarTurno
            // 
            this.btnModificarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarTurno.Location = new System.Drawing.Point(370, 343);
            this.btnModificarTurno.Name = "btnModificarTurno";
            this.btnModificarTurno.Size = new System.Drawing.Size(238, 36);
            this.btnModificarTurno.TabIndex = 4;
            this.btnModificarTurno.Text = "MODIFICAR";
            this.btnModificarTurno.UseVisualStyleBackColor = true;
            this.btnModificarTurno.Click += new System.EventHandler(this.btnModificarTurno_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(486, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "ELIMINAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(724, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descripcion";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDescripcionTurno
            // 
            this.txtDescripcionTurno.Location = new System.Drawing.Point(689, 96);
            this.txtDescripcionTurno.Name = "txtDescripcionTurno";
            this.txtDescripcionTurno.Size = new System.Drawing.Size(153, 20);
            this.txtDescripcionTurno.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(724, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hora Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(724, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hora Fin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(723, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Valor KM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(724, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Precio Base";
            // 
            // dateTimePickerHoraInicio
            // 
            this.dateTimePickerHoraInicio.Location = new System.Drawing.Point(689, 151);
            this.dateTimePickerHoraInicio.Name = "dateTimePickerHoraInicio";
            this.dateTimePickerHoraInicio.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerHoraInicio.TabIndex = 16;
            // 
            // dateTimePickerHoraFin
            // 
            this.dateTimePickerHoraFin.Location = new System.Drawing.Point(689, 207);
            this.dateTimePickerHoraFin.Name = "dateTimePickerHoraFin";
            this.dateTimePickerHoraFin.Size = new System.Drawing.Size(153, 20);
            this.dateTimePickerHoraFin.TabIndex = 17;
            // 
            // numericValorKm
            // 
            this.numericValorKm.DecimalPlaces = 2;
            this.numericValorKm.Location = new System.Drawing.Point(708, 317);
            this.numericValorKm.Name = "numericValorKm";
            this.numericValorKm.Size = new System.Drawing.Size(120, 20);
            this.numericValorKm.TabIndex = 18;
            this.numericValorKm.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericPrecioBase
            // 
            this.numericPrecioBase.DecimalPlaces = 2;
            this.numericPrecioBase.Location = new System.Drawing.Point(708, 263);
            this.numericPrecioBase.Name = "numericPrecioBase";
            this.numericPrecioBase.Size = new System.Drawing.Size(120, 20);
            this.numericPrecioBase.TabIndex = 18;
            this.numericPrecioBase.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(753, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Id";
            // 
            // txtIdTurno
            // 
            this.txtIdTurno.Location = new System.Drawing.Point(689, 54);
            this.txtIdTurno.Name = "txtIdTurno";
            this.txtIdTurno.ReadOnly = true;
            this.txtIdTurno.Size = new System.Drawing.Size(153, 20);
            this.txtIdTurno.TabIndex = 21;
            // 
            // AbmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 560);
            this.Controls.Add(this.txtIdTurno);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericPrecioBase);
            this.Controls.Add(this.numericValorKm);
            this.Controls.Add(this.dateTimePickerHoraFin);
            this.Controls.Add(this.dateTimePickerHoraInicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcionTurno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModificarTurno);
            this.Controls.Add(this.btnCrearTurno);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerTurnos);
            this.Name = "AbmTurno";
            this.Text = "AbmTurno";
            this.Load += new System.EventHandler(this.AbmTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecioBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerTurnos;
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
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerHoraFin;
        private System.Windows.Forms.NumericUpDown numericValorKm;
        private System.Windows.Forms.NumericUpDown numericPrecioBase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdTurno;
    }
}