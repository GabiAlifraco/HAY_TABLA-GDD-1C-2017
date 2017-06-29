namespace UberFrba.Registro_Viajes
{
    partial class AltaViajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaViajes));
            this.listBoxChoferes = new System.Windows.Forms.ListBox();
            this.label29 = new System.Windows.Forms.Label();
            this.listBoxTurnos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuto = new System.Windows.Forms.TextBox();
            this.txtCantidadKm = new System.Windows.Forms.TextBox();
            this.txtFyHinicio = new System.Windows.Forms.MaskedTextBox();
            this.txtFyHfin = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxCliente = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxChoferes
            // 
            this.listBoxChoferes.FormattingEnabled = true;
            this.listBoxChoferes.Location = new System.Drawing.Point(12, 69);
            this.listBoxChoferes.Name = "listBoxChoferes";
            this.listBoxChoferes.Size = new System.Drawing.Size(147, 134);
            this.listBoxChoferes.TabIndex = 74;
            this.listBoxChoferes.SelectedIndexChanged += new System.EventHandler(this.listBoxChoferes_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.LemonChiffon;
            this.label29.Location = new System.Drawing.Point(12, 53);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 13);
            this.label29.TabIndex = 73;
            this.label29.Text = "Chofer";
            // 
            // listBoxTurnos
            // 
            this.listBoxTurnos.FormattingEnabled = true;
            this.listBoxTurnos.Location = new System.Drawing.Point(165, 69);
            this.listBoxTurnos.Name = "listBoxTurnos";
            this.listBoxTurnos.Size = new System.Drawing.Size(162, 134);
            this.listBoxTurnos.TabIndex = 75;
            this.listBoxTurnos.SelectedIndexChanged += new System.EventHandler(this.listBoxTurnos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Location = new System.Drawing.Point(164, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Location = new System.Drawing.Point(330, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Auto";
            // 
            // txtAuto
            // 
            this.txtAuto.Enabled = false;
            this.txtAuto.Location = new System.Drawing.Point(333, 70);
            this.txtAuto.Name = "txtAuto";
            this.txtAuto.Size = new System.Drawing.Size(116, 20);
            this.txtAuto.TabIndex = 78;
            // 
            // txtCantidadKm
            // 
            this.txtCantidadKm.Location = new System.Drawing.Point(205, 227);
            this.txtCantidadKm.Name = "txtCantidadKm";
            this.txtCantidadKm.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadKm.TabIndex = 79;
            this.txtCantidadKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtFyHinicio
            // 
            this.txtFyHinicio.Location = new System.Drawing.Point(205, 266);
            this.txtFyHinicio.Mask = "00/00/0000 00:00";
            this.txtFyHinicio.Name = "txtFyHinicio";
            this.txtFyHinicio.Size = new System.Drawing.Size(100, 20);
            this.txtFyHinicio.TabIndex = 82;
            this.txtFyHinicio.ValidatingType = typeof(System.DateTime);
            this.txtFyHinicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // txtFyHfin
            // 
            this.txtFyHfin.Location = new System.Drawing.Point(205, 302);
            this.txtFyHfin.Mask = "00/00/0000 00:00";
            this.txtFyHfin.Name = "txtFyHfin";
            this.txtFyHfin.Size = new System.Drawing.Size(100, 20);
            this.txtFyHfin.TabIndex = 83;
            this.txtFyHfin.ValidatingType = typeof(System.DateTime);
            this.txtFyHfin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soloNumeros);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.Location = new System.Drawing.Point(118, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Cantidad de km";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LemonChiffon;
            this.label4.Location = new System.Drawing.Point(88, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Fecha y hora de inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.Location = new System.Drawing.Point(101, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Fecha y hora de fin";
            // 
            // listBoxCliente
            // 
            this.listBoxCliente.FormattingEnabled = true;
            this.listBoxCliente.Location = new System.Drawing.Point(455, 70);
            this.listBoxCliente.Name = "listBoxCliente";
            this.listBoxCliente.Size = new System.Drawing.Size(141, 134);
            this.listBoxCliente.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LemonChiffon;
            this.label6.Location = new System.Drawing.Point(452, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Cliente";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(327, 283);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 39);
            this.btnGuardar.TabIndex = 89;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(438, 283);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(91, 39);
            this.btnVolver.TabIndex = 90;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // AltaViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(608, 372);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFyHfin);
            this.Controls.Add(this.txtFyHinicio);
            this.Controls.Add(this.txtCantidadKm);
            this.Controls.Add(this.txtAuto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxTurnos);
            this.Controls.Add(this.listBoxChoferes);
            this.Controls.Add(this.label29);
            this.Name = "AltaViajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaViajes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxChoferes;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ListBox listBoxTurnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuto;
        private System.Windows.Forms.TextBox txtCantidadKm;
        private System.Windows.Forms.MaskedTextBox txtFyHinicio;
        private System.Windows.Forms.MaskedTextBox txtFyHfin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
    }
}