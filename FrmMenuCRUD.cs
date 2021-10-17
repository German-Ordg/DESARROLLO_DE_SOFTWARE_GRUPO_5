using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    public partial class FrmMenuCRUD : Form
    {
        public FrmMenuCRUD()
        {
          
            InitializeComponent();
        }


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

        private void FrmMenuCRUD_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosTrabajo clientes = new frmPuestosTrabajo();
            clientes.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipalGerente principalGerente = new FrmMenuPrincipalGerente();
            principalGerente.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMetodosdePago metodosdePago = new FrmMetodosdePago();
            metodosdePago.Show();
            this.Hide();
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            frmPuestosTrabajo trabajo = new frmPuestosTrabajo();
            trabajo.Show();
            this.Close();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.Show();
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
            this.Close();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.Show();
            this.Close();
        }

        private void métodoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMetodosdePago metodosdePago = new FrmMetodosdePago();
            metodosdePago.Show();
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versión de programa Final.", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INVERSIONES HEAVEN STORE. TEL.:2772-2047. CORREO: gomezsalgadoevelyn@gmail.com", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias categorias = new FrmCategorias();
            categorias.Show();
            this.Hide();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias categorias = new FrmCategorias();
            categorias.Show();
            this.Close();
        }

        private void btnDescuentos_Click(object sender, EventArgs e)
        {
            FrmDescuentos descuentos = new FrmDescuentos();
            descuentos.Show();
            this.Hide();
        }
    }
}
