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
            InitializeComponent();
            textBox1.Enabled = false;
           // textBox2.Enabled = false;
        }
        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;


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
            FrmMenuPrincipalGerente gerente = new FrmMenuPrincipalGerente();
            gerente.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInventarioParaEmpleado fact = new frmInventarioParaEmpleado();
            fact.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int poc;

            poc = dataGridView1.CurrentRow.Index;

            textBox1.Text = dataGridView1[0, poc].Value.ToString();
            //textBox2.Text = dataGridView1[1, poc].Value.ToString();
        }

        private void FrmInventario_Gerente_Load(object sender, EventArgs e)
        {
            conect.abrir();
            conect.cargarDatosProductos(dataGridView1);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int selection = comboBox1.SelectedIndex;
            if (selection == 0)
            {
                var aux = new MetodoBuscarCodigo();
                aux.filtrar1(dataGridView1, this.textBox1.Text.Trim());
            }
            
            else
            {
                var aux = new MetodoBucasrProducto();
                aux.filtrar(dataGridView1, this.textBox1.Text.Trim());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1_events();



         }
        private void comboBox1_events()
        {
            int selection = comboBox1.SelectedIndex;
            if(selection == -1)
            {
                textBox1.Enabled = false;
               // textBox2.Enabled = false;
            }
            else
            {
                if(selection == 0)
                {
                    textBox1.Enabled = true;
                   // textBox2.Enabled = false;
                    textBox1.Clear() ;
                   // textBox2.Clear();
                }
                else
                {
                    textBox1.Enabled = true;
                    //textBox2.Enabled = true;
                    textBox1.Clear();
                  //  textBox2.Clear();

                }
            }
        }

        

    }
}
