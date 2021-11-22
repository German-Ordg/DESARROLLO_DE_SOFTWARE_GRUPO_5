using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }
        //Variable generada para ingresar los parametros
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

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {   //Carga la seguridad del formulario y ademas informacion relevante del user
            security();
            lblnombre.Text = "Bienvenido: " + Cashe.UserCache.FirstName + " " + Cashe.UserCache.LastName;
            timer1.Enabled = true;
        }
        private void security()
        {   //Instancia para validar credenciales para el usuario
            var userModel = new Dominio.UserModel();
            if (userModel.securityLogin() == false)
            {
                MessageBox.Show("Error Fatal, se detectó que está intentando acceder al sistema sin credenciales, por favor inicie sesión e indentifiquese");
                Application.Exit();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInventario menu = new FrmInventario();
            menu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de Acceso al hacer click
            FrmAcceso acceso = new FrmAcceso();
            acceso.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {   //Cierra el formulario
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {   //Nos abre el formulario de facturacion al hacer click
            frmPantallaFacturacion facturacion = new frmPantallaFacturacion();
            facturacion.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {   //Muestra la hora actual
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string ruta = @"file:///C:/Users/david/Desktop/Heaven_Store_proyecto/Manual_Usuario_Heaven/Manual_Usuario_Heaven/index.htm";
            Process.Start(ruta);
        }
    }
}
