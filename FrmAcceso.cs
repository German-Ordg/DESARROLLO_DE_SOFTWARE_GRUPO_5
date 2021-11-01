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
    public partial class FrmAcceso : Form
    {
        public FrmAcceso()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
         
                if (txtUsuario.Text != "Usuario")
                {
                    if (txtContrasena.Text != "Contraseña")
                    {
                        
                        Dominio.UserModel model = new Dominio.UserModel();
                    String contra = Encrypt.GetSHA256(txtContrasena.Text);
                    var validar = model.LoginUser(txtUsuario.Text, contra);
                    if (validar == true)
                        {


                        if (Cashe.UserCache.estado == "ACTIVO")
                        {
                            this.Hide();
                            FormBienvenido welcome = new FormBienvenido();
                            welcome.ShowDialog();
                            if (Cashe.UserCache.Position == "Vendedor")
                            {
                                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                                menu.Show();
                                menu.FormClosed += cerrarSesion;
                            }
                            else if (Cashe.UserCache.Position == "Gerente")
                            {
                                FrmMenuPrincipalGerente menu = new FrmMenuPrincipalGerente();
                                menu.Show();
                                menu.FormClosed += cerrarSesion;
                            }
                            else {
                                MessageBox.Show("Tu Puesto de Trabajo No opera con este sistema, Contacte al Gerente", "ACCESO RESTRINGIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Application.Exit();
                            }
                        }                  
                        else
                            MessageBox.Show("Tu cuenta esta INACTIVA, Contacte al Gerente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                        else
                        {
                            msjError("Usuario o contraseña incorrecta \n\t Intente de nuevo");
                            
                        }
                    
                    }
                    else
                        msjError("Ingrese la contraseña");
                }
                else
                    msjError("Ingrese el usuario");
            
        }
        private void msjError(string msj)
        {
            lblError.Text = msj;
            lblError.Visible = true;
            picError.Visible = true;
        }
        

        private void chkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtContrasena.Text;
            if (chkMostrarContra.Checked)
            {
                txtContrasena.UseSystemPasswordChar = false;
                txtContrasena.Text = text;
            }
            else
            {
                txtContrasena.UseSystemPasswordChar = true;
                txtContrasena.Text = text;
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
           
            lblError.Visible = false;
            picError.Visible = false;
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";            
                txtUsuario.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";          
                txtContrasena.ForeColor = SystemColors.GrayText;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }
        private void cerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            lblError.Visible = false;
            this.Show();
            txtUsuario.Focus();
            picError.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            picError.Visible = false;

        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            FrmRecuperaContra recuperacion = new FrmRecuperaContra();
            recuperacion.Show();
            recuperacion.FormClosed += cerrarSesion;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCompras fact = new FrmCompras();

            fact.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();

        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtUsuario.Text != "Usuario")
                {
                    if (txtContrasena.Text != "Contraseña")
                    {

                        Dominio.UserModel model = new Dominio.UserModel();
                        String contra = Encrypt.GetSHA256(txtContrasena.Text);
                        var validar = model.LoginUser(txtUsuario.Text, contra);
                        if (validar == true)
                        {
                            if (Cashe.UserCache.estado == "ACTIVO")
                            {
                                this.Hide();
                                FormBienvenido welcome = new FormBienvenido();
                                welcome.ShowDialog();
                                if (Cashe.UserCache.Position == "Vendedor")
                                {
                                    FrmMenuPrincipal menu = new FrmMenuPrincipal();
                                    menu.Show();
                                    menu.FormClosed += cerrarSesion;
                                }
                                else
                                if (Cashe.UserCache.Position == "Gerente")
                                {
                                    FrmMenuPrincipalGerente menu = new FrmMenuPrincipalGerente();
                                    menu.Show();
                                    menu.FormClosed += cerrarSesion;
                                }
                                else
                                {
                                    MessageBox.Show("Tu Puesto de Trabajo No opera con este sistema, Contacte al Gerente", "ACCESO RESTRINGIDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Application.Exit();
                                }
                            }
                            else
                                MessageBox.Show("Tu cuenta esta INACTIVA, Contacte al Gerente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        }
                        else
                        {
                            msjError("Usuario o contraseña incorrecta \n\t Intente de nuevo");
                         
                        }
                    }
                    else
                        msjError("Ingrese la contraseña");
                }
                else
                    msjError("Ingrese el usuario");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPantallaFacturacion fact = new frmPantallaFacturacion();
            fact.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPantallaFacturacion fact = new frmPantallaFacturacion();
            fact.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FrmProductos productos = new FrmProductos();
            productos.Show();
        }
    }
}
