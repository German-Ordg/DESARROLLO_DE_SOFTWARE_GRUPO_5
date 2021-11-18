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
    public partial class FrmInventario_Gerente : Form
    {
        public FrmInventario_Gerente()
        {
            // Este codigo permite estar bloqueado el txtIngreso sin haber seleccionado algo
            InitializeComponent();
            txtIngreso.Enabled = false;
        }
        //Codigo de la clase conexion a la Base de Datos
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
            FrmMenuPrincipalGerente gerente = new FrmMenuPrincipalGerente();
            gerente.Show();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Este cdigo permite Ingresar a la pantalla inventario para empleado 
            this.Hide();
            frmInventarioParaEmpleado fact = new frmInventarioParaEmpleado();
            fact.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////Seleccion en el dtgInventarioGerente
            int poc;

            poc = dtgInventarioGerente.CurrentRow.Index;

            txtIngreso.Text = dtgInventarioGerente[0, poc].Value.ToString();
        }
        private void FrmInventario_Gerente_Load(object sender, EventArgs e)
        {
            //permite la carga de datos de productos al dtgInventarioGerente
            conect.abrir();
            conect.cargarDatosProductos(dtgInventarioGerente);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Codigo que muestra el Dia, Fecha, mes y la hora en la parte inferior del programa
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }
//---------------------------------------Codigo Que no se puede Eliminar--------------------------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* int poc;
            poc = dataGridView1.CurrentRow.Index;

            textBox1.Text = dataGridView1[0, poc].Value.ToString();
            /*textBox2.Text = dataGridView1[1, poc].Value.ToString();*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           /* var aux = new MetodoBucasrProducto();
            aux.filtrar(dataGridView1, this.textBox2.Text.Trim());*/
        }
//-------------------------------------------------------------------------------------------------------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ////Este codigo permite el ingreso del categoria que desea buscar en el dtgInventarioGerente
            int selection = CBBusqueda.SelectedIndex;
            if (selection == 0)
            {
                var aux = new MetodoBucasrProducto();
                aux.filtrar(dtgInventarioGerente, this.txtIngreso.Text.Trim());
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Solo premitre mostrar el evento del comobo box busqueda
            comboBox1_events();
         }
        private void comboBox1_events()
        {
            //Este codigo permite la busqueda por medio combobox de inventario la seleccion de  categoria
            int selection = CBBusqueda.SelectedIndex;
            if(selection == -1)
            {
                txtIngreso.Enabled = false;
            }
            else
            {
                if(selection == 0)
                {
                    txtIngreso.Enabled = true;
                    txtIngreso.Clear();
                }
            }
        }
    }
}
