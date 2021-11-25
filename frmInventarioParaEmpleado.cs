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
    public partial class frmInventarioParaEmpleado : Form
    {
        private bool letra1 = false;
        private bool numero1 = false;

        public frmInventarioParaEmpleado()
        {
            InitializeComponent();
        }
        //Clase De conexion a la base de datos
        //Validacion de los codigos
        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;
        validaciones validacion = new validaciones();
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

        private void button7_Click(object sender, EventArgs e)
        {
            //Este codigo regresa a la pantalla Gerente Inventario
            this.Close();
            FrmInventario_Gerente invtGer = new FrmInventario_Gerente();
            invtGer.Show();
        }

        private void frmInventarioParaEmpleado_Load(object sender, EventArgs e)
        {
            //Este codigo permite que el combobox de categoria permanezca bloquado sin aber ingresado un codigo
            cmbcategoria.Enabled = false;
            txtdescripcion.Enabled = false;
            conect.abrir();
            conect.CargaDeCategoria(cmbcategoria);
            conect.cerrar();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Codigo que muestra el Dia, Fecha, mes y la hora en la parte inferior del programa
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //var aux = new MetodoBuscarCodigo();
           // aux.filtrar1(textBox2.Text, this.textBox1.Text.Trim());
        }
        FrmInventario_Gerente fact = new FrmInventario_Gerente();


        private void button2_Click(object sender, EventArgs e)
        {
            //Esta Parte del codigo valida si en el textbox se encuentra en blanco
            ErrorProvider1.Clear();
            letra1 = false;
            
            if (validacion.Espacio_Blanco(ErrorProvider1, txtdescripcion))
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtdescripcion))
                    ErrorProvider.SetError(txtdescripcion, "No se puede dejar en blanco");
            }
            else
            //Este Codigo evalua lo que ingreso en el codigo y se habilita las opciones que aparece en el combobox de esta pantalla
            {
                letra1 = true;
            }
            if (letra1)
            {
                try
                {
                   conect.cerrar();
                    conect.abrir();
                    string codigoCategoria = "";
                    SqlCommand comando = new SqlCommand("Select codigo_categoria from Categoria_Producto where descripcion_categoria='" + cmbcategoria.Text + "'", conect.conexion);
                    SqlDataReader registro = comando.ExecuteReader();
                    while (registro.Read())
                    {
                        codigoCategoria = registro["codigo_categoria"].ToString();
                    }
                   conect.cerrar();
                    conect.abrir();

                    cmd = new SqlCommand("Update Productos set codigo_categoria = '" + codigoCategoria + "', descripcion_producto = '" + txtdescripcion.Text + "'Where codigo_producto = " + txtcodigo.Text, conect.conexion);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Se Ha actualizado Correctamente");
                    conect.cerrar();

                    //this.Close();
                    // FrmInventario_Gerente invtGer = new FrmInventario_Gerente();
                    // invtGer.Show();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error al buscar producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                    txtcodigo.Clear();
                
                    cmbcategoria.Items.Clear();
                    txtdescripcion.Clear();
                    conect.abrir();
                    conect.CargaDeCategoria(cmbcategoria);
                    conect.cerrar();
            }     
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Esta Parte del codigo valida si en el textbox se encuentra en blanco
            if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo) || validacion.Solo_Numeros(ErrorProvider, txtcodigo))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo))
                    ErrorProvider.SetError(txtcodigo, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider, txtcodigo))
                    ErrorProvider.SetError(txtcodigo, "Solo se permite numeros");
            }
            else
            //Este Codigo evalua lo que ingreso en el codigo y se habilita las opciones que aparece en el combobox de esta pantalla
            //Solo se puede ingresar numeros no letras
            {
                numero1 = true;
            }
            if (numero1)
            {
                conect.abrir();

                cmd = new SqlCommand("select * from VistaProductoCatego where codigo_producto = @codigo_producto ", conect.conexion);
                cmd.Parameters.AddWithValue("@codigo_producto", txtcodigo.Text);
                SqlDataReader Productos = cmd.ExecuteReader();
                if (Productos.Read())
                {
                    txtcodigo.Enabled = true;
                    txtdescripcion.Enabled = true;
                    cmbcategoria.Enabled = true;

                    cmbcategoria.Text = Productos["descripcion_categoria"].ToString();
                    txtdescripcion.Text = Productos["descripcion_producto"].ToString();

                }
                else
                {
                    MessageBox.Show("Error al buscar producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
              

               conect.cerrar();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
