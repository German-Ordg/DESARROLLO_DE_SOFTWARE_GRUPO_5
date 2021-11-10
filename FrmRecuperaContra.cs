//Recupera contra
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
    public partial class FrmRecuperaContra : Form
    {
        public FrmRecuperaContra()
        {
            InitializeComponent();
        }

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
        validaciones validacion = new validaciones();
        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;
        SqlCommand scd;
        private bool letra2 = false;
        private bool letra5 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            //FrmAcceso acceso = new FrmAcceso();
           // acceso.Show();
            this.Close();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            /*
             Verifica si el usuario ingresado se encuentra en la base de datos
            */
            conect.abrir();
            cmd = new SqlCommand("select nombre_usuario from Usuarios where nombre_usuario = @Usuario", conect.conexion);
            cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            SqlDataReader usuario = cmd.ExecuteReader();
            if (usuario.Read())
            {
                txtresultado.Visible = true;
                var user = new Dominio.UserModel();
                var result = user.recoverPassword(txtUsuario.Text);
                txtresultado.Text = result;

                txtcodigo.Visible = true;
                lblcodigo.Visible = true;
                btnverificar.Visible = true;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conect.cerrar();
        }

        private void FrmRecuperaContra_Load(object sender, EventArgs e)
        {
            txtresultado.Visible = false;
            chkMostrarContra.Visible = false;
            conect.abrir();

            conect.cerrar();
        }



        private void btnverificar_Click(object sender, EventArgs e)
        {
            /*
             Verifica si el codigo enviado al correo se ingresó correctamente
            */
            letra2 = false;
            if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo) || validacion.Solo_Numeros(ErrorProvider, txtcodigo))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo))
                    ErrorProvider.SetError(txtcodigo, "No se puede dejar en blanco");
                else
                if (validacion.Solo_Numeros(ErrorProvider, txtcodigo))
                    ErrorProvider.SetError(txtcodigo, "Solo se permiten números");
            }
            else
            {
                letra2 = true;
            }
            if (letra2)
            {
                int valor = Convert.ToInt32(txtcodigo.Text);
                if (Cashe.UserCache.numero == valor)
                {
                    lblnueva.Visible = true;
                    txtContrasena.Visible = true;
                    lblcodigo.Visible = false;
                    txtcodigo.Visible = false;
                    btnverificar.Visible = false;
                    btncambiar.Visible = true;
                    chkMostrarContra.Visible = true;
                }
                else
                {
                    MessageBox.Show("Codigo Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btncambiar_Click(object sender, EventArgs e)
        {
            /*
             Cambia la contraseña de usuario
            */
            letra5 = false;
            if (validacion.Espacio_Blanco(ErrorProvider, txtContrasena) || txtContrasena.TextLength < 8)
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtContrasena))
                    ErrorProvider.SetError(txtContrasena, "no se puede dejar en blanco");
                else
                if (txtContrasena.TextLength < 8)
                {
                    ErrorProvider.SetError(txtContrasena, "la contraseña debe ser mayor a 7 caracteres");
                }
            }
            else
            {
                letra5 = true;
            }
            if (letra5)
            {
                try
                {
                    conect.abrir();
                    string contra;
                    contra = Encrypt.GetSHA256(txtContrasena.Text);

                    scd = new SqlCommand("update Usuarios set contrasena='" + contra + "' where nombre_usuario = '" + txtUsuario.Text + "'", conect.conexion);

                    scd.ExecuteNonQuery();

                    MessageBox.Show("Contraseña actualizada!", "AVISO", MessageBoxButtons.OK);
                    conect.cerrar();
                    lblnueva.Visible = false;
                    btncambiar.Visible = false;
                    txtContrasena.Visible = false;
                    txtresultado.Text = "";
                    txtresultado.Visible = false;
                    txtUsuario.Text = "";
                    chkMostrarContra.Visible = false;

                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cambiar contraseña", "ERROR", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
             Se ingres la nueva contraseña
            */
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    conect.abrir();
                    string contra;
                    contra = Encrypt.GetSHA256(txtContrasena.Text);

                    scd = new SqlCommand("update Usuarios set contrasena='" + contra + "' where nombre_usuario = '" + txtUsuario.Text + "'", conect.conexion);

                    scd.ExecuteNonQuery();

                    MessageBox.Show("Contraseña actualizada!", "AVISO", MessageBoxButtons.OK);
                    conect.cerrar();
                    lblnueva.Visible = false;
                    btncambiar.Visible = false;
                    txtContrasena.Visible = false;
                    txtresultado.Text = "";
                    txtresultado.Visible = false;
                    txtUsuario.Text = "";

                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cambiar contraseña", "ERROR", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }

        }

        private void btncambiar_Enter(object sender, EventArgs e)
        {

        }

        private void btncambiar_Leave(object sender, EventArgs e)
        {

        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            /*
             Limpia el texto del textBox
            */
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            /*
             Rellena el texto en el textBox
            */
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = SystemColors.GrayText;
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
             Verifica si el código que se ingresó es correcto
            */
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int valor = Convert.ToInt32(txtcodigo.Text);
                if (Cashe.UserCache.numero == valor)
                {
                    lblnueva.Visible = true;
                    txtContrasena.Visible = true;
                    lblcodigo.Visible = false;
                    txtcodigo.Visible = false;
                    btnverificar.Visible = false;
                    btncambiar.Visible = true;
                }
                else
                {
                    MessageBox.Show("Codigo Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void chkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            /*
             Permite ver la contraseña ingresada
            */
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

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}