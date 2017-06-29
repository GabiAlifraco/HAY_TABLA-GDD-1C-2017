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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmRol));
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkVerInhabilitados = new System.Windows.Forms.CheckBox();
            this.panelAbmRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.panelDatosRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAbmRol
            // 
            this.panelAbmRol.BackColor = System.Drawing.Color.Transparent;
            this.panelAbmRol.Controls.Add(this.checkVerInhabilitados);
            this.panelAbmRol.Controls.Add(this.button2);
            this.panelAbmRol.Controls.Add(this.btnModificar);
            this.panelAbmRol.Controls.Add(this.dgvRoles);
            this.panelAbmRol.Controls.Add(this.btnAltaDeRol);
            this.panelAbmRol.Location = new System.Drawing.Point(40, 36);
            this.panelAbmRol.Name = "panelAbmRol";
            this.panelAbmRol.Size = new System.Drawing.Size(351, 284);
            this.panelAbmRol.TabIndex = 12;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(127, 197);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(89, 30);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(42, 30);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.Size = new System.Drawing.Size(261, 161);
            this.dgvRoles.TabIndex = 1;
            this.dgvRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellClick);
            // 
            // btnAltaDeRol
            // 
            this.btnAltaDeRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaDeRol.Location = new System.Drawing.Point(32, 198);
            this.btnAltaDeRol.Name = "btnAltaDeRol";
            this.btnAltaDeRol.Size = new System.Drawing.Size(89, 28);
            this.btnAltaDeRol.TabIndex = 0;
            this.btnAltaDeRol.Text = "Alta";
            this.btnAltaDeRol.UseVisualStyleBackColor = true;
            this.btnAltaDeRol.Click += new System.EventHandler(this.btnAltaDeRol_Click_1);
            // 
            // panelDatosRol
            // 
            this.panelDatosRol.BackColor = System.Drawing.Color.Transparent;
            this.panelDatosRol.Controls.Add(this.button1);
            this.panelDatosRol.Controls.Add(this.label26);
            this.panelDatosRol.Controls.Add(this.txtIdSeleccionado);
            this.panelDatosRol.Controls.Add(this.btnGuardar);
            this.panelDatosRol.Controls.Add(this.tbNombreRol);
            this.panelDatosRol.Controls.Add(this.clbFuncionalidades);
            this.panelDatosRol.Controls.Add(this.label2);
            this.panelDatosRol.Controls.Add(this.label1);
            this.panelDatosRol.Location = new System.Drawing.Point(27, 12);
            this.panelDatosRol.Name = "panelDatosRol";
            this.panelDatosRol.Size = new System.Drawing.Size(375, 324);
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
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(226, 256);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 34);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Aceptar";
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
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.Location = new System.Drawing.Point(7, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funcionalidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.Location = new System.Drawing.Point(11, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre del Rol";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(82, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 34);
            this.button1.TabIndex = 82;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(225, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "Inhabilitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkVerInhabilitados
            // 
            this.checkVerInhabilitados.AutoSize = true;
            this.checkVerInhabilitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVerInhabilitados.Location = new System.Drawing.Point(23, 3);
            this.checkVerInhabilitados.Name = "checkVerInhabilitados";
            this.checkVerInhabilitados.Size = new System.Drawing.Size(147, 24);
            this.checkVerInhabilitados.TabIndex = 11;
            this.checkVerInhabilitados.Text = "Ver Inhabilitados";
            this.checkVerInhabilitados.UseVisualStyleBackColor = true;
            this.checkVerInhabilitados.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(435, 355);
            this.Controls.Add(this.panelAbmRol);
            this.Controls.Add(this.panelDatosRol);
            this.Name = "AbmRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AbmRol";
            this.panelAbmRol.ResumeLayout(false);
            this.panelAbmRol.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkVerInhabilitados;

    }
}