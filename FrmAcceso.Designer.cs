
namespace Pantallas_proyecto
{
    partial class FrmAcceso
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcceso));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.chkMostrarContra = new System.Windows.Forms.CheckBox();
            this.picError = new System.Windows.Forms.PictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.txtContrasena);
            this.groupBox1.Controls.Add(this.chkMostrarContra);
            this.groupBox1.Controls.Add(this.picError);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(357, 341);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtUsuario.Location = new System.Drawing.Point(152, 102);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(127, 25);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtContrasena.Location = new System.Drawing.Point(152, 159);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasena.MaxLength = 50;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(127, 25);
            this.txtContrasena.TabIndex = 2;
            this.txtContrasena.Text = "Contraseña";
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            this.txtContrasena.Enter += new System.EventHandler(this.txtContrasena_Enter);
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasena_KeyPress);
            this.txtContrasena.Leave += new System.EventHandler(this.txtContrasena_Leave);
            // 
            // chkMostrarContra
            // 
            this.chkMostrarContra.AutoSize = true;
            this.chkMostrarContra.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMostrarContra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkMostrarContra.Location = new System.Drawing.Point(152, 201);
            this.chkMostrarContra.Margin = new System.Windows.Forms.Padding(4);
            this.chkMostrarContra.Name = "chkMostrarContra";
            this.chkMostrarContra.Size = new System.Drawing.Size(141, 21);
            this.chkMostrarContra.TabIndex = 6;
            this.chkMostrarContra.Text = "Mostrar Contraseña";
            this.chkMostrarContra.UseVisualStyleBackColor = true;
            this.chkMostrarContra.CheckedChanged += new System.EventHandler(this.chkMostrarContra_CheckedChanged);
            // 
            // picError
            // 
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(32, 290);
            this.picError.Margin = new System.Windows.Forms.Padding(4);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(20, 20);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picError.TabIndex = 17;
            this.picError.TabStop = false;
            this.picError.Visible = false;
          
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(70, 295);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(37, 16);
            this.lblError.TabIndex = 16;
            this.lblError.Text = "label2";
            this.lblError.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Usuario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(30, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 39);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bienvenido";
            // 
            // btnIngreso
            // 
            this.btnIngreso.BackColor = System.Drawing.Color.Maroon;
            this.btnIngreso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnIngreso.Location = new System.Drawing.Point(65, 386);
            this.btnIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(98, 40);
            this.btnIngreso.TabIndex = 3;
            this.btnIngreso.Text = "Ingresar";
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackColor = System.Drawing.Color.Maroon;
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecuperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecuperar.Location = new System.Drawing.Point(289, 386);
            this.btnRecuperar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(234, 40);
            this.btnRecuperar.TabIndex = 4;
            this.btnRecuperar.Text = "Recuperar Contraseña";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Maroon;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.Location = new System.Drawing.Point(674, 386);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(99, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(403, 135);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(295, 29);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Martes 8 de Junio de 2021";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(508, 192);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(71, 29);
            this.lblHora.TabIndex = 7;
            this.lblHora.Text = "12:47";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pantallas_proyecto.Properties.Resources.Letras1;
            this.pictureBox1.Location = new System.Drawing.Point(392, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(557, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 50);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(818, 466);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(834, 505);
            this.MinimumSize = new System.Drawing.Size(834, 505);
            this.Name = "FrmAcceso";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heaven Store";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.CheckBox chkMostrarContra;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Label lblError;
        public System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}

