
namespace Pantallas_proyecto
{
    partial class FrmInventario_Gerente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario_Gerente));
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dtgInventarioGerente = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.CBBusqueda = new System.Windows.Forms.ComboBox();
            this.txtIngreso = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventarioGerente)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Maroon;
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRegresar.Location = new System.Drawing.Point(614, 28);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(92, 29);
            this.btnRegresar.TabIndex = 33;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.button4_Click);
            // 
            // dtgInventarioGerente
            // 
            this.dtgInventarioGerente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInventarioGerente.Location = new System.Drawing.Point(17, 155);
            this.dtgInventarioGerente.Name = "dtgInventarioGerente";
            this.dtgInventarioGerente.ReadOnly = true;
            this.dtgInventarioGerente.RowHeadersWidth = 51;
            this.dtgInventarioGerente.Size = new System.Drawing.Size(706, 245);
            this.dtgInventarioGerente.TabIndex = 30;
            this.dtgInventarioGerente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 62F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(168, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 94);
            this.label2.TabIndex = 27;
            this.label2.Text = "HEAVEN";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Maroon;
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificar.Location = new System.Drawing.Point(614, 102);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(92, 29);
            this.btnModificar.TabIndex = 35;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 406);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(733, 25);
            this.toolStrip1.TabIndex = 36;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Búsqueda Por:";
            // 
            // CBBusqueda
            // 
            this.CBBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBusqueda.FormattingEnabled = true;
            this.CBBusqueda.Items.AddRange(new object[] {
            "Codigo",
            "Categoria"});
            this.CBBusqueda.Location = new System.Drawing.Point(170, 113);
            this.CBBusqueda.Name = "CBBusqueda";
            this.CBBusqueda.Size = new System.Drawing.Size(109, 21);
            this.CBBusqueda.TabIndex = 38;
            this.CBBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtIngreso
            // 
            this.txtIngreso.Location = new System.Drawing.Point(301, 115);
            this.txtIngreso.Name = "txtIngreso";
            this.txtIngreso.Size = new System.Drawing.Size(206, 20);
            this.txtIngreso.TabIndex = 29;
            this.txtIngreso.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FrmInventario_Gerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(733, 431);
            this.Controls.Add(this.CBBusqueda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dtgInventarioGerente);
            this.Controls.Add(this.txtIngreso);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(749, 470);
            this.MinimumSize = new System.Drawing.Size(749, 470);
            this.Name = "FrmInventario_Gerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heaven Store - Inventario";
            this.Load += new System.EventHandler(this.FrmInventario_Gerente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventarioGerente)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DataGridView dtgInventarioGerente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBBusqueda;
        private System.Windows.Forms.TextBox txtIngreso;
    }
}