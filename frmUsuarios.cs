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
using System.Xml.Schema;
using System.Text.RegularExpressions;

namespace Pantallas_proyecto
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        SqlCommand scd;
        ClsConexionBD conect = new ClsConexionBD();
        validaciones validacion = new validaciones();

        private bool letra = false;
        private bool letra2 = false;
        private bool letra3 = false;
        private bool letra4 = false;
        private bool letra5 = false;
        private bool letra6 = false;
        private bool letra7 = false;
        private bool letra8 = false;
        private bool letra9 = false;
        private bool letra10 = false;

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


       

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Close();
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            errorProvider2.Clear();

            letra = false;
            letra2 = false;
            letra3 = false;
            letra4 = false;
            letra5 = false;
            letra6 = false;
            letra7 = true;
            letra8 = true;
            letra9 = true;

            if (validacion.Espacio_Blanco(errorProvider1, txtcodemp) || validacion.Solo_Numeros(errorProvider1, txtcodemp))
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtcodemp))
                    errorProvider1.SetError(txtcodemp, "no se puede dejar en blanco"); 
                else
                    if (validacion.Solo_Numeros(errorProvider1, txtcodemp))
                    errorProvider1.SetError(txtcodemp, "solo se permite numeros");

            }
            else
            {
                letra = true;
            }


            if (validacion.Espacio_Blanco(errorProvider1, txtusuario) || txtusuario.TextLength < 8)
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtusuario))
                    errorProvider1.SetError(txtusuario, "no se puede dejar en blanco");
                if (txtusuario.TextLength < 8 )
                {
                    errorProvider1.SetError(txtusuario, "el usuario debe ser mayor a 7 caracteres");
                }
            }
            else
            {
                letra2 = true;
            }


            if (validacion.Espacio_Blanco(errorProvider1, txtcorreo))
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtcorreo))
                    errorProvider1.SetError(txtcorreo, "no se puede dejar en blanco");
            }
            else
            {
                letra3 = true;
            }


            if (validacion.Espacio_Blanco_CB(errorProvider1, cmbtipousr))
            {
                if (validacion.Espacio_Blanco_CB(errorProvider1, cmbtipousr))
                    errorProvider1.SetError(cmbtipousr, "no se puede dejar en blanco");
            }
            else
            {
                letra4 = true;
            }


            if (validacion.Espacio_Blanco(errorProvider2, txtcontra)  || txtcontra.TextLength < 8)
            {
                if (validacion.Espacio_Blanco(errorProvider2, txtcontra))
                    errorProvider2.SetError(txtcontra, "no se puede dejar en blanco");
                if (txtcontra.TextLength < 8)
                {
                    errorProvider2.SetError(txtcontra, "el correo debe ser mayor a 7 caracteres");
                }
            }
            else
            {
                letra5 = true;
            }


            if (email_bien_escrito(txtcorreo.Text))
            {
                letra6 = true;
                
            }
            else
            {
                errorProvider2.SetError(txtcorreo, "Direccion de Correo invalida");
            }
                      

                    conect.abrir();
                    SqlCommand comando3 = new SqlCommand("select nombre_usuario from Usuarios where  nombre_usuario= '" + txtusuario.Text + "'", conect.conexion);
                    SqlDataReader registro3 = comando3.ExecuteReader();
                    if (registro3.Read())
                    {
                        letra7 = false;
                        errorProvider2.SetError(txtusuario, "Nombre de Usuario no disponible");

                    }
                    conect.cerrar();

                    
              


            conect.abrir();
            SqlCommand comando4 = new SqlCommand("select [codigo_empleado] from Usuarios where  [codigo_empleado]= '" + txtcodemp.Text + "'", conect.conexion);
            SqlDataReader registro4 = comando4.ExecuteReader();
            if (registro4.Read())
            {
                letra8 = false;
                errorProvider2.SetError(txtcodemp, "Codigo ya Registrado");

            }

            conect.cerrar();


            conect.abrir();
                            SqlCommand comando1 = new SqlCommand("select correo_electronico from Usuarios where  correo_electronico= '" + txtcorreo.Text + "'", conect.conexion);
                            SqlDataReader registro = comando1.ExecuteReader();
                            if (registro.Read())
                            {
                                letra9 = false;
                                errorProvider2.SetError(txtcorreo, "Correo ya Registrado");
                             
                            }

                            conect.cerrar();
                        



            conect.cerrar();



            if (letra && letra2 && letra3 && letra4 && letra5 && letra6 && letra7 && letra8 && letra9)
            {



                try
                {
                 
                    conect.abrir();
                        //-------------------------------encriptar contraseña
                        string contra;


                        contra = Encrypt.GetSHA256(txtcontra.Text);


                        scd = new SqlCommand("Insert into Usuarios(codigo_empleado, nombre_usuario, correo_electronico, contrasena, Estado) Values('" + txtcodemp.Text + "','" + txtusuario.Text + "','" + txtcorreo.Text + "','" + contra + "','" + cmbtipousr.Text + "')", conect.conexion);
                        //-------------------------------
                        scd.ExecuteNonQuery();
                        MessageBox.Show("Registro exitoso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conect.CargarDatosUsuario(dataGridView1);
                        txtcodemp.Clear();
                        txtusuario.Clear();
                        txtcorreo.Clear();
                    txtcontra.Clear();
                        cmbtipousr.SelectedIndex = -1;

                    
                    conect.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ingresar datos", "ERROR", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
                btnModificar.Enabled = false;
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            conect.abrir();
            int indice;
            String cod;
            indice = dataGridView1.CurrentRow.Index;

            letra = false;
            letra2 = false;
            letra3 = false;
            letra4 = false;
            letra5 = true;
            letra6 = false;
            letra9 = false;
            letra10 = false;
            if (validacion.Espacio_Blanco(errorProvider1, txtcodemp) || validacion.Solo_Numeros(errorProvider1, txtcodemp))
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtcodemp))
                    errorProvider1.SetError(txtcodemp, "no se puede dejar en blanco");
                else
                    if (validacion.Solo_Numeros(errorProvider1, txtcodemp))
                    errorProvider1.SetError(txtcodemp, "solo se permite numeros");
            }
            else
            {
                letra = true;
            }
            if (validacion.Espacio_Blanco(errorProvider1, txtusuario) || txtusuario.TextLength < 8)
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtusuario))
                    errorProvider1.SetError(txtusuario, "no se puede dejar en blanco");
                if (txtusuario.TextLength < 8)
                {
                    errorProvider1.SetError(txtusuario, "el usuario debe ser mayor a 7 caracteres");
                }
            }
            else
            {
                letra2 = true;
            }
            if (validacion.Espacio_Blanco(errorProvider1, txtcorreo))
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtcorreo))
                    errorProvider1.SetError(txtcorreo, "no se puede dejar en blanco");
            }
            else
            {
                letra3 = true;
            }
            if (validacion.Espacio_Blanco_CB(errorProvider1, cmbtipousr))
            {
                if (validacion.Espacio_Blanco_CB(errorProvider1, cmbtipousr))
                    errorProvider1.SetError(cmbtipousr, "no se puede dejar en blanco");
            }
            else
            {
                letra4 = true;
            }
            if (validacion.Espacio_Blanco(errorProvider2, txtcontra))
            {
                errorProvider2.Clear();
            }
            else
            {
                letra5 = true;
            }

            if (email_bien_escrito(txtcorreo.Text))
            {
                letra6 = true;
                errorProvider2.Clear();
            }
            else
            {
                errorProvider2.SetError(txtcorreo, "Direccion de Correo invalida");
                errorProvider3.Clear();
            }
            conect.cerrar();
            conect.abrir();
            SqlCommand comando1 = new SqlCommand("select count(*) from Usuarios where  correo_electronico= '" + txtcorreo.Text +"'", conect.conexion);
            int consulta1 = Convert.ToInt32(comando1.ExecuteScalar());
            if (consulta1 == 1)
            {
                if (txtcorreo2.Text == txtcorreo.Text)
                {
                    letra9 = true;
                }
                else
                {
                    letra9 = false;
                    errorProvider2.SetError(txtcorreo, "Correo ya Registrado");
                }
            }
            else
            {
     
                    letra9 = true;
   
            }


            conect.cerrar();


            


            conect.abrir();
            if (letra && letra2 && letra3 && letra4 && letra6 && letra9  )
            {

                try
                {

                    cod = dataGridView1[0, indice].Value.ToString();
                    //dataGridView1[1, indice].Value = textBox5.Text;
                    dataGridView1[1, indice].Value = txtusuario.Text;
                    dataGridView1[3, indice].Value = txtcorreo.Text;
                    //---------------------------encriptar en el data

                    string contra;

                    dataGridView1[2, indice].Value = Encrypt.GetSHA256(txtcontra.Text);
                    //---------------------------
                    dataGridView1[4, indice].Value = cmbtipousr.Text;


                    contra = Encrypt.GetSHA256(txtcontra.Text);
                    if (txtcontra.Text=="")
                    {
                        scd = new SqlCommand("Update Usuarios set codigo_empleado = " + txtcodemp.Text + ",   correo_electronico = '" + txtcorreo.Text + "',   nombre_usuario= '" + txtusuario2.Text + "', Estado = '" + cmbtipousr.Text + "' where nombre_usuario='" + txtusuario2.Text + "'", conect.conexion);
                        scd.ExecuteNonQuery();
                        MessageBox.Show("Registro Modificado!", "AVISO", MessageBoxButtons.OK);
                        txtcodemp.Clear();
                        txtusuario.Clear();
                        txtusuario2.Clear();
                        txtcorreo.Clear();
                        txtcorreo2.Clear();
                        txtcontra.Clear();
                        cmbtipousr.SelectedIndex = -1;
                        conect.CargarDatosUsuario(dataGridView1);
                        btnModificar.Enabled = false;
                        errorProvider1.Clear();
                        btnCrear.Enabled = true;
                        cmbEmpleado.Enabled = true;
                        txtusuario.Enabled = true;
                        errorProvider2.Clear();
                        errorProvider1.Clear();
                        errorProvider3.Clear();
                    }
                    else
                    {
                        if (txtcontra.TextLength < 8)
                        {
                            errorProvider3.SetError(txtcontra, "la contraseña debe ser mayor a 7 caracteres");
                        }
                        else
                        {
                            scd = new SqlCommand("Update Usuarios set codigo_empleado = " + txtcodemp.Text + ",   correo_electronico = '" + txtcorreo.Text + "',   nombre_usuario= '" + txtusuario2.Text + "',  contrasena = '" + contra + "', Estado = '" + cmbtipousr.Text + "' where nombre_usuario='" + txtusuario2.Text + "'", conect.conexion);
                            scd.ExecuteNonQuery();
                            MessageBox.Show("Registro Modificado!", "AVISO", MessageBoxButtons.OK);
                            txtcodemp.Clear();
                            txtusuario.Clear();
                            txtusuario2.Clear();
                            txtcorreo.Clear();
                            txtcorreo2.Clear();
                            txtcontra.Clear();
                            cmbtipousr.SelectedIndex = -1;
                            conect.CargarDatosUsuario(dataGridView1);
                            btnModificar.Enabled = false;
                            errorProvider1.Clear();
                            btnCrear.Enabled = true;
                            cmbEmpleado.Enabled = true;
                            txtusuario.Enabled = true;
                            errorProvider2.Clear();
                            errorProvider1.Clear();
                            errorProvider3.Clear();
                        }
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar datos", "ERROR", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
                
            }
            
            conect.cerrar();

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            txtusuario2.Visible = false;
            txtcorreo2.Visible = false;
            timer1.Enabled = true;
            toolStrip1.ForeColor = Color.Black;
            toolStripLabel1.ForeColor = Color.Black;
            toolStripLabel2.ForeColor = Color.Black;
            conect.abrir();
            conect.CargarDatosUsuario(dataGridView1);
            conect.CargaDeNombreUsuarios(cmbEmpleado);
            dataGridView1.ForeColor = Color.Black;
            conect.cerrar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToShortTimeString();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnCrear.Enabled = false;
            cmbEmpleado.Enabled = false;
            txtusuario.Enabled = false;
            int poc;

            poc = dataGridView1.CurrentRow.Index;

            txtcodemp.Text = dataGridView1[0, poc].Value.ToString();
            string codigo = txtcodemp.Text;

            try
            {
                
                conect.abrir();
                SqlCommand comando = new SqlCommand("select [nombre_empleado],[apellido_empleado] from [Empleados] where [codigo_empelado]=" + codigo + "", conect.conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cmbEmpleado.Text = (registro["nombre_empleado"].ToString() + " " + registro["apellido_empleado"].ToString());
                }

                conect.cerrar();
            }
            catch (Exception)
            {
                
                
            }
           


            txtusuario.Text = dataGridView1[1, poc].Value.ToString();
            txtusuario2.Text = dataGridView1[1, poc].Value.ToString();
            txtcorreo.Text = dataGridView1[3, poc].Value.ToString();
            txtcorreo2.Text = dataGridView1[3, poc].Value.ToString();

            txtcontra.Text = "";
            cmbtipousr.Text = dataGridView1[4, poc].Value.ToString();
        }

        private void cmbtipousr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                errorProvider1.Clear();
                conect.abrir();
                SqlCommand codemple = new SqlCommand(" select [codigo_empelado] from [Empleados] where  [nombre_empleado]+' '+[apellido_empleado]= '" + cmbEmpleado.Text + "'", conect.conexion);
                SqlDataReader registro2 = codemple.ExecuteReader();


                if (registro2.Read())
                {
                    txtcodemp.Text = registro2["codigo_empelado"].ToString();


                }

                conect.cerrar();
            }
            catch (Exception)
            {
                
                //errorProvider1.SetError(cmbEmpleado, "Codigo no encontrado, Intente de nuevo");
            }
            
        }
    }
}