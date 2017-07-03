namespace UberFrba.Rendicion_Viajes
{
    partial class frmRendicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRendicion));
            this.dgvRendicion = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFechaRendicion = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxTurnos = new System.Windows.Forms.ListBox();
            this.listBoxChoferes = new System.Windows.Forms.ListBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRendicion = new System.Windows.Forms.Button();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.txtCantidadViajes = new System.Windows.Forms.TextBox();
            this.txtCantKms = new System.Windows.Forms.TextBox();
            this.txtPorcentajeDePago = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRendicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentajeDePago)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRendicion
            // 
            this.dgvRendicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRendicion.Location = new System.Drawing.Point(406, 40);
            this.dgvRendicion.Name = "dgvRendicion";
            this.dgvRendicion.Size = new System.Drawing.Size(381, 331);
            this.dgvRendicion.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.Location = new System.Drawing.Point(790, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "Ayuda:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(793, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(272, 334);
            this.richTextBox1.TabIndex = 96;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LemonChiffon;
            this.label14.Location = new System.Drawing.Point(53, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 99;
            this.label14.Text = "Fecha:";
            // 
            // txtFechaRendicion
            // 
            this.txtFechaRendicion.Location = new System.Drawing.Point(97, 234);
            this.txtFechaRendicion.Mask = "00/00/0000";
            this.txtFechaRendicion.Name = "txtFechaRendicion";
            this.txtFechaRendicion.Size = new System.Drawing.Size(68, 20);
            this.txtFechaRendicion.TabIndex = 98;
            this.txtFechaRendicion.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Location = new System.Drawing.Point(205, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 108;
            this.label1.Text = "Turno";
            // 
            // listBoxTurnos
            // 
            this.listBoxTurnos.FormattingEnabled = true;
            this.listBoxTurnos.Location = new System.Drawing.Point(208, 71);
            this.listBoxTurnos.Name = "listBoxTurnos";
            this.listBoxTurnos.Size = new System.Drawing.Size(147, 134);
            this.listBoxTurnos.TabIndex = 107;
            // 
            // listBoxChoferes
            // 
            this.listBoxChoferes.FormattingEnabled = true;
            this.listBoxChoferes.Location = new System.Drawing.Point(53, 71);
            this.listBoxChoferes.Name = "listBoxChoferes";
            this.listBoxChoferes.Size = new System.Drawing.Size(147, 134);
            this.listBoxChoferes.TabIndex = 106;
            this.listBoxChoferes.SelectedIndexChanged += new System.EventHandler(this.listBoxChoferes_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.LemonChiffon;
            this.label29.Location = new System.Drawing.Point(53, 55);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 13);
            this.label29.TabIndex = 105;
            this.label29.Text = "Chofer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.Location = new System.Drawing.Point(205, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "Porcentaje de pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Location = new System.Drawing.Point(403, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 111;
            this.label2.Text = "Viajes de la rendicion";
            // 
            // btnRendicion
            // 
            this.btnRendicion.Location = new System.Drawing.Point(125, 293);
            this.btnRendicion.Name = "btnRendicion";
            this.btnRendicion.Size = new System.Drawing.Size(149, 59);
            this.btnRendicion.TabIndex = 112;
            this.btnRendicion.Text = "HACER RENDICION";
            this.btnRendicion.UseVisualStyleBackColor = true;
            this.btnRendicion.Click += new System.EventHandler(this.btnRendicion_Click);
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Enabled = false;
            this.txtImporteTotal.Location = new System.Drawing.Point(406, 403);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(136, 20);
            this.txtImporteTotal.TabIndex = 115;
            // 
            // txtCantidadViajes
            // 
            this.txtCantidadViajes.Enabled = false;
            this.txtCantidadViajes.Location = new System.Drawing.Point(406, 429);
            this.txtCantidadViajes.Name = "txtCantidadViajes";
            this.txtCantidadViajes.Size = new System.Drawing.Size(381, 20);
            this.txtCantidadViajes.TabIndex = 114;
            // 
            // txtCantKms
            // 
            this.txtCantKms.Enabled = false;
            this.txtCantKms.Location = new System.Drawing.Point(406, 377);
            this.txtCantKms.Name = "txtCantKms";
            this.txtCantKms.Size = new System.Drawing.Size(136, 20);
            this.txtCantKms.TabIndex = 113;
            // 
            // txtPorcentajeDePago
            // 
            this.txtPorcentajeDePago.DecimalPlaces = 2;
            this.txtPorcentajeDePago.Location = new System.Drawing.Point(311, 235);
            this.txtPorcentajeDePago.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtPorcentajeDePago.MinimumSize = new System.Drawing.Size(2, 0);
            this.txtPorcentajeDePago.Name = "txtPorcentajeDePago";
            this.txtPorcentajeDePago.Size = new System.Drawing.Size(55, 20);
            this.txtPorcentajeDePago.TabIndex = 116;
            // 
            // frmRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1073, 502);
            this.Controls.Add(this.txtPorcentajeDePago);
            this.Controls.Add(this.txtImporteTotal);
            this.Controls.Add(this.txtCantidadViajes);
            this.Controls.Add(this.txtCantKms);
            this.Controls.Add(this.btnRendicion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxTurnos);
            this.Controls.Add(this.listBoxChoferes);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtFechaRendicion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dgvRendicion);
            this.MaximizeBox = false;
            this.Name = "frmRendicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRendicion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRendicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentajeDePago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRendicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtFechaRendicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxTurnos;
        private System.Windows.Forms.ListBox listBoxChoferes;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRendicion;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.TextBox txtCantidadViajes;
        private System.Windows.Forms.TextBox txtCantKms;
        private System.Windows.Forms.NumericUpDown txtPorcentajeDePago;
    }
}