namespace UberFrba.Abm_Rol
{
    partial class AbmRol
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
            this.panelAbmRol = new System.Windows.Forms.Panel();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnAltaDeRol = new System.Windows.Forms.Button();
            this.panelDatosRol = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.txtIdSeleccionado = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tbNombreRol = new System.Windows.Forms.TextBox();
            this.clbFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAbmRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.panelDatosRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAbmRol
            // 
            this.panelAbmRol.Controls.Add(this.btnModificar);
            this.panelAbmRol.Controls.Add(this.dgvRoles);
            this.panelAbmRol.Controls.Add(this.btnAltaDeRol);
            this.panelAbmRol.Location = new System.Drawing.Point(12, 12);
            this.panelAbmRol.Name = "panelAbmRol";
            this.panelAbmRol.Size = new System.Drawing.Size(351, 284);
            this.panelAbmRol.TabIndex = 12;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(108, 196);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(27, 21);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.Size = new System.Drawing.Size(235, 125);
            this.dgvRoles.TabIndex = 1;
            this.dgvRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellClick);
            // 
            // btnAltaDeRol
            // 
            this.btnAltaDeRol.Location = new System.Drawing.Point(27, 203);
            this.btnAltaDeRol.Name = "btnAltaDeRol";
            this.btnAltaDeRol.Size = new System.Drawing.Size(75, 23);
            this.btnAltaDeRol.TabIndex = 0;
            this.btnAltaDeRol.Text = "AltaDeRol";
            this.btnAltaDeRol.UseVisualStyleBackColor = true;
            this.btnAltaDeRol.Click += new System.EventHandler(this.btnAltaDeRol_Click_1);
            // 
            // panelDatosRol
            // 
            this.panelDatosRol.Controls.Add(this.label26);
            this.panelDatosRol.Controls.Add(this.txtIdSeleccionado);
            this.panelDatosRol.Controls.Add(this.btnGuardar);
            this.panelDatosRol.Controls.Add(this.tbNombreRol);
            this.panelDatosRol.Controls.Add(this.clbFuncionalidades);
            this.panelDatosRol.Controls.Add(this.label2);
            this.panelDatosRol.Controls.Add(this.label1);
            this.panelDatosRol.Location = new System.Drawing.Point(399, 12);
            this.panelDatosRol.Name = "panelDatosRol";
            this.panelDatosRol.Size = new System.Drawing.Size(339, 324);
            this.panelDatosRol.TabIndex = 11;
            this.panelDatosRol.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.LemonChiffon;
            this.label26.Location = new System.Drawing.Point(75, 38);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(16, 13);
            this.label26.TabIndex = 81;
            this.label26.Text = "Id";
            // 
            // txtIdSeleccionado
            // 
            this.txtIdSeleccionado.Enabled = false;
            this.txtIdSeleccionado.Location = new System.Drawing.Point(116, 38);
            this.txtIdSeleccionado.Name = "txtIdSeleccionado";
            this.txtIdSeleccionado.Size = new System.Drawing.Size(67, 20);
            this.txtIdSeleccionado.TabIndex = 80;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(11, 260);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tbNombreRol
            // 
            this.tbNombreRol.Location = new System.Drawing.Point(116, 64);
            this.tbNombreRol.Name = "tbNombreRol";
            this.tbNombreRol.Size = new System.Drawing.Size(110, 20);
            this.tbNombreRol.TabIndex = 7;
            // 
            // clbFuncionalidades
            // 
            this.clbFuncionalidades.FormattingEnabled = true;
            this.clbFuncionalidades.Location = new System.Drawing.Point(116, 96);
            this.clbFuncionalidades.Name = "clbFuncionalidades";
            this.clbFuncionalidades.Size = new System.Drawing.Size(200, 154);
            this.clbFuncionalidades.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funcionalidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre del Rol";
            // 
            // AbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 440);
            this.Controls.Add(this.panelAbmRol);
            this.Controls.Add(this.panelDatosRol);
            this.Name = "AbmRol";
            this.Text = "Form1";
            this.panelAbmRol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.panelDatosRol.ResumeLayout(false);
            this.panelDatosRol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAbmRol;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnAltaDeRol;
        private System.Windows.Forms.Panel panelDatosRol;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtIdSeleccionado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox tbNombreRol;
        private System.Windows.Forms.CheckedListBox clbFuncionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}