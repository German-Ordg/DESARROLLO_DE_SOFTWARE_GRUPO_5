
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Pantallas_proyecto
{
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        validaciones validacion = new validaciones();
        private bool letra = false;
        private bool letra2 = false;
        private bool letra3 = false;

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

        private void label4_Click(object sender, EventArgs e)
        {

        }



        ClsConexionBD conect2 = new ClsConexionBD();
        Productos producto = new Productos();




        SqlDataAdapter da;
        DataTable dt;
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------


        public void cargarDatosCompras(DataGridView dgv, string nombreTabla)//Metodo cargar dato compras
        {
            try
            {
                da = new SqlDataAdapter("Select  Compras.codigo_compra Codigo, Proveedores.nombre_proveedor Proveedor , fecha_compra Fecha , Metodo_Pago.descripcion_pago Pago From " + nombreTabla +
                    ", Detalle_Compra, Proveedores, Metodo_Pago Where (Compras.codigo_compra= Detalle_Compra.codigo_compra ) and (Detalle_Compra.codigo_proveedor=Proveedores.codigo_proveedor) and" +
                    "(Detalle_Compra.codigo_pago= Metodo_pago.codigo_pago );", conect2.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        private void FrmCompras_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            conect2.abrir();
            // cargarDatosProductos(dgvProductos, "Productos");
            cargarDatosCompras(dgvProveedores, "Compras");


            try
            {
                da = new SqlDataAdapter("SELECT nombre_proveedor as 'Nombre del Proveedor' FROM Proveedores", conect2.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dtgprov.DataSource = dt;
                conect2.cerrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de los proveedores", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SqlCommand comando = new SqlCommand("SELECT descripcion_pago FROM Metodo_Pago", conect2.conexion);
                conect2.abrir();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    comboPago.Items.Add(registro["descripcion_pago"].ToString());
                }
                conect2.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                        //metodo para cargar datos en combobox proveedores 
          /*  try
            {
                SqlCommand comando = new SqlCommand("SELECT nombre_proveedor FROM Proveedores", conect2.conexion);
                conect2.abrir();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    comboProveedor.Items.Add(registro["nombre_proveedor"].ToString());
                }
                conect2.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } */

        }


        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipalGerente acceso = new FrmMenuPrincipalGerente();
            acceso.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }



        private void button2_Click_2(object sender, EventArgs e)
        {

            letra = false;
            letra2 = false;
            letra3 = false;


            if (validacion.Espacio_Blanco(errorProvider1, codigoCompra))
            {
                if (validacion.Espacio_Blanco(errorProvider1, codigoCompra))
                    errorProvider1.SetError(codigoCompra, "no se puede dejar en blanco");
            }
            else
            {
                letra = true;
            }


           if (validacion.Espacio_Blanco(errorProvider1, textProveedor))
            {
                if (validacion.Espacio_Blanco(errorProvider1, textProveedor))
                    errorProvider1.SetError(textProveedor, "no se puede dejar en blanco");
            }
            else
            {
                letra2 = true;
            }



            if (validacion.Espacio_Blanco_CB(errorProvider1, comboPago))
            {
                if (validacion.Espacio_Blanco_CB(errorProvider1, comboPago))
                    errorProvider1.SetError(comboPago, "no se puede dejar en blanco");
            }
            else
            {
                letra3 = true;
            }

            if (textProveedor.Enabled==true)
            {
                
                    errorProvider1.SetError(textProveedor, "Seleccione una opcion de abajo");
                    letra3 = false;
            }
            else
            {
                letra3 = true;
            }


            if (letra && letra2 && letra3)
            {
                //---------------------------------------------------------------------------------------------------------------------------------
                //Compras
                try
            {
                if (codigoCompra.Text == string.Empty || textProveedor.Text==string.Empty||comboPago.Text == string.Empty || dateFecha.Text == string.Empty)
                    MessageBox.Show("Porfavor llene o seleccione todos los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                else
                {


                    producto.Codigo_compra = Convert.ToInt32(codigoCompra.Text);
                    if (producto.Codigo_compra == producto.buscarCompra(codigoCompra.Text))
                    {
                        MessageBox.Show("Error el codigo de compra ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                    else if (producto.Codigo_compra == 0 || Convert.ToInt32(codigoCompra.Text) <= 0)
                    {
                        MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        codigoCompra.Clear();
                        codigoCompra.Focus();

                    }
                    else 
                    {
                        FrmProductos produc = new FrmProductos();
                        produc.compra.Text = codigoCompra.Text;
                        produc.fecha.Text = dateFecha.Value.ToString("yyyy/MM/dd");
                        produc.proveedor.Text = proveedorSeleccionado;
                        produc.pago.Text = comboPago.SelectedItem.ToString();

                        produc.Show();
                        this.Close();

                       codigoCompra.Clear();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FrmMenuPrincipalGerente gerente = new FrmMenuPrincipalGerente();
            gerente.Show();
            this.Close();
        }

        private void codigoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void comboPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void codigoCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string proveedorSeleccionado;
        int poc1;

        private void dtgprov_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //poc1 = -1;
            poc1 = dtgprov.CurrentRow.Index;
            proveedorSeleccionado = dtgprov[0, poc1].Value.ToString();
            textProveedor.Text = dtgprov[0, poc1].Value.ToString();
            textProveedor.Enabled = false;
        }

        private void dtgprov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dtgprov.CurrentRow.Index;
            proveedorSeleccionado = dtgprov[0, poc1].Value.ToString();
            textProveedor.Text = dtgprov[0, poc1].Value.ToString();
            textProveedor.Enabled = false;
        }

        private void dtgprov_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dtgprov.CurrentRow.Index;
            proveedorSeleccionado = dtgprov[0, poc1].Value.ToString();
            textProveedor.Text = dtgprov[0, poc1].Value.ToString();
            textProveedor.Enabled = false;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            textProveedor.Text = "";
            codigoCompra.Text = "";
            comboPago.SelectedIndex = -1;
            textProveedor.Enabled = true;
        }

        private void textProveedor_TextChanged(object sender, EventArgs e)
        {
            var aux = new MetodoBuscarProveedor();
            aux.filtrar(dtgprov, this.textProveedor.Text.Trim());
            errorProvider1.Clear();
        }
    }



}


