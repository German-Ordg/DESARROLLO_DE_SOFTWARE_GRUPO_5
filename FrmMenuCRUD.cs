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

        //Variable generada por el editor 
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
        {   //Evento que activa el timer1
            timer1.Enabled = true;
        }
        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Nos abre el formulario puestos de trabajo al hacer click
            frmPuestosTrabajo clientes = new frmPuestosTrabajo();
            clientes.Show();
            this.Close();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {   //Nos regresa al menu principal al hacer click
            FrmMenuPrincipalGerente principalGerente = new FrmMenuPrincipalGerente();
            principalGerente.Show();
            this.Close();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de Empleados al hacer click
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.Show();
            this.Hide();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de proveedores al hacer click
            frmProveedores proveedores = new frmProveedores();
            proveedores.Show();
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de usuarios al hacer click
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de metodos de pago al hacer click
            FrmMetodosdePago metodosdePago = new FrmMetodosdePago();
            metodosdePago.Show();
            this.Hide();
        }

      

        private void button6_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de puestos de trabajo al hacer click
            frmPuestosTrabajo trabajo = new frmPuestosTrabajo();
            trabajo.Show();
            this.Close();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de empleados al hacer click
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.Show();
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de usuarios al hacer click
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.Show();
            this.Close();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de proveedores al hacer click y cierra este frm
            frmProveedores proveedores = new frmProveedores();
            proveedores.Show();
            this.Close();
        }

        private void métodoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de metodos de pago al hacer click
            FrmMetodosdePago metodosdePago = new FrmMetodosdePago();
            metodosdePago.Show();
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Muestra informacion relevante sobre este software
            MessageBox.Show("Versión de programa Final.", "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Muestra informacion relevante sobre este software
            MessageBox.Show("INVERSIONES HEAVEN STORE. TEL.:2772-2047. CORREO: gomezsalgadoevelyn@gmail.com", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   //Muestra la fecha

            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de categorias al hacer click
            FrmCategorias categorias = new FrmCategorias();
            categorias.Show();
            this.Hide();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de categorias al hacer click
            FrmCategorias categorias = new FrmCategorias();
            categorias.Show();
            this.Close();
        }

        private void btnDescuentos_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de descuentos al hacer click
            FrmDescuentos descuentos = new FrmDescuentos();
            descuentos.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        { //Nos abre el formulario de descuentos al hacer click
            FrmDescuentos descuentos = new FrmDescuentos();
            descuentos.Show();
            this.Hide();
        }
    }
}
