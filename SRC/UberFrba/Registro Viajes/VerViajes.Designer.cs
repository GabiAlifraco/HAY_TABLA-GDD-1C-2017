namespace UberFrba.Registro_Viajes
{
    partial class VerViajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerViajes));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.cbTrimestre = new System.Windows.Forms.ComboBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(261, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trimestre";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(45, 11);
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
            this.nudAnio.Size = new System.Drawing.Size(80, 20);
            this.nudAnio.TabIndex = 2;
            this.nudAnio.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.nudAnio.ValueChanged += new System.EventHandler(this.nudAnio_ValueChanged);
            // 
            // cbTrimestre
            // 
            this.cbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrimestre.FormattingEnabled = true;
            this.cbTrimestre.Items.AddRange(new object[] {
            "Enero - Marzo",
            "Abril - Junio",
            "Julio - Septiembre",
            "Octubre - Diciembre"});
            this.cbTrimestre.Location = new System.Drawing.Point(318, 11);
            this.cbTrimestre.Name = "cbTrimestre";
            this.cbTrimestre.Size = new System.Drawing.Size(121, 21);
            this.cbTrimestre.TabIndex = 3;
            this.cbTrimestre.SelectedIndexChanged += new System.EventHandler(this.cbTrimestre_SelectedIndexChanged);
            // 
            // dgvListado
            // 
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(16, 56);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(735, 352);
            this.dgvListado.TabIndex = 4;
            // 
            // VerViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(796, 462);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.cbTrimestre);
            this.Controls.Add(this.nudAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VerViajes";
            this.Text = "VerViajes";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.ComboBox cbTrimestre;
        private System.Windows.Forms.DataGridView dgvListado;
    }
}