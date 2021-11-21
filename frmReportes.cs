using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Pantallas_proyecto
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

 

        
        ClsConexionBD conect = new ClsConexionBD();
        validaciones validacion = new validaciones();
        private bool letra2 = false;
        private bool letra = false;

        private const int noClose = 0x200;

        //metodo para que no se pueda cerrar el programa con el boton con la figura "X"
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | noClose;
                return myCp;
            }
        }
        //boton para regresar al menu principal
        private void button7_Click(object sender, EventArgs e)
        {
            conect.cerrar();
            FrmMenuPrincipalGerente gerente = new FrmMenuPrincipalGerente();
            gerente.Show();
            this.Close();
        }
        
        //se cargan los datos de los reportes y datos que se usan para su propia creacion de los reportes
        private void frmReportes_Load(object sender, EventArgs e)
        {
            txtcodigo.Enabled = false;
            lblmensaje.Text = "";
            conect.abrir();
            conect.cargarDatosreporte1(dgvcompra);
            conect.abrir();
            conect.cargarDatosreporte2(dgvrotacion);
            conect.abrir();
            conect.cargarDatosreporte3(dgvventas);
            conect.abrir();
            conect.cargarDatosreporte4(dgvacabarse);
            conect.abrir();
            conect.cargarDatosreporte5(dgvcategorias);
            conect.abrir();
            conect.cargarDatosreporte5(dgvinventario);
            conect.abrir();
            conect.cargarDatosreporteempleado(dgvempleado);
            dgvempleado.ForeColor = Color.Black;
            dgvcompra.ForeColor = Color.Black;
            dgvrotacion.ForeColor = Color.Black;
            dgvventas.ForeColor = Color.Black;
            dgvmasvendido.ForeColor = Color.Black;
            dgvcategorias.ForeColor = Color.Black;
            dgvacabarse.ForeColor = Color.Black;
            DateTime fecha1 = dateTimePicker1.Value;
            dateTimePicker2.MinDate = fecha1.Date.AddDays(1);
            this.vCategoriasTableAdapter3.Fill(this.db_a75e9e_bderickmoncadaDataSetINVENTARIO.VCategorias);
            this.vCategoriasTableAdapter2.Fill(this.db_a75e9e_bderickmoncadaDataSet11VCategorita.VCategorias);
            timer1.Enabled = true;
            this.vCategoriasTableAdapter1.Fill(this.db_a75e9e_bderickmoncadaDataSet5.VCategorias);
            this.VCategoriasTableAdapter.Fill(this.db_a75e9e_bderickmoncadaDataSet4.VCategorias);
            this.ProductosTableAdapter.Fill(this.db_a75e9e_bderickmoncadaDataSet2.Productos);
            this.categoria_ProductoTableAdapter.Fill(this.db_a75e9e_bderickmoncadaDataSet.Categoria_Producto);
            CBcategoria.SelectedIndex = -1;
            CBcategoria.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            this.reportViewer8.RefreshReport();
            this.reportViewer8.RefreshReport();
        }

        //buton para mostrar el reporte que se desea
        private void button2_Click(object sender, EventArgs e)
        {
            letra2 = false;
            letra = false;
            if (validacion.Espacio_Blanco_CB(ErrorProvider, CBtipo))
            {
                if (validacion.Espacio_Blanco_CB(ErrorProvider, CBtipo))
                    ErrorProvider.SetError(CBtipo, "no se puede dejar en blanco");
            }
            else
            {
                letra2 = true;
            }

            

            if (letra2)
            {
                switch (CBtipo.Text)
                {
                    case "Inventario por Categoria":
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        CBcategoria.Enabled = true;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "Seleccione una categoria";
                        List<impresion1> impresion9 = new List<impresion1>();

                        impresion9.Clear();

                        for (int i = 0; i < dgvcategorias.Rows.Count - 1; i++)
                        {
                            impresion1 imp = new impresion1();
                            imp.dato1 = this.dgvcategorias.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvcategorias.Rows[i].Cells[2].Value.ToString();
                            imp.dato3 = this.dgvcategorias.Rows[i].Cells[3].Value.ToString();
                            imp.dato4 = this.dgvcategorias.Rows[i].Cells[4].Value.ToString();
                            imp.dato5 = this.dgvcategorias.Rows[i].Cells[5].Value.ToString();
                            imp.dato6 = this.dgvcategorias.Rows[i].Cells[6].Value.ToString();
                            imp.dato7 = this.dgvcategorias.Rows[i].Cells[7].Value.ToString();

                            impresion9.Add(imp);
                        }
                        ReportParameter[] parameters100 = new ReportParameter[1];
                        this.reportes.SelectedTab = reportes.TabPages["tab1"];
                        string Categoria = CBcategoria.Text.Trim();
                        parameters100[0] = new ReportParameter("Categoria", Categoria);
                        reportViewer1.LocalReport.SetParameters(parameters100);
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion9));
                        this.reportViewer1.RefreshReport();
                
                break;
                    case "Ventas":
                        dateTimePicker1.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "Ingrese una 'Fecha desde' y una 'Fecha hasta'";
                        List<impresion_ventas> impresion5 = new List<impresion_ventas>();

                        impresion5.Clear();

                        for (int i = 0; i < dgvventas.Rows.Count - 1; i++)
                        {
                            impresion_ventas imp = new impresion_ventas();
                            imp.dato1 = this.dgvventas.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvventas.Rows[i].Cells[1].Value.ToString();
                            imp.dato3 = this.dgvventas.Rows[i].Cells[2].Value.ToString();
                            imp.dato4 = this.dgvventas.Rows[i].Cells[3].Value.ToString();
                            imp.dato5 = this.dgvventas.Rows[i].Cells[4].Value.ToString();
                            imp.dato6 = this.dgvventas.Rows[i].Cells[5].Value.ToString();
                            imp.dato7 = this.dgvventas.Rows[i].Cells[6].Value.ToString();
                            imp.dato8 = this.dgvventas.Rows[i].Cells[7].Value.ToString();
                            imp.dato9 = this.dgvventas.Rows[i].Cells[8].Value.ToString();
                            imp.dato10 = this.dgvventas.Rows[i].Cells[9].Value.ToString();
                            impresion5.Add(imp);
                        }
                        ReportParameter[] parameters2222 = new ReportParameter[2];
                        this.reportes.SelectedTab = reportes.TabPages["tab2"];
                        string Fecha123 = dateTimePicker1.Value.ToString();
                        string Fecha234 = dateTimePicker2.Value.ToString();
                        parameters2222[0] = new ReportParameter("fecha1", Fecha123);
                        parameters2222[1] = new ReportParameter("fecha2", Fecha234);
                        reportViewer2.LocalReport.SetParameters(parameters2222);

                        reportViewer2.LocalReport.DataSources.Clear();
                        reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion5));
                        this.reportViewer2.RefreshReport();
                        break;
                    case "Productos a Punto de Acabarse":
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "";
                        List<impresion_ventas> impresion12 = new List<impresion_ventas>();

                        impresion12.Clear();

                        for (int i = 0; i < dgvacabarse.Rows.Count - 1; i++)
                        {
                            impresion_ventas imp = new impresion_ventas();
                            imp.dato1 = this.dgvacabarse.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvacabarse.Rows[i].Cells[2].Value.ToString();
                            imp.dato3 = this.dgvacabarse.Rows[i].Cells[3].Value.ToString();
                            imp.dato4 = this.dgvacabarse.Rows[i].Cells[4].Value.ToString();
                            imp.dato5 = this.dgvacabarse.Rows[i].Cells[5].Value.ToString();
                            imp.dato6 = this.dgvacabarse.Rows[i].Cells[6].Value.ToString();
                            imp.dato7 = this.dgvacabarse.Rows[i].Cells[7].Value.ToString();
                            impresion12.Add(imp);
                        }
                        this.reportes.SelectedTab = reportes.TabPages["tab3"];
                        reportViewer3.LocalReport.DataSources.Clear();
                        reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion12));
                        this.reportViewer3.RefreshReport();
                        break;
                    case "Rotacion del Inventario":
                        dateTimePicker1.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "Ingrese una 'Fecha desde' y una 'Fecha hasta'";
                        List<impresion1> impresion4 = new List<impresion1>();

                        impresion4.Clear();

                        for (int i = 0; i < dgvrotacion.Rows.Count - 1; i++)
                        {
                            impresion1 imp = new impresion1();
                            imp.dato1 = this.dgvrotacion.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = (string)this.dgvrotacion.Rows[i].Cells[1].Value;
                            imp.dato3 = this.dgvrotacion.Rows[i].Cells[2].Value.ToString();
                            imp.dato4 = this.dgvrotacion.Rows[i].Cells[3].Value.ToString();
                            imp.dato5 = this.dgvrotacion.Rows[i].Cells[4].Value.ToString();
                            imp.dato6 = this.dgvrotacion.Rows[i].Cells[5].Value.ToString();
                            imp.dato7 = this.dgvrotacion.Rows[i].Cells[6].Value.ToString();
                            imp.dato8 = this.dgvrotacion.Rows[i].Cells[7].Value.ToString();
                            impresion4.Add(imp);
                        }
                        ReportParameter[] parameters22 = new ReportParameter[2];
                        this.reportes.SelectedTab = reportes.TabPages["tab5"];
                        string Fecha1 = dateTimePicker1.Value.ToString();
                        string Fecha2 = dateTimePicker2.Value.ToString();
                        parameters22[0] = new ReportParameter("fecha1", Fecha1);
                        parameters22[1] = new ReportParameter("fecha2", Fecha2);
                        reportViewer5.LocalReport.SetParameters(parameters22);
                        reportViewer5.LocalReport.DataSources.Clear();
                        reportViewer5.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion4));
                        this.reportViewer5.RefreshReport();
                        break;
                    case "Inventario":
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "";
                        List<impresion1> impresion22 = new List<impresion1>();

                        impresion22.Clear();

                        for (int i = 0; i < dgvinventario.Rows.Count - 1; i++)
                        {
                            impresion1 imp = new impresion1();
                            imp.dato1 = this.dgvinventario.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvinventario.Rows[i].Cells[2].Value.ToString();
                            imp.dato3 = this.dgvinventario.Rows[i].Cells[3].Value.ToString();
                            imp.dato4 = this.dgvinventario.Rows[i].Cells[4].Value.ToString();
                            imp.dato5 = this.dgvinventario.Rows[i].Cells[5].Value.ToString();
                            imp.dato6 = this.dgvinventario.Rows[i].Cells[6].Value.ToString();
                            imp.dato7 = this.dgvinventario.Rows[i].Cells[7].Value.ToString();
                            impresion22.Add(imp);
                        }
                        this.reportes.SelectedTab = reportes.TabPages["tab6"];
                        reportViewer6.LocalReport.DataSources.Clear();
                        reportViewer6.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion22));
                        this.reportViewer6.RefreshReport();
                        break;

                    case "Compras por Codigo":
                        reportViewer7.Visible = true;
                        reportViewer9.Visible = false;
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Enabled = true;
                        lblmensaje.Text = "Debe ingresar un codigo de compra";
                        if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo) || validacion.Solo_Numeros(ErrorProvider, txtcodigo))
                        {
                            if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo))
                                ErrorProvider.SetError(txtcodigo, "no se puede dejar en blanco");
                            else
                                if (validacion.Solo_Numeros(ErrorProvider, txtcodigo))
                                ErrorProvider.SetError(txtcodigo, "solo se permite numeros");
                        }
                        else
                        {
                            letra = true;
                        }
                        if (letra)
                        {
                            lblmensaje.Text = "";
                            List<impresion1> impresion2 = new List<impresion1>();

                            impresion2.Clear();

                            for (int i = 0; i < dgvcompra.Rows.Count - 1; i++)
                            {
                                impresion1 imp = new impresion1();
                                imp.dato1 = this.dgvcompra.Rows[i].Cells[0].Value.ToString();
                                imp.dato2 = (string)this.dgvcompra.Rows[i].Cells[1].Value;
                                imp.dato3 = this.dgvcompra.Rows[i].Cells[2].Value.ToString();
                                imp.dato4 = this.dgvcompra.Rows[i].Cells[3].Value.ToString();
                                imp.dato5 = (string)this.dgvcompra.Rows[i].Cells[4].Value;
                                imp.dato6 = this.dgvcompra.Rows[i].Cells[5].Value.ToString();
                                imp.dato7 = this.dgvcompra.Rows[i].Cells[6].Value.ToString();
                                imp.dato8 = this.dgvcompra.Rows[i].Cells[7].Value.ToString();
                                impresion2.Add(imp);
                            }
                            ReportParameter[] parameters1 = new ReportParameter[1];
                            this.reportes.SelectedTab = reportes.TabPages["tab7"];
                            string Codigo = txtcodigo.Text;
                            parameters1[0] = new ReportParameter("codigo", Codigo);
                            reportViewer7.LocalReport.SetParameters(parameters1);
                            reportViewer7.LocalReport.DataSources.Clear();
                            reportViewer7.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion2));
                            this.reportViewer7.RefreshReport();
                        }
                        break;

                    case "Compras con Fecha":
                        reportViewer9.Visible = true;
                        reportViewer7.Visible = false;
                        dateTimePicker1.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "Ingrese una 'Fecha desde' y una 'Fecha hasta'";
                        List<impresion1> impresion3 = new List<impresion1>();

                        impresion3.Clear();

                        for (int i = 0; i < dgvcompra.Rows.Count - 1; i++)
                        {
                            impresion1 imp = new impresion1();
                            imp.dato1 = this.dgvcompra.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvcompra.Rows[i].Cells[1].Value.ToString();
                            imp.dato3 = this.dgvcompra.Rows[i].Cells[2].Value.ToString();
                            imp.dato4 = this.dgvcompra.Rows[i].Cells[3].Value.ToString();
                            imp.dato5 = this.dgvcompra.Rows[i].Cells[4].Value.ToString();
                            imp.dato6 = this.dgvcompra.Rows[i].Cells[5].Value.ToString();
                            imp.dato7 = this.dgvcompra.Rows[i].Cells[6].Value.ToString();
                            imp.dato8 = this.dgvcompra.Rows[i].Cells[7].Value.ToString();
                            impresion3.Add(imp);
                        }
                        ReportParameter[] parameters2 = new ReportParameter[2];
                        this.reportes.SelectedTab = reportes.TabPages["tab7"];
                        string Fecha11 = dateTimePicker1.Value.ToString();
                        string Fecha22 = dateTimePicker2.Value.ToString();
                        parameters2[0] = new ReportParameter("fecha1", Fecha11);
                        parameters2[1] = new ReportParameter("fecha2", Fecha22);
                        reportViewer9.LocalReport.SetParameters(parameters2);
                        reportViewer9.LocalReport.DataSources.Clear();
                        reportViewer9.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion3));
                        this.reportViewer9.RefreshReport();
                        break;
                    case "Lo mas Vendido":
                        dateTimePicker1.Enabled = true;
                        dateTimePicker2.Enabled = true;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Clear();
                        txtcodigo.Enabled = false;
                        ErrorProvider.Clear();
                        lblmensaje.Text = "Ingrese una 'Fecha desde' y una 'Fecha hasta'";

                        DateTime Fecha111 = dateTimePicker1.Value;
                        DateTime Fecha222 = dateTimePicker2.Value;
                        var aux = new Metodolomasvendido();
                        aux.filtrar(dgvmasvendido, Fecha111, Fecha222);
                        List<impresion_ventas> impresion6 = new List<impresion_ventas>();

                        impresion6.Clear();

                        for (int i = 0; i < dgvmasvendido.Rows.Count - 1; i++)
                        {
                            impresion_ventas imp = new impresion_ventas();
                            imp.dato1 = this.dgvmasvendido.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvmasvendido.Rows[i].Cells[1].Value.ToString();
                            imp.dato3 = this.dgvmasvendido.Rows[i].Cells[2].Value.ToString();
                            impresion6.Add(imp);
                        }
                        this.reportes.SelectedTab = reportes.TabPages["tab4"];
                        reportViewer4.LocalReport.DataSources.Clear();
                        reportViewer4.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion6));
                        this.reportViewer4.RefreshReport();
                        break;
                    case "Empleados":
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        CBcategoria.Enabled = false;
                        CBcategoria.SelectedIndex = -1;
                        txtcodigo.Enabled = false;
                        lblmensaje.Text = "";
                        List<impresion1> impresion88 = new List<impresion1>();

                        impresion88.Clear();

                        for (int i = 0; i < dgvempleado.Rows.Count - 1; i++)
                        {
                            impresion1 imp = new impresion1();
                            imp.dato1 = this.dgvempleado.Rows[i].Cells[0].Value.ToString();
                            imp.dato2 = this.dgvempleado.Rows[i].Cells[1].Value.ToString();
                            imp.dato3 = this.dgvempleado.Rows[i].Cells[2].Value.ToString();
                            imp.dato4 = this.dgvempleado.Rows[i].Cells[3].Value.ToString();
                            imp.dato5 = this.dgvempleado.Rows[i].Cells[4].Value.ToString();
                            imp.dato6 = this.dgvempleado.Rows[i].Cells[5].Value.ToString();
                            impresion88.Add(imp);
                        }
                        this.reportes.SelectedTab = reportes.TabPages["tab10"];
                        reportViewer8.LocalReport.DataSources.Clear();
                        reportViewer8.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion88));
                        this.reportViewer8.RefreshReport();
                        break;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void reportViewer6_Load(object sender, EventArgs e)
        {
        }


        private void CBcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CBtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        //metodo para mostrar la hora y fecha actual
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void VCategoriasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void dba75e9ebderickmoncadaDataSet2BindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {   
        }

        private void lblmensaje_Click(object sender, EventArgs e)
        {
        }
        //metodo para el correcto funcionamiento de la fecha que se pueden escoger
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime fecha1 = dateTimePicker1.Value;
            dateTimePicker2.MinDate = fecha1.Date.AddDays(1);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dgvcompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    //clase corta hecha para lograr imprimir los datos de los reportes
    //no se creo la clase aparte por que muy pequeña
    public class impresion1
    {
        public string dato1 { get; set; }
        public string dato2 { get; set; }
        public string dato3 { get; set; }
        public string dato4 { get; set; }
        public string dato5 { get; set; }
        public string dato6 { get; set; }
        public string dato7 { get; set; }
        public string dato8 { get; set; }
    }
    //clase corta hecha para lograr imprimir los datos de los reportes
    //no se creo la clase aparte por que muy pequeña
    public class impresion_ventas
    {
        public string dato1 { get; set; }
        public string dato2 { get; set; }
        public string dato3 { get; set; }
        public string dato4 { get; set; }
        public string dato5 { get; set; }
        public string dato6 { get; set; }
        public string dato7 { get; set; }
        public string dato8 { get; set; }
        public string dato9 { get; set; }
        public string dato10 { get; set; }
    }
    //clase corta hecha para lograr imprimir los datos del reprote de lo mas vendido
    //no se creo la clase aparte por que muy pequeña
    class Metodolomasvendido
    {
        ClsConexionBD conect = new ClsConexionBD();

        public void filtrar(DataGridView data, DateTime fecha1, DateTime fecha2)
        {


            try
            {
                conect.cerrar();
                conect.abrir();
                SqlCommand sql = new SqlCommand("PA_producto_mas_vendido", conect.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.Add("@Fecha1", SqlDbType.Date).Value = fecha1;
                sql.Parameters.Add("@Fecha2", SqlDbType.Date).Value = fecha2;

                sql.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(dt);
                data.DataSource = dt;
                conect.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error es: " + ex.ToString());
            }

        }
    }

}
