namespace UberFrba.Abm_Turno
{
    partial class AltaTurnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaTurnos));
            this.numericPrecioBase = new System.Windows.Forms.NumericUpDown();
            this.numericValorKm = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcionTurno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrearTurno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericMinutoFin = new System.Windows.Forms.NumericUpDown();
            this.numericHoraFin = new System.Windows.Forms.NumericUpDown();
            this.numericMinutoInicio = new System.Windows.Forms.NumericUpDown();
            this.numericHoraInicio = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecioBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // numericPrecioBase
            // 
            this.numericPrecioBase.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericPrecioBase.DecimalPlaces = 2;
            this.numericPrecioBase.Location = new System.Drawing.Point(110, 257);
            this.numericPrecioBase.Name = "numericPrecioBase";
            this.numericPrecioBase.Size = new System.Drawing.Size(120, 20);
            this.numericPrecioBase.TabIndex = 31;
            // 
            // numericValorKm
            // 
            this.numericValorKm.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericValorKm.DecimalPlaces = 2;
            this.numericValorKm.Location = new System.Drawing.Point(110, 311);
            this.numericValorKm.Name = "numericValorKm";
            this.numericValorKm.Size = new System.Drawing.Size(120, 20);
            this.numericValorKm.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LemonChiffon;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Precio Base";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(127, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Valor KM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LemonChiffon;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Hora Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Hora Inicio";
            // 
            // txtDescripcionTurno
            // 
            this.txtDescripcionTurno.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtDescripcionTurno.Location = new System.Drawing.Point(91, 90);
            this.txtDescripcionTurno.Name = "txtDescripcionTurno";
            this.txtDescripcionTurno.Size = new System.Drawing.Size(165, 20);
            this.txtDescripcionTurno.TabIndex = 24;
            this.txtDescripcionTurno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloLetras);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Descripcion";
            // 
            // btnCrearTurno
            // 
            this.btnCrearTurno.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnCrearTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearTurno.Location = new System.Drawing.Point(110, 337);
            this.btnCrearTurno.Name = "btnCrearTurno";
            this.btnCrearTurno.Size = new System.Drawing.Size(120, 36);
            this.btnCrearTurno.TabIndex = 22;
            this.btnCrearTurno.Text = "CREAR";
            this.btnCrearTurno.UseVisualStyleBackColor = false;
            this.btnCrearTurno.Click += new System.EventHandler(this.btnCrearTurno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 42);
            this.label1.TabIndex = 35;
            this.label1.Text = "ALTA TURNOS";
            // 
            // numericMinutoFin
            // 
            this.numericMinutoFin.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericMinutoFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericMinutoFin.Location = new System.Drawing.Point(174, 201);
            this.numericMinutoFin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinutoFin.Name = "numericMinutoFin";
            this.numericMinutoFin.Size = new System.Drawing.Size(49, 20);
            this.numericMinutoFin.TabIndex = 39;
            // 
            // numericHoraFin
            // 
            this.numericHoraFin.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericHoraFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericHoraFin.Location = new System.Drawing.Point(119, 201);
            this.numericHoraFin.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericHoraFin.Name = "numericHoraFin";
            this.numericHoraFin.Size = new System.Drawing.Size(49, 20);
            this.numericHoraFin.TabIndex = 38;
            // 
            // numericMinutoInicio
            // 
            this.numericMinutoInicio.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericMinutoInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericMinutoInicio.Location = new System.Drawing.Point(174, 145);
            this.numericMinutoInicio.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinutoInicio.Name = "numericMinutoInicio";
            this.numericMinutoInicio.Size = new System.Drawing.Size(49, 20);
            this.numericMinutoInicio.TabIndex = 37;
            // 
            // numericHoraInicio
            // 
            this.numericHoraInicio.BackColor = System.Drawing.Color.LemonChiffon;
            this.numericHoraInicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericHoraInicio.Location = new System.Drawing.Point(119, 145);
            this.numericHoraInicio.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericHoraInicio.Name = "numericHoraInicio";
            this.numericHoraInicio.Size = new System.Drawing.Size(49, 20);
            this.numericHoraInicio.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LemonChiffon;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 36);
            this.button1.TabIndex = 40;
            this.button1.Text = "VOLVER ABM TURNO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AltaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(344, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericMinutoFin);
            this.Controls.Add(this.numericHoraFin);
            this.Controls.Add(this.numericMinutoInicio);
            this.Controls.Add(this.numericHoraInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericPrecioBase);
            this.Controls.Add(this.numericValorKm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcionTurno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCrearTurno);
            this.Name = "AltaTurnos";
            this.Text = "AltaTurnos";
            ((System.ComponentModel.ISupportInitialize)(this.numericPrecioBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericValorKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoraInicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericPrecioBase;
        private System.Windows.Forms.NumericUpDown numericValorKm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcionTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrearTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericMinutoFin;
        private System.Windows.Forms.NumericUpDown numericHoraFin;
        private System.Windows.Forms.NumericUpDown numericMinutoInicio;
        private System.Windows.Forms.NumericUpDown numericHoraInicio;
        private System.Windows.Forms.Button button1;
    }
}