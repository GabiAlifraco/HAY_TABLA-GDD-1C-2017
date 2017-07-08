namespace UberFrba.Facturacion
{
    partial class frmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantKms = new System.Windows.Forms.TextBox();
            this.txtCantidadViajes = new System.Windows.Forms.TextBox();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.listBoxCliente = new System.Windows.Forms.ListBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fecha_inicio = new System.Windows.Forms.Label();
            this.fecha_fin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Location = new System.Drawing.Point(36, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Cliente:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvFactura
            // 
            this.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactura.Location = new System.Drawing.Point(240, 66);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.Size = new System.Drawing.Size(364, 331);
            this.dgvFactura.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.Location = new System.Drawing.Point(240, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Viajes Faturados";
            // 
            // txtCantKms
            // 
            this.txtCantKms.Enabled = false;
            this.txtCantKms.Location = new System.Drawing.Point(240, 401);
            this.txtCantKms.Name = "txtCantKms";
            this.txtCantKms.Size = new System.Drawing.Size(136, 20);
            this.txtCantKms.TabIndex = 89;
            // 
            // txtCantidadViajes
            // 
            this.txtCantidadViajes.Enabled = false;
            this.txtCantidadViajes.Location = new System.Drawing.Point(240, 453);
            this.txtCantidadViajes.Name = "txtCantidadViajes";
            this.txtCantidadViajes.Size = new System.Drawing.Size(364, 20);
            this.txtCantidadViajes.TabIndex = 90;
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Enabled = false;
            this.txtImporteTotal.Location = new System.Drawing.Point(240, 427);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(136, 20);
            this.txtImporteTotal.TabIndex = 91;
            // 
            // listBoxCliente
            // 
            this.listBoxCliente.FormattingEnabled = true;
            this.listBoxCliente.Location = new System.Drawing.Point(39, 69);
            this.listBoxCliente.Name = "listBoxCliente";
            this.listBoxCliente.Size = new System.Drawing.Size(187, 329);
            this.listBoxCliente.TabIndex = 92;
            this.listBoxCliente.SelectedIndexChanged += new System.EventHandler(this.listBoxCliente_SelectedIndexChanged);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(39, 401);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(187, 46);
            this.btnFacturar.TabIndex = 93;
            this.btnFacturar.Text = "FACTURAR";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(619, 63);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(272, 334);
            this.richTextBox1.TabIndex = 94;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.Location = new System.Drawing.Point(616, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 95;
            this.label5.Text = "Ayuda:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(382, 401);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(108, 46);
            this.btnConfirmar.TabIndex = 96;
            this.btnConfirmar.Text = "CONFIRMAR FACTURA";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Visible = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(496, 401);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 46);
            this.btnCancelar.TabIndex = 97;
            this.btnCancelar.Text = "CANCELAR FACTURA";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.TabIndex = 98;
            this.label1.Text = "Facturacion del mes en curso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LemonChiffon;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 99;
            this.label4.Text = "Fecha de Inicio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LemonChiffon;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(615, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 100;
            this.label6.Text = "Fecha de Fin:";
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.AutoSize = true;
            this.fecha_inicio.BackColor = System.Drawing.Color.LemonChiffon;
            this.fecha_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha_inicio.Location = new System.Drawing.Point(422, 18);
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Size = new System.Drawing.Size(91, 20);
            this.fecha_inicio.TabIndex = 101;
            this.fecha_inicio.Text = "FechaInicio";
            // 
            // fecha_fin
            // 
            this.fecha_fin.AutoSize = true;
            this.fecha_fin.BackColor = System.Drawing.Color.LemonChiffon;
            this.fecha_fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha_fin.Location = new System.Drawing.Point(727, 18);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(76, 20);
            this.fecha_fin.TabIndex = 102;
            this.fecha_fin.Text = "FechaFin";
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(936, 507);
            this.Controls.Add(this.fecha_fin);
            this.Controls.Add(this.fecha_inicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.listBoxCliente);
            this.Controls.Add(this.txtImporteTotal);
            this.Controls.Add(this.txtCantidadViajes);
            this.Controls.Add(this.txtCantKms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvFactura);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantKms;
        private System.Windows.Forms.TextBox txtCantidadViajes;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.ListBox listBoxCliente;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label fecha_inicio;
        private System.Windows.Forms.Label fecha_fin;
    }
}