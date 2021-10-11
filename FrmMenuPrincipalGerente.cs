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
    public partial class FrmMenuPrincipalGerente : Form
    {
        public FrmMenuPrincipalGerente()
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInventario_Gerente inventario_Gerente = new FrmInventario_Gerente();
            inventario_Gerente.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReportes reportes = new frmReportes();
            reportes.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPantallaFacturacion facturacion = new frmPantallaFacturacion();
            facturacion.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmCompras compras = new FrmCompras();
            compras.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAcceso acceso = new FrmAcceso();
            acceso.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipalGerente_Load(object sender, EventArgs e)
        {
            lblnombre.Text = "Bienvenido: "+Cashe.UserCache.FirstName +" "+ Cashe.UserCache.LastName;
            timer1.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
