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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //FrmInventario_Gerente menu = new FrmInventario_Gerente();
         //   menu.Show();
            this.Close();
            FrmInventario_Gerente invtGer = new FrmInventario_Gerente();
            invtGer.Show();
        }

      /*  private void Agregar(object sender, EventArgs e)
        {
            int poc;

            poc = dataGridView1.CurrentRow.Index;

            textBox1.Text = dataGridView1[0, poc].Value.ToString();
            comboBox2.Text = dataGridView1[1, poc].Value.ToString();
        }*/

        private void frmInventarioParaEmpleado_Load(object sender, EventArgs e)
        {
            cmbcategoria.Enabled = false;
            txtdescripcion.Enabled = false;
            conect.abrir();
            conect.CargaDeCategoria(cmbcategoria);
            conect.cerrar();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
            ErrorProvider1.Clear();
            letra1 = false;

            if (validacion.Espacio_Blanco(ErrorProvider1, txtdescripcion))
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtdescripcion))
                    ErrorProvider.SetError(txtdescripcion, "No se puede dejar en blanco");
            }
            else
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

                    this.Close();
                    FrmInventario_Gerente invtGer = new FrmInventario_Gerente();
                    invtGer.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
                
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo) || validacion.Solo_Numeros(ErrorProvider, txtcodigo))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtcodigo))
                    ErrorProvider.SetError(txtcodigo, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider, txtcodigo))
                    ErrorProvider.SetError(txtcodigo, "Solo se permite numeros");
            }
            else
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
                    txtcodigo.Enabled = false;
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
