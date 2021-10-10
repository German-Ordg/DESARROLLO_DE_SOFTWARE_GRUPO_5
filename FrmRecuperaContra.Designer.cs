
namespace Pantallas_proyecto
{
    partial class FrmRecuperaContra
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecuperaContra));
            this.button1 = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtresultado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btncambiar = new System.Windows.Forms.Button();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnverificar = new System.Windows.Forms.Button();
            this.lblnueva = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.chkMostrarContra = new System.Windows.Forms.CheckBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(538, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.BackColor = System.Drawing.Color.Maroon;
            this.btnIngreso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnIngreso.Location = new System.Drawing.Point(538, 146);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(98, 40);
            this.btnIngreso.TabIndex = 2;
            this.btnIngreso.Text = "Recuperar";
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.txtresultado);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 282);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // txtresultado
            // 
            this.txtresultado.Enabled = false;
            this.txtresultado.Location = new System.Drawing.Point(37, 171);
            this.txtresultado.Multiline = true;
            this.txtresultado.Name = "txtresultado";
            this.txtresultado.Size = new System.Drawing.Size(279, 75);
            this.txtresultado.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(34, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Recuperación de Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 62F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(395, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 94);
            this.label2.TabIndex = 7;
            this.label2.Text = "HEAVEN";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // btncambiar
            // 
            this.btncambiar.BackColor = System.Drawing.Color.Maroon;
            this.btncambiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btncambiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncambiar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btncambiar.Location = new System.Drawing.Point(623, 357);
            this.btncambiar.Name = "btncambiar";
            this.btncambiar.Size = new System.Drawing.Size(84, 40);
            this.btncambiar.TabIndex = 6;
            this.btncambiar.Text = "Cambiar Contraseña";
            this.btncambiar.UseVisualStyleBackColor = false;
            this.btncambiar.Visible = false;
            this.btncambiar.Click += new System.EventHandler(this.btncambiar_Click);
            // 
            // txtContrasena
            // 
            this.txtContrasena.BackColor = System.Drawing.Color.White;
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtContrasena.Location = new System.Drawing.Point(477, 360);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(127, 25);
            this.txtContrasena.TabIndex = 5;
            this.txtContrasena.Text = "Contraseña";
            this.txtContrasena.Visible = false;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            this.txtContrasena.Enter += new System.EventHandler(this.txtContrasena_Enter);
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasena_KeyPress);
            this.txtContrasena.Leave += new System.EventHandler(this.txtContrasena_Leave);
            // 
            // btnverificar
            // 
            this.btnverificar.BackColor = System.Drawing.Color.Maroon;
            this.btnverificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnverificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnverificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverificar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnverificar.Location = new System.Drawing.Point(593, 312);
            this.btnverificar.Name = "btnverificar";
            this.btnverificar.Size = new System.Drawing.Size(59, 28);
            this.btnverificar.TabIndex = 4;
            this.btnverificar.Text = "Verificar Codigo";
            this.btnverificar.UseVisualStyleBackColor = false;
            this.btnverificar.Visible = false;
            this.btnverificar.Click += new System.EventHandler(this.btnverificar_Click);
            // 
            // lblnueva
            // 
            this.lblnueva.AutoSize = true;
            this.lblnueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnueva.ForeColor = System.Drawing.Color.White;
            this.lblnueva.Location = new System.Drawing.Point(276, 365);
            this.lblnueva.Name = "lblnueva";
            this.lblnueva.Size = new System.Drawing.Size(194, 13);
            this.lblnueva.TabIndex = 20;
            this.lblnueva.Text = "Introduzca su nueva contraseña:";
            this.lblnueva.Visible = false;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(476, 320);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 3;
            this.txtcodigo.Visible = false;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtcodigo_TextChanged);
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcodigo.ForeColor = System.Drawing.Color.White;
            this.lblcodigo.Location = new System.Drawing.Point(300, 323);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(170, 13);
            this.lblcodigo.TabIndex = 18;
            this.lblcodigo.Text = "Ingrese el codigo del correo:";
            this.lblcodigo.Visible = false;
            // 
            // chkMostrarContra
            // 
            this.chkMostrarContra.AutoSize = true;
            this.chkMostrarContra.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMostrarContra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkMostrarContra.Location = new System.Drawing.Point(482, 394);
            this.chkMostrarContra.Margin = new System.Windows.Forms.Padding(4);
            this.chkMostrarContra.Name = "chkMostrarContra";
            this.chkMostrarContra.Size = new System.Drawing.Size(141, 21);
            this.chkMostrarContra.TabIndex = 21;
            this.chkMostrarContra.Text = "Mostrar Contraseña";
            this.chkMostrarContra.UseVisualStyleBackColor = true;
            this.chkMostrarContra.CheckedChanged += new System.EventHandler(this.chkMostrarContra_CheckedChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(124, 109);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(192, 20);
            this.txtUsuario.TabIndex = 22;
            // 
            // FrmRecuperaContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(787, 431);
            this.Controls.Add(this.chkMostrarContra);
            this.Controls.Add(this.btncambiar);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnverificar);
            this.Controls.Add(this.lblnueva);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(803, 470);
            this.MinimumSize = new System.Drawing.Size(803, 470);
            this.Name = "FrmRecuperaContra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperar Contraseña";
            this.Load += new System.EventHandler(this.FrmRecuperaContra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtresultado;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Button btncambiar;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnverificar;
        private System.Windows.Forms.Label lblnueva;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.CheckBox chkMostrarContra;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}