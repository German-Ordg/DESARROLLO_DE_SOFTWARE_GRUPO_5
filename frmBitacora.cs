using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Pantallas_proyecto
{
    public partial class frmBitacora : Form
    {
        public frmBitacora()
        {
            InitializeComponent();
        }
        //se llama a las clases de facturacion para acceder al metodo de mostrar usuarios en un combobox
        //se llama a la clase de conexion para tener acceso a la base de datos
        Bitacora bitacora = new Bitacora();
        ClsConexionBD conect = new ClsConexionBD();

        private const int cpNoCloseButton = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | cpNoCloseButton;
                return myCp;
            }
        }
        //Se cargan los empelados del sistema
        private void frmBitacora_Load(object sender, EventArgs e)
        {
            bitacora.cargarComboboxVendedor2(cmbVendedor);
            this.reportViewer1.RefreshReport();

            conect.cargarBitacora(dgvbitacora);

            dgvbitacora.ForeColor = Color.Black;

            this.reportViewer1.RefreshReport();

            DateTime fecha1 = dateTimePicker1.Value;
            dateTimePicker2.MinDate = fecha1.Date.AddDays(1);
        }
        //es la funcion del boton que sirve para regresar al menu principal
        private void btnregresar_Click(object sender, EventArgs e)
        {
            conect.cerrar();
            FrmMenuPrincipalGerente gerente = new FrmMenuPrincipalGerente();
            gerente.Show();
            this.Close();
        }
        //Se carga la bitacora del empleado deseado

        private void mostrar_Click(object sender, EventArgs e)
        {
            //se crea lista para guardar los datos que se van a imprimer 
            List<impresion_bitacora> ImpresionBitacora = new List<impresion_bitacora>();

            ImpresionBitacora.Clear();

            for (int i = 0; i < dgvbitacora.Rows.Count - 1; i++)
            {
                impresion_bitacora imp = new impresion_bitacora();
                imp.dato1 = this.dgvbitacora.Rows[i].Cells[0].Value.ToString();
                imp.dato2 = this.dgvbitacora.Rows[i].Cells[1].Value.ToString();
                imp.dato3 = this.dgvbitacora.Rows[i].Cells[2].Value.ToString();
                imp.dato4 = this.dgvbitacora.Rows[i].Cells[3].Value.ToString();
                ImpresionBitacora.Add(imp);
            }
            ReportParameter[] parameters2 = new ReportParameter[3];
            string Fecha1 = dateTimePicker1.Value.ToString();
            string Fecha2 = dateTimePicker2.Value.ToString();
            string nombre = cmbVendedor.Text.Trim(); 
            parameters2[0] = new ReportParameter("fecha1", Fecha1);
            parameters2[1] = new ReportParameter("fecha2", Fecha2);
            parameters2[2] = new ReportParameter("nombre", nombre);
            reportViewer1.LocalReport.SetParameters(parameters2);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ImpresionBitacora));
            this.reportViewer1.RefreshReport();
        }
    }


    public class impresion_bitacora
    {
        public string dato1 { get; set; }
        public string dato2 { get; set; }
        public string dato3 { get; set; }
        public string dato4 { get; set; }
    }
}
