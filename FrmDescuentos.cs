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

namespace Pantallas_proyecto
{
    public partial class FrmDescuentos : Form
    {
        public FrmDescuentos()
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

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD CRUD = new FrmMenuCRUD();
            CRUD.Show();
            this.Close();
        }
        ClsConexionBD connect = new ClsConexionBD();
        SqlDataAdapter da;
        DataTable dt;
        int Record_Id=0;
        double venta = 0; 
        public void MostrarDatos(DataGridView dgv, string nombreTabla)
        {
            try
            {
                da = new SqlDataAdapter("Select codigo_producto Codigo,Categoria_Producto.descripcion_categoria Categoria, descripcion_producto Descripción, cantidad_existente Cantidad,precio_actual Precio , descuento_producto Descuento , talla  " +
                    "From " + nombreTabla + ", Categoria_Producto Where Categoria_Producto.codigo_categoria = Productos.codigo_categoria ", connect.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmDescuentos_Load(object sender, EventArgs e)
        {
            MostrarDatos(dgvProductos, "Productos");
            timer1.Enabled = true;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                double validar = Convert.ToDouble(txtDescuento.Text);
            }
            catch (Exception)
            {
                errorProvider1.SetError(txtDescuento, "Escriba un Valor Valido");
                return;
            }
            
            bool letra = false;
            if (Record_Id==0) {
                letra = true;
                errorProvider1.SetError(txtDescuento, "No se selecciono un producto");
            }
            else if (Convert.ToDouble(txtDescuento.Text) > venta) { errorProvider1.SetError(txtDescuento, "Descuento es mayor que el precio de venta");letra = true; }

            if (letra == false)
            {
                try
                {
                    string query = "Update [Productos] set [descuento_producto]= '" + txtDescuento.Text + "' where [codigo_producto]='" + Record_Id + "'";
                    connect.abrir();
                    SqlCommand comando = new SqlCommand(query, connect.conexion);
                    comando.ExecuteNonQuery();
                    connect.abrir();
                    MessageBox.Show("Se Modificó Correctamente");
                    txtDescuento.Text = "";
                    errorProvider1.Clear();
                    MostrarDatos(dgvProductos, "Productos");
                    limpio();
                    textBox1.Text="";
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Record_Id = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtDescuento.Text = (dgvProductos.Rows[e.RowIndex].Cells[5].Value.ToString());
                //textBox1.Text = (dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                venta = Convert.ToDouble(dgvProductos.Rows[e.RowIndex].Cells[4].Value.ToString());
                lblProducto.Visible = true;
                lblProducto.Text = (dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString());
                errorProvider1.Clear();
                
            }
            catch { }

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Record_Id = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtDescuento.Text = (dgvProductos.Rows[e.RowIndex].Cells[5].Value.ToString());
                //textBox1.Text = (dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString());
                venta = Convert.ToDouble(dgvProductos.Rows[e.RowIndex].Cells[4].Value.ToString());
                lblProducto.Visible = true;
                lblProducto.Text = (dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString());
                errorProvider1.Clear();
                
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var aux = new MetodoBuscarCodigo();
            aux.filtrar1(dgvProductos, this.textBox1.Text.Trim());
            limpio();
        }
        void limpio() {
            Record_Id = 0;
            txtDescuento.Text = "";
            lblProducto.Text = "";
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text.Substring(0) == "0")
            {
                txtDescuento.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
