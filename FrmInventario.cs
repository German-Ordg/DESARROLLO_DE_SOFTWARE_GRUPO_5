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
using System.Data.Sql;

namespace Pantallas_proyecto
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }
        ClsConexionBD conect = new ClsConexionBD();

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Este Codigo permite regresar al menu principal del programa de la Tienda Heaven Store
            FrmMenuPrincipal menu = new FrmMenuPrincipal();
            menu.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Seleccion en el dtgInventario
            int poc;

            poc = dtgInventario.CurrentRow.Index;

            txtBusqueda.Text = dtgInventario[0, poc].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Codigo que muestra el Dia, Fecha, mes y la hora en la parte inferior del programa
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            //Permite La carga de datos de productos al dtgInventario desde el sql
            conect.cargarDatosProductos(dtgInventario);
            timer1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Este codigo permite el ingreso del codigo o categoria que desea buscar en el dtgInventario
            int selection = CBSeleccion.SelectedIndex;
            if (selection == 0)
            {
                var aux = new MetodoBucasrProducto();
                aux.filtrar(dtgInventario, this.txtBusqueda.Text.Trim());
            }
        }
        private void comboBox1_events()
        {
            //Este codigo permite la busqueda por medio combobox de inventario la seleccion de codigo o categoria 
            int selection = CBSeleccion.SelectedIndex;
            if (selection == -1)
            {
                txtBusqueda.Enabled = false;
            }
            else
            {
                if (selection == 0)
                {
                    txtBusqueda.Enabled = true;
                    txtBusqueda.Clear();
                }
            }
        }
    }
}
