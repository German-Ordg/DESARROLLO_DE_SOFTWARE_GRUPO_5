using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
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

        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;
        validaciones validacion = new validaciones();
        private bool letra2 = false;
        private bool letra = false;
        private bool letra3 = false;
        private bool letra9 = false;
        private bool letra10 = false;
        private string proveedor;
        private string numero;

        private void button7_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD menuCRUD = new FrmMenuCRUD();
            menuCRUD.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            letra2 = false;
            letra = false;
            letra3 = false;
            dgvProovedores.ForeColor = Color.Black;
            if (validacion.Espacio_Blanco(ErrorProvider, txtNombreProovedor) || validacion.Solo_Letras(ErrorProvider, txtNombreProovedor))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtNombreProovedor))
                    ErrorProvider.SetError(txtNombreProovedor, "no se puede dejar en blanco");
                else
                    if (validacion.Solo_Letras(ErrorProvider, txtNombreProovedor))
                    ErrorProvider.SetError(txtNombreProovedor, "solo se permite letras");
            }
            else
            {
                letra = true;
            }
            if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion) )
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion))
                    ErrorProvider.SetError(txtDescripcion, "no se puede dejar en blanco");
                
            }
            else
            {
                letra2 = true;
            }
            if (validacion.Espacio_Blanco(ErrorProvider, txtTelefono) || validacion.Solo_Numeros(ErrorProvider, txtTelefono))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtTelefono))
                    ErrorProvider.SetError(txtTelefono, "no se puede dejar en blanco");
                else
                    if (validacion.Solo_Numeros(ErrorProvider, txtTelefono))
                    ErrorProvider.SetError(txtTelefono, "solo se permite numeros");
            }
            else
            {
                letra3 = true;
            }

            if (txtTelefono.Text.Length < 8 || txtTelefono.Text.Length > 8)
            {
                ErrorProvider.SetError(txtTelefono, "Numero invalido");
                letra3 = false;
            }
            if (letra && letra2 && letra3)
            {

                bool igual = false;
                conect.abrir();
                SqlCommand comando1 = new SqlCommand("select * from Proveedores where  nombre_proveedor= '" + txtNombreProovedor.Text + "'", conect.conexion);
                SqlDataReader registro = comando1.ExecuteReader();
                if (registro.Read())
                {
                    igual = true;
                }
                conect.cerrar();
                conect.abrir();
                SqlCommand comando2 = new SqlCommand("select * from Proveedores where  numero_contacto= '" + txtTelefono.Text + "'", conect.conexion);
                SqlDataReader registro2 = comando2.ExecuteReader();
                if (registro2.Read())
                {
                    igual = true;
                }
                conect.cerrar();
                if (igual == false)
                {
                    try
                    {
                        conect.abrir();
                        if (txtNombreProovedor.Text == "" || txtTelefono.Text == "" || txtDescripcion.Text == "")
                        {

                            MessageBox.Show("No se pueden dejar los campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            cmd = new SqlCommand("Insert into Proveedores(nombre_proveedor, numero_contacto, direccion_proveedor) values('" + txtNombreProovedor.Text + "','" + txtTelefono.Text + "','" + txtDescripcion.Text + "')", conect.conexion);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Se han ingresado los Datos con Exito ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conect.cargarProveedores(dgvProovedores);
                            dgvProovedores.ForeColor = Color.Black;
                            txtDescripcion.Text = "";
                            txtNombreProovedor.Text = "";
                            txtTelefono.Text = "";
                            errorProvider2.Clear();
                            ErrorProvider.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message.ToString());
                        MessageBox.Show("ERROR AL INSERTAR LOS DATOS" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        txtNombreProovedor.Clear();
                        txtTelefono.Clear();
                        txtDescripcion.Clear();
                    }
                    conect.cerrar();
                }
                else
                    MessageBox.Show("Esta ingresando un nombre o telefono que ya fue registrado", "Aviso", MessageBoxButtons.OK);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvProovedores.ForeColor = Color.Black;
            SqlDataAdapter da;
            DataTable dt;
           
            da = new SqlDataAdapter("Select * From Proveedores", conect.conexion);
            dt = new DataTable();
            da.Fill(dt);
            dgvProovedores.DataSource = dt;
        }

        private void dgvProovedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int indice;
            int codigo;
            indice = dgvProovedores.CurrentRow.Index;
            letra2 = false;
            letra = false;
            letra3 = false;
            letra9 = false;
            letra10 = false;
            if (validacion.Espacio_Blanco(ErrorProvider, txtNombreProovedor) || validacion.Solo_Letras(ErrorProvider, txtNombreProovedor))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtNombreProovedor))
                    ErrorProvider.SetError(txtNombreProovedor, "no se puede dejar en blanco");
                else
                    if (validacion.Solo_Letras(ErrorProvider, txtNombreProovedor))
                    ErrorProvider.SetError(txtNombreProovedor, "solo se permite letras");
            }
            else
            {
                letra = true;
            }
            if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion) )
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion))
                    ErrorProvider.SetError(txtDescripcion, "no se puede dejar en blanco");
                
            }
            else
            {
                letra2 = true;
            }
            if (validacion.Espacio_Blanco(ErrorProvider, txtTelefono) || validacion.Solo_Numeros(ErrorProvider, txtTelefono))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtTelefono))
                    ErrorProvider.SetError(txtTelefono, "no se puede dejar en blanco");
                else
                    if (validacion.Solo_Numeros(ErrorProvider, txtTelefono))
                    ErrorProvider.SetError(txtTelefono, "solo se permite numeros");
            }
            else
            {
                letra3 = true;
            }

            if (txtTelefono.Text.Length<8 || txtTelefono.Text.Length > 8) {
                ErrorProvider.SetError(txtTelefono, "Numero invalido");
                letra3 = false;
            }


            conect.cerrar();
            conect.abrir();
            SqlCommand comando2 = new SqlCommand("select count(*) from Proveedores where nombre_proveedor= '" + txtNombreProovedor.Text + "'", conect.conexion);
            int consulta2 = Convert.ToInt32(comando2.ExecuteScalar());
            if (consulta2 == 1)
            {
                if (proveedor == txtNombreProovedor.Text)
                {
                    letra9 = true;
                }
                else
                {
                    letra9 = false;
                    errorProvider2.SetError(txtNombreProovedor, "Nombre de proveedor ya Registrado");
                }
            }
            else
            {

                letra9 = true;

            }


            conect.cerrar();

            conect.abrir();

            SqlCommand comando3 = new SqlCommand("select count(*) from Proveedores where numero_contacto= '" + txtTelefono.Text + "'", conect.conexion);
            int consulta3 = Convert.ToInt32(comando3.ExecuteScalar());
            if (consulta3 == 1)
            {
                if (numero == txtTelefono.Text)
                {
                    letra10 = true;
                }
                else
                {
                    letra10 = false;
                    errorProvider2.SetError(txtTelefono, "telefono ya Registrado");
                }
            }
            else
            {

                letra10 = true;

            }


            conect.cerrar();

            conect.abrir();

            if (letra && letra2 && letra3 && letra9 && letra10)
            {

                
                    try
                    {
                        conect.abrir();
                        codigo = Convert.ToInt32(dgvProovedores[0, indice].Value);


                        dgvProovedores[1, indice].Value = txtNombreProovedor.Text;
                        dgvProovedores[2, indice].Value = txtTelefono.Text;
                        dgvProovedores[3, indice].Value = txtDescripcion.Text;


                        cmd = new SqlCommand("UPDATE Proveedores SET nombre_proveedor = '" + txtNombreProovedor.Text + "',  numero_contacto = '" + txtTelefono.Text + "', direccion_proveedor = '" + txtDescripcion.Text + "'  where codigo_proveedor = " + codigo, conect.conexion);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El registro fue actualizado exitosamente","Informacion",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conect.cargarProveedores(dgvProovedores);


                        txtNombreProovedor.Clear();
                        txtTelefono.Clear();
                        txtDescripcion.Clear();
                        txtNombreProovedor.Focus();
                        conect.cerrar();
                    button2.Enabled = true;
                    button3.Enabled = false;
                    proveedor = null;
                    numero = null;
                    errorProvider2.Clear();
                    ErrorProvider.Clear();

                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El registro no pudo ser actualizado" , "INFO", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                

            }

        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            conect.abrir();
            conect.cargarProveedores(dgvProovedores);
            dgvProovedores.ForeColor = Color.Black;
            button2.Enabled = true;
            button3.Enabled = false;
        }

       

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombreProovedor_TextChanged(object sender, EventArgs e)
        {

            if (txtNombreProovedor.Text.Length >= 50)
            {
                ErrorProvider.SetError(txtNombreProovedor, "No se pueden ingresar nombres mayor a 50 caracteres");
            }
        }

        private void txtNombreProovedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvProovedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int poc;

            poc = dgvProovedores.CurrentRow.Index;

            txtNombreProovedor.Text = dgvProovedores[1, poc].Value.ToString();
            txtTelefono.Text = dgvProovedores[2, poc].Value.ToString();
            txtDescripcion.Text = dgvProovedores[3, poc].Value.ToString();
            proveedor = dgvProovedores[1, poc].Value.ToString();
            numero = dgvProovedores[2, poc].Value.ToString();
            button2.Enabled = false;
            button3.Enabled = true;

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            txtNombreProovedor.Clear();
            txtDescripcion.Clear();
            txtTelefono.Clear();
            button2.Enabled = true;
            button3.Enabled = false;
            proveedor = null;
            numero = null;
            errorProvider2.Clear();
            ErrorProvider.Clear();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length >= 150)
            {
                ErrorProvider.SetError(txtNombreProovedor, "Numero invalido");
            }
        }
    }
    }

