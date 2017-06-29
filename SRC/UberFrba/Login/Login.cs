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
using UberFrba.Abm_Turno;
using UberFrba.Abm_Cliente;
using UberFrba.Menu;

namespace UberFrba.Login
{
    public partial class Login : Form
    {
        private TextBox user_txt;
        private Button iniciar_btn;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private TextBox password_txt;

        public DBAccess Access { get; set; }
        public System.Byte[] Contraseña { get; set; }
        public int Intentos { get; set; }
        public string id_Usuario { get; set; }
        private List<KeyValuePair<string, int>> listRoles = new List<KeyValuePair<string, int>>()
        {
        };

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
                    string query = String.Format("UPDATE [HAY_TABLA].[Usuarios] " +
                                                 "SET Usu_IntentosFallidos = 0 WHERE Usu_Username = @UserName");
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
                    string query = String.Format("UPDATE [HAY_TABLA].[Usuarios] " +
                                                 "SET Usu_IntentosFallidos = @Intentos WHERE Usu_Username = @UserName");
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
                    string query = String.Format("UPDATE [HAY_TABLA].[Usuarios] " +
                                                 "SET Usu_IntentosFallidos = @Intentos WHERE Usu_Username = @UserName");
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

        private void IngresarAlSistema(byte[] contraseña_real, string id_Usuario,string contraseña_a_verificar)
        {
            if (CompararContraseña(contraseña_real, password_txt.Text))
            {
                ResetearIntentosDeIngreso();

                 using (SqlConnection conexion = new SqlConnection(Access.Conexion))
                {
                    string query;
                    string query2;
                    string query3;
                    query = String.Format("SELECT COUNT(*) FROM [HAY_TABLA].[USUARIO_POR_ROL] AS UR INNER JOIN [HAY_TABLA].[ROL] AS R ON R.Id_Rol = UR.Id_Rol WHERE UR.Nombre_Usuario ='" + user_txt.Text + "' AND UR.Habilitado = 1");
                    query2 = String.Format("SELECT UR.[Id_Rol], R.Id_Rol, R.Nombre FROM [HAY_TABLA].[USUARIO_POR_ROL] AS UR INNER JOIN [HAY_TABLA].[ROL] AS R ON R.Id_Rol = UR.Id_Rol  WHERE UR.Nombre_Usuario =" + "'" + user_txt.Text + "'" + "AND UR.Habilitado = 1");
                    query3 = String.Format("SELECT R.Id_Rol FROM [HAY_TABLA].[USUARIO_POR_ROL] AS UR INNER JOIN [HAY_TABLA].[ROL] AS R ON R.Id_Rol = UR.Id_Rol  WHERE UR.Nombre_Usuario =" + "'" + user_txt.Text + "'" + "AND UR.Habilitado = 1");
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    Int32 cantidadDeRoles = (Int32)cmd.ExecuteScalar();
                    SqlCommand cmd2 = new SqlCommand(query2, conexion);
                    SqlCommand cmd3 = new SqlCommand(query3, conexion);
                    Int32 RolquePosee = (Int32)cmd3.ExecuteScalar();

                    if (cantidadDeRoles > 1)
                    {
                        MenuGeneral formularioMenu = new MenuGeneral(id_Usuario, user_txt.Text);
                        formularioMenu.Show();
                    }
                    else
                    {
                        try
                        {
                            SqlDataReader dr = cmd2.ExecuteReader();
                            while (dr.Read())
                            {
                                listRoles.Add((new KeyValuePair<string, int>(dr["Nombre"].ToString(), (int)dr["Id_Rol"])));
                            }
                            MenuFuncionesDelRol formularioMenuFuncionesRol = new MenuFuncionesDelRol(id_Usuario, listRoles[0].Value);
                            formularioMenuFuncionesRol.Show();
                        }
                        catch (Exception excep)
                        {
                            MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                this.Hide();
            }
            else
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // user_txt
            // 
            this.user_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.user_txt.Location = new System.Drawing.Point(135, 113);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(299, 20);
            this.user_txt.TabIndex = 13;
            // 
            // iniciar_btn
            // 
            this.iniciar_btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.iniciar_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.iniciar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciar_btn.Location = new System.Drawing.Point(228, 189);
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
            this.label1.Location = new System.Drawing.Point(24, 113);
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
            this.label3.Location = new System.Drawing.Point(2, 154);
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
            this.password_txt.Location = new System.Drawing.Point(135, 163);
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '•';
            this.password_txt.Size = new System.Drawing.Size(299, 20);
            this.password_txt.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(29, 189);
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
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(494, 259);
            this.Controls.Add(this.iniciar_btn);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password_txt);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
                string query = String.Format("SELECT Usu_Id, Usu_Username, Usu_Password, Usu_IntentosFallidos FROM [HAY_TABLA].[Usuarios] WHERE Usu_Username = @UserName");
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
                    id_Usuario = dr["Usu_Username"].ToString();
                    Contraseña = (System.Byte[])dr.GetValue(2);
                    Intentos = Convert.ToInt16(dr["Usu_IntentosFallidos"].ToString());
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Intentos > 3)
            {
                MessageBox.Show("La cuenta no esta habilitada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
            IngresarAlSistema(Contraseña,id_Usuario,password_txt.Text);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}