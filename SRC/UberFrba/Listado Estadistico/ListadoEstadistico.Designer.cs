namespace UberFrba.Listado_Estadistico
{
    partial class ListadoEstadistico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTrimestre = new System.Windows.Forms.ComboBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.cbListado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAnio
            // 
            this.nudAnio.BackColor = System.Drawing.Color.LemonChiffon;
            this.nudAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAnio.Location = new System.Drawing.Point(71, 76);
            this.nudAnio.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.ReadOnly = true;
            this.nudAnio.Size = new System.Drawing.Size(115, 26);
            this.nudAnio.TabIndex = 10;
            this.nudAnio.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.nudAnio.ValueChanged += new System.EventHandler(this.nudAnio_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Trimestre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ver TOP 5 de:";
            // 
            // cbTrimestre
            // 
            this.cbTrimestre.BackColor = System.Drawing.Color.LemonChiffon;
            this.cbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrimestre.FormattingEnabled = true;
            this.cbTrimestre.Items.AddRange(new object[] {
            "Enero - Marzo",
            "Abril - Junio",
            "Julio - Septiembre",
            "Octubre - Diciembre"});
            this.cbTrimestre.Location = new System.Drawing.Point(377, 75);
            this.cbTrimestre.Name = "cbTrimestre";
            this.cbTrimestre.Size = new System.Drawing.Size(165, 28);
            this.cbTrimestre.TabIndex = 9;
            this.cbTrimestre.SelectedIndexChanged += new System.EventHandler(this.cbTrimestre_SelectedIndexChanged);
            // 
            // dgvListado
            // 
            this.dgvListado.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(24, 107);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(518, 177);
            this.dgvListado.TabIndex = 8;
            // 
            // cbListado
            // 
            this.cbListado.BackColor = System.Drawing.Color.LemonChiffon;
            this.cbListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListado.FormattingEnabled = true;
            this.cbListado.Items.AddRange(new object[] {
            "Clientes con mayor consumo",
            "Cliente que usó más veces el mismo automovil en sus viajes",
            "Choferes con el viaje más largo realizado",
            "Chóferes con mayor recaudación"});
            this.cbListado.Location = new System.Drawing.Point(24, 43);
            this.cbListado.Name = "cbListado";
            this.cbListado.Size = new System.Drawing.Size(518, 28);
            this.cbListado.TabIndex = 7;
            this.cbListado.SelectedIndexChanged += new System.EventHandler(this.cbListado_SelectedIndexChanged);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(566, 305);
            this.Controls.Add(this.nudAnio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTrimestre);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.cbListado);
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListadoEstadistico";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTrimestre;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.ComboBox cbListado;
    }
}