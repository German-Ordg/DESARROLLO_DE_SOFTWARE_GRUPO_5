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
        validaciones validacion = new validaciones();
        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;
        SqlCommand scd;
        private bool letra2 = false;
        private void button1_Click(object sender, EventArgs e)
        {
            //FrmAcceso acceso = new FrmAcceso();
           // acceso.Show();
            this.Close();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
           
            if (validacion.Espacio_Blanco_CB(ErrorProvider, cmbUsuariorequerido))
            {
                if (!validacion.Espacio_Blanco_CB(ErrorProvider, cmbUsuariorequerido))
                {
                    ErrorProvider.SetError(cmbUsuariorequerido, "");
                }
                ErrorProvider.SetError(cmbUsuariorequerido, "Elija un usuario para recuperar contraseña");
            }
            else
            {
                txtresultado.Visible = true;
                var user = new Dominio.UserModel();
                var result = user.recoverPassword(cmbUsuariorequerido.Text);
                txtresultado.Text = result;

                txtcodigo.Visible = true;
                lblcodigo.Visible = true;
                btnverificar.Visible = true;
                cmbUsuariorequerido.Enabled = false;
            }
        }

        private void FrmRecuperaContra_Load(object sender, EventArgs e)
        {
            txtresultado.Visible = false;
            lblcorreo.Visible = false;
            chkMostrarContra.Visible = false;
            conect.abrir();
            conect.CargaDeUsuarios(cmbUsuariorequerido);
            conect.cerrar();
            


        }

        private void cmbUsuariorequerido_SelectedIndexChanged(object sender, EventArgs e)
        {
            //conseguir Correo del usuario
            conect.abrir();
            cmd = new SqlCommand("select correo_electronico from Usuarios where nombre_usuario = @Usuario", conect.conexion);
            cmd.Parameters.AddWithValue("@Usuario", cmbUsuariorequerido.Text);
            SqlDataReader correo = cmd.ExecuteReader();
            if (correo.Read())
            {
                lblcorreo.Text = correo["correo_electronico"].ToString();
                lblcorreo.Visible = true;
            }
            else
            {
                MessageBox.Show("Error al buscar el Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conect.cerrar();
        }

        private void btnverificar_Click(object sender, EventArgs e)
        {
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
            try
            {
                conect.abrir();
                string contra;
                contra = Encrypt.GetSHA256(txtContrasena.Text);

                scd = new SqlCommand("update Usuarios set contrasena='" + contra + "' where nombre_usuario = '" + cmbUsuariorequerido.Text + "'", conect.conexion);

                scd.ExecuteNonQuery();

                MessageBox.Show("Contraseña actualizada!", "AVISO", MessageBoxButtons.OK);
                conect.cerrar();
                lblnueva.Visible = false;
                btncambiar.Visible = false;
                txtContrasena.Visible = false;
                txtresultado.Text = "";
                txtresultado.Visible = false;
                cmbUsuariorequerido.Text = "";
                cmbUsuariorequerido.Enabled = true;
                lblcorreo.Visible = false;
                chkMostrarContra.Visible = false;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cambiar contraseña", "ERROR", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    conect.abrir();
                    string contra;
                    contra = Encrypt.GetSHA256(txtContrasena.Text);

                    scd = new SqlCommand("update Usuarios set contrasena='" + contra + "' where nombre_usuario = '" + cmbUsuariorequerido.Text + "'", conect.conexion);

                    scd.ExecuteNonQuery();

                    MessageBox.Show("Contraseña actualizada!", "AVISO", MessageBoxButtons.OK);
                    conect.cerrar();
                    lblnueva.Visible = false;
                    btncambiar.Visible = false;
                    txtContrasena.Visible = false;
                    txtresultado.Text = "";
                    txtresultado.Visible = false;
                    cmbUsuariorequerido.Text = "";
                    cmbUsuariorequerido.Enabled = true;
                    lblcorreo.Visible = false;

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

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
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
