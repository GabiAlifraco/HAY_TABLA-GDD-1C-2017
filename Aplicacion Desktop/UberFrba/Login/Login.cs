using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace UberFrba.Login
{
    public partial class Login : Form
    {
        private TextBox user_txt;
        private Button iniciar_btn;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label2;
        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private TextBox password_txt;

        public DBAccess Access { get; set; }
        public byte[] Contraseña { get; set; }
        public bool Estado { get; set; }
        public int Intentos { get; set; }

        public Login()
        {
            InitializeComponent();
            Access = new DBAccess();
        }

        bool CompararContraseña(byte[] a1, string contraseña)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(contraseña);
            byte[] a2 = provider.ComputeHash(inputBytes);

            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

        private void ResetearIntentosDeIngreso()
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string query = String.Format("UPDATE [GD1C2017].[UN_CORTADO].[USUARIOS] " +
                                                 "SET Cantidad_Intentos = 0 WHERE Nombre_Usuario = @UserName");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void SumarIntentosFallidos(int intentos)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string query = String.Format("UPDATE [GD1C2017].[UN_CORTADO].[USUARIOS] " +
                                                 "SET Cantidad_Intentos = @Intentos WHERE Nombre_Usuario = @UserName");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Intentos", intentos);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Contraseña no válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void InhabilitarCuenta(int intentos)
        {
            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                conexion.Open();
                SqlTransaction transaction = conexion.BeginTransaction();
                SqlCommand command = conexion.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    string query = String.Format("UPDATE [GD1C2017].[UN_CORTADO].[USUARIOS] " +
                                                 "SET Habilitado = 0, Cantidad_Intentos = @Intentos WHERE Nombre_Usuario = @UserName");
                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    command.Parameters.Add(param);

                    param = new SqlParameter("@Intentos", intentos);
                    param.SqlDbType = System.Data.SqlDbType.TinyInt;
                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Su cuenta ha sido inhabilitada por demasiados intentos fallidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Dispose();
                }
            }
        }

        private void IngresarAlSistema(byte[] contraseña, bool estado)
        {
            if (CompararContraseña(contraseña, password_txt.Text))
            {
                MessageBox.Show("Bienvenido/a" + " " + user_txt.Text, "EXITO");
               // Roles.Rol roles = new Roles.Rol(user_txt.Text);
                this.Hide();
                //roles.ShowDialog();
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.user_txt = new System.Windows.Forms.TextBox();
            this.iniciar_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // user_txt
            // 
            this.user_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_txt.Location = new System.Drawing.Point(172, 113);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(407, 20);
            this.user_txt.TabIndex = 13;
            // 
            // iniciar_btn
            // 
            this.iniciar_btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.iniciar_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.iniciar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciar_btn.Location = new System.Drawing.Point(373, 196);
            this.iniciar_btn.Name = "iniciar_btn";
            this.iniciar_btn.Size = new System.Drawing.Size(206, 56);
            this.iniciar_btn.TabIndex = 15;
            this.iniciar_btn.Text = "Iniciar Sesión";
            this.iniciar_btn.UseVisualStyleBackColor = false;
            this.iniciar_btn.Click += new System.EventHandler(this.iniciar_btn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Contraseña";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // password_txt
            // 
            this.password_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_txt.Location = new System.Drawing.Point(172, 163);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '•';
            this.password_txt.Size = new System.Drawing.Size(407, 20);
            this.password_txt.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(172, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 26);
            this.label2.TabIndex = 19;
            this.label2.Text = "No tenes cuenta aun? Registrate gratis ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(444, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 37);
            this.button1.TabIndex = 20;
            this.button1.Text = "AQUÍ";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(369, 310);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(274, 196);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 56);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // Login
            // 
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(639, 359);
            this.Controls.Add(this.iniciar_btn);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password_txt);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void iniciar_btn_Click(object sender, EventArgs e)
        {
            if (user_txt.Text.Equals(""))
            {
                MessageBox.Show("El usuario no puede quedar vacio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password_txt.Text.Equals(""))
            {
                MessageBox.Show("La contraseña no puede quedar vacia", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(Access.Conexion))
            {
                string query = String.Format("SELECT u.Nombre_Usuario, u.Contraseña, u.Habilitado, u.Cantidad_Intentos FROM [GD1C2017].[UN_CORTADO].[USUARIOS] u " +
                                             "INNER JOIN [GD1C2017].[UN_CORTADO].[ROLPORUSUARIO] rxu " +
                                             "ON u.Nombre_Usuario = rxu.Nombre_Usuario " +
                                             "INNER JOIN [GD1C2017].[UN_CORTADO].[ROLES] r " +
                                             "ON r.Id = rxu.Id_Rol " +
                                             "WHERE u.Nombre_Usuario = @UserName");

                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlParameter param = new SqlParameter("@UserName", user_txt.Text);
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                cmd.Parameters.Add(param);

                try
                {
                    conexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.Read())
                    {
                        MessageBox.Show("Acceso denegado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        user_txt.Text = "";
                        password_txt.Text = "";
                        user_txt.Focus();

                        return;
                    }

                    Contraseña = (byte[])dr.GetValue(1);
                    Estado = dr.GetBoolean(2);
                    Intentos = dr.GetInt16(3);
                }
                catch
                {

                }
            }

            if (!Estado)
            {
                MessageBox.Show("La cuenta no esta habilitada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(CompararContraseña(Contraseña, password_txt.Text)))
            {
                Intentos++;
                if (Intentos == 3)
                    InhabilitarCuenta(Intentos);
                else
                    SumarIntentosFallidos(Intentos);

                password_txt.Text = "";
                password_txt.Focus();
                return;
            }
            else
            {
                ResetearIntentosDeIngreso();
            }

            IngresarAlSistema(Contraseña, Estado);               
        }

    }
}