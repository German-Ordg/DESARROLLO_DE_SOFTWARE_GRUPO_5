
namespace Pantallas_proyecto
{
    partial class frmBitacora
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBitacora));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dgvbitacora = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnregresar = new System.Windows.Forms.Button();
            this.mostrar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.impresion_bitacoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbitacora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.impresion_bitacoraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Controls.Add(this.dgvbitacora);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1252, 431);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.impresion_bitacoraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Pantallas_proyecto.report_bitacora.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 18);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1246, 410);
            this.reportViewer1.TabIndex = 2;
            // 
            // dgvbitacora
            // 
            this.dgvbitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbitacora.Location = new System.Drawing.Point(654, 55);
            this.dgvbitacora.Name = "dgvbitacora";
            this.dgvbitacora.RowHeadersWidth = 51;
            this.dgvbitacora.RowTemplate.Height = 24;
            this.dgvbitacora.Size = new System.Drawing.Size(518, 232);
            this.dgvbitacora.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(161, 145);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(225, 22);
            this.dateTimePicker2.TabIndex = 68;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(555, 95);
            this.cmbVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(225, 24);
            this.cmbVendedor.TabIndex = 66;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 97);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(225, 22);
            this.dateTimePicker1.TabIndex = 67;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(62, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 71;
            this.label4.Text = "Fecha hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(467, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 70;
            this.label3.Text = "Empleado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(58, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "Fecha desde:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pantallas_proyecto.Properties.Resources.Letras1;
            this.pictureBox1.Location = new System.Drawing.Point(469, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // btnregresar
            // 
            this.btnregresar.BackColor = System.Drawing.Color.Maroon;
            this.btnregresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnregresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregresar.ForeColor = System.Drawing.Color.White;
            this.btnregresar.Location = new System.Drawing.Point(1053, 32);
            this.btnregresar.Margin = new System.Windows.Forms.Padding(4);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(149, 32);
            this.btnregresar.TabIndex = 77;
            this.btnregresar.Text = "Regresar";
            this.btnregresar.UseVisualStyleBackColor = false;
            this.btnregresar.Click += new System.EventHandler(this.btnregresar_Click);
            // 
            // mostrar
            // 
            this.mostrar.BackColor = System.Drawing.Color.Maroon;
            this.mostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostrar.ForeColor = System.Drawing.Color.White;
            this.mostrar.Location = new System.Drawing.Point(555, 135);
            this.mostrar.Margin = new System.Windows.Forms.Padding(4);
            this.mostrar.Name = "mostrar";
            this.mostrar.Size = new System.Drawing.Size(149, 32);
            this.mostrar.TabIndex = 78;
            this.mostrar.Text = "Mostrar";
            this.mostrar.UseVisualStyleBackColor = false;
            this.mostrar.Click += new System.EventHandler(this.mostrar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 598);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1255, 31);
            this.toolStrip1.TabIndex = 79;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(111, 28);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(111, 28);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // impresion_bitacoraBindingSource
            // 
            this.impresion_bitacoraBindingSource.DataSource = typeof(Pantallas_proyecto.impresion_bitacora);
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1255, 629);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mostrar);
            this.Controls.Add(this.btnregresar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1273, 676);
            this.MinimumSize = new System.Drawing.Size(1273, 676);
            this.Name = "frmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heaven Store - Bitacora";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbitacora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.impresion_bitacoraBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.DataGridView dgvbitacora;
        private System.Windows.Forms.Button mostrar;
        private System.Windows.Forms.BindingSource impresion_bitacoraBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Timer timer1;
    }
}