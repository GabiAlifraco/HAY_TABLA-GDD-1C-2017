namespace UberFrba.Listado_Estadistico
{
    partial class frmListadoEstadistico
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btnClientesMayorConsumo = new System.Windows.Forms.Button();
            this.btnChoferConMayorRecaudacion = new System.Windows.Forms.Button();
            this.btnChoferConViajeMasLargo = new System.Windows.Forms.Button();
            this.btnClienteQueMasUtilizoMisimoAuto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(302, 12);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(601, 260);
            this.dgvListado.TabIndex = 3;
            // 
            // btnClientesMayorConsumo
            // 
            this.btnClientesMayorConsumo.Location = new System.Drawing.Point(12, 99);
            this.btnClientesMayorConsumo.Name = "btnClientesMayorConsumo";
            this.btnClientesMayorConsumo.Size = new System.Drawing.Size(284, 23);
            this.btnClientesMayorConsumo.TabIndex = 4;
            this.btnClientesMayorConsumo.Text = "Clientes con mayor consumo";
            this.btnClientesMayorConsumo.UseVisualStyleBackColor = true;
            this.btnClientesMayorConsumo.Click += new System.EventHandler(this.btnClientesMayorConsumo_Click);
            // 
            // btnChoferConMayorRecaudacion
            // 
            this.btnChoferConMayorRecaudacion.Location = new System.Drawing.Point(12, 70);
            this.btnChoferConMayorRecaudacion.Name = "btnChoferConMayorRecaudacion";
            this.btnChoferConMayorRecaudacion.Size = new System.Drawing.Size(284, 23);
            this.btnChoferConMayorRecaudacion.TabIndex = 5;
            this.btnChoferConMayorRecaudacion.Text = " Chóferes con mayor recaudación ";
            this.btnChoferConMayorRecaudacion.UseVisualStyleBackColor = true;
            // 
            // btnChoferConViajeMasLargo
            // 
            this.btnChoferConViajeMasLargo.Location = new System.Drawing.Point(12, 12);
            this.btnChoferConViajeMasLargo.Name = "btnChoferConViajeMasLargo";
            this.btnChoferConViajeMasLargo.Size = new System.Drawing.Size(284, 23);
            this.btnChoferConViajeMasLargo.TabIndex = 6;
            this.btnChoferConViajeMasLargo.Text = "Choferes con el viaje más largo realizado ";
            this.btnChoferConViajeMasLargo.UseVisualStyleBackColor = true;
            // 
            // btnClienteQueMasUtilizoMisimoAuto
            // 
            this.btnClienteQueMasUtilizoMisimoAuto.Location = new System.Drawing.Point(12, 41);
            this.btnClienteQueMasUtilizoMisimoAuto.Name = "btnClienteQueMasUtilizoMisimoAuto";
            this.btnClienteQueMasUtilizoMisimoAuto.Size = new System.Drawing.Size(284, 23);
            this.btnClienteQueMasUtilizoMisimoAuto.TabIndex = 7;
            this.btnClienteQueMasUtilizoMisimoAuto.Text = "Cliente que utilizo más veces el mismo automóvil";
            this.btnClienteQueMasUtilizoMisimoAuto.UseVisualStyleBackColor = true;
            // 
            // frmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 474);
            this.Controls.Add(this.btnClienteQueMasUtilizoMisimoAuto);
            this.Controls.Add(this.btnChoferConViajeMasLargo);
            this.Controls.Add(this.btnChoferConMayorRecaudacion);
            this.Controls.Add(this.btnClientesMayorConsumo);
            this.Controls.Add(this.dgvListado);
            this.Name = "frmListadoEstadistico";
            this.Text = "Listados estadisticos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Button btnClientesMayorConsumo;
        private System.Windows.Forms.Button btnChoferConMayorRecaudacion;
        private System.Windows.Forms.Button btnChoferConViajeMasLargo;
        private System.Windows.Forms.Button btnClienteQueMasUtilizoMisimoAuto;
    }
}