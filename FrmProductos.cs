
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Pantallas_proyecto
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {

            InitializeComponent();

        }
        private bool letra = false;
        private bool letra2 = false;
        private bool letra3 = false;
        private bool letra4 = false;
        private bool letra5 = false;
        private bool letra6 = false;
        private bool letra7 = false;
        

        ClsConexionBD conect2 = new ClsConexionBD();
        Productos producto = new Productos();
        FrmCompras compras = new FrmCompras();
        validaciones validacion = new validaciones();
        ClsConexionBD conect = new ClsConexionBD();

        string[,] productosArrays = new string[20, 8];

        int contador = 0;

        SqlDataAdapter da;
        DataTable dt;
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


        private void label2_Click(object sender, EventArgs e)
        {

        }





        public void cargarDatosProductos(DataGridView dgv, string nombreTabla)//Metodo cargar dato productos
        {
            try
            {
                da = new SqlDataAdapter("Select codigo_producto Codigo,Categoria_Producto.descripcion_categoria Categoria, descripcion_producto Descripción, cantidad_existente Cantidad,precio_actual Precio , descuento_producto Descuento , talla  " +
                    "From " + nombreTabla + ", Categoria_Producto Where Categoria_Producto.codigo_categoria = Productos.codigo_categoria ", conect2.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            letra = false;
            letra2 = false;
            letra3= false;
            letra4 = false;
            letra5 = false;
            letra6 = false;
            letra7 = false;
            

            if (validacion.Espacio_Blanco(errorProvider1, descripcionProducto))
            {
                if (validacion.Espacio_Blanco(errorProvider1, descripcionProducto))
                    errorProvider1.SetError(descripcionProducto, "no se puede dejar en blanco");
               
            }
            else
            {
                letra = true;
            }

            if (validacion.Espacio_Blanco_CB(errorProvider1, cmbCategoria))
            {
                if (validacion.Espacio_Blanco_CB(errorProvider1, cmbCategoria))
                    errorProvider1.SetError(cmbCategoria, "no se puede dejar en blanco");

            }
            else
            {
                letra2 = true;
            }


            if (validacion.Espacio_Blanco(errorProvider1, precioCompra) )
            {
                if (validacion.Espacio_Blanco(errorProvider1, precioCompra))
                    errorProvider1.SetError(precioCompra, "no se puede dejar en blanco");
               
            }
            else
            {
                letra3 = true;
            }


            if (validacion.Espacio_Blanco(errorProvider1, precioActual))
            {
                if (validacion.Espacio_Blanco(errorProvider1, precioActual))
                    errorProvider1.SetError(precioActual, "no se puede dejar en blanco");
              
            }
            else
            {
                letra4= true;
            }

            if (validacion.Espacio_Blanco(errorProvider1, cantidad) || validacion.Solo_Numeros(errorProvider1, cantidad))
            {
                if (validacion.Espacio_Blanco(errorProvider1, cantidad))
                    errorProvider1.SetError(cantidad, "no se puede dejar en blanco");
                else
                    if (validacion.Solo_Numeros(errorProvider1, cantidad))
                    errorProvider1.SetError(cantidad, "solo se permite numeros enteros");
            }
            else
            {
                letra5 = true;
            }


            if (validacion.Espacio_Blanco(errorProvider1, descuento))
            {
                if (validacion.Espacio_Blanco(errorProvider1, descuento))
                    errorProvider1.SetError(descuento, "no se puede dejar en blanco");
            }
            else
            {
                letra6 = true;
            }

            if (validacion.Espacio_Blanco(errorProvider1, codigoProducto))
            {
                if (validacion.Espacio_Blanco(errorProvider1, codigoProducto))
                    errorProvider1.SetError(codigoProducto, "no se puede dejar en blanco");

            }
            else
            {
                letra7 = true;
            }

          


            if (letra && letra2 && letra3 && letra4 && letra5 && letra6&& letra7 )
            {

                if (Convert.ToDouble(precioActual.Text) < Convert.ToDouble(precioCompra.Text))
                {
                    
                        errorProvider1.SetError(precioActual, "El precio de Venta es menor que el de Compra");

                }
                else
                {
                    try
                    {
                        if (codigoProducto.Text == string.Empty || descripcionProducto.Text == string.Empty || cmbCategoria.Text == string.Empty || precioCompra.Text == string.Empty || precioActual.Text == string.Empty || cantidad.Text == string.Empty || descuento.Text == string.Empty)
                            MessageBox.Show("Porfavor llene todos los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);



                        else
                        {

                            producto.Codigo_producto = Convert.ToInt32(codigoProducto.Text);
                            producto.Precio_actual = Convert.ToDouble(precioActual.Text);
                            producto.Precio_compra = Convert.ToDouble(precioCompra.Text);
                            producto.Cantidad = Convert.ToInt32(cantidad.Text);
                            producto.Descuento = Convert.ToDouble(descuento.Text);


                            if (producto.Codigo_producto == 0 || producto.Codigo_producto <= 0)
                            {
                                MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                codigoProducto.Clear();
                                codigoProducto.Focus();


                            }



                            else if (producto.Precio_actual == 0 || producto.Precio_actual <= 0)
                            {
                                MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                precioActual.Clear();
                                precioActual.Focus();


                            }

                            else if (producto.Precio_compra == 0 || producto.Precio_compra <= 0)
                            {
                                MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                precioCompra.Clear();
                                precioCompra.Focus();

                            }

                            else if (producto.Cantidad == 0 || producto.Cantidad <= 0)
                            {
                                MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cantidad.Clear();
                                cantidad.Focus();

                            }

                            else if (producto.Descuento < 0)
                            {
                                MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                descuento.Clear();
                                descuento.Focus();

                            }

                            else
                            {
                                bool igual = false;

                                conect.abrir();
                                SqlCommand comando3 = new SqlCommand("select codigo_producto from Productos where  codigo_producto= '" + codigoProducto.Text + "'", conect.conexion);
                                SqlDataReader registro3 = comando3.ExecuteReader();
                                if (registro3.Read() && codigoProducto.Enabled == true)
                                {
                                    igual = true;
                                    errorProvider1.SetError(codigoProducto, "Codigo de Producto asignado a otro");

                                }
                                conect.cerrar();

                                for (int i = 0; i <= contador; i++)
                                {
                                    if (codigoProducto.Text == productosArrays[i, 0])
                                    {
                                        igual = true;
                                        errorProvider1.SetError(codigoProducto, "Ya agrego este producto anteriormente a la factura");
                                    }
                                }
                                if (igual == false)
                                {
                                    productosArrays[contador, 0] = codigoProducto.Text;
                                    productosArrays[contador, 1] = descripcionProducto.Text;
                                    productosArrays[contador, 2] = cmbCategoria.Text;
                                    productosArrays[contador, 3] = talla.Text;
                                    productosArrays[contador, 4] = precioCompra.Text;
                                    productosArrays[contador, 5] = precioActual.Text;
                                    productosArrays[contador, 6] = cantidad.Text;
                                    productosArrays[contador, 7] = descuento.Text;
                                    contador++;

                                    producto.Codigo_producto = Convert.ToInt32(codigoProducto.Text);
                                    int RowsEscribir = dgvProductosCompra.Rows.Count - 1;
                                    dgvProductosCompra.Rows.Add(1);
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[0].Value = codigoProducto.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[1].Value = descripcionProducto.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[2].Value = cmbCategoria.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[3].Value = talla.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[4].Value = precioCompra.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[5].Value = precioActual.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[6].Value = cantidad.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[7].Value = descuento.Text;

                                    codigoProducto.Clear();
                                    descripcionProducto.Clear();
                                    cantidad.Clear();
                                    precioActual.Clear();
                                    descuento.Clear();
                                    talla.Clear();
                                    cmbCategoria.Items.Clear();
                                    descripcionProducto.Clear();
                                    precioCompra.Clear();
                                    cmbCategoria.Enabled = true;
                                    descripcionProducto.Enabled = true;
                                    codigoProducto.Enabled = true;
                                    talla.Enabled = true;
                                    btnquitar.Visible = false;
                                    categorias();
                                }
                                // else
                                // MessageBox.Show("Esta ingresando un producto que ya fue ingresado","Aviso",MessageBoxButtons.OK);

                            }

                        }

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ingresar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
          }


        }

        private void categorias()
        {
            try
            {
                SqlCommand comando = new SqlCommand("SELECT codigo_categoria,descripcion_categoria FROM Categoria_Producto", conect2.conexion);

                conect2.abrir();
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())


                {
                    cmbCategoria.Items.Add(registro["descripcion_categoria"].ToString());

                }
                conect2.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            txtCodigo.Enabled = false;
            timer1.Enabled = true;

            cargarDatosProductos(dgvProductos, "Productos");
            categorias();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (productosArrays[0,0]==null)
            {
                MessageBox.Show("No hay productos en la compra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (MessageBox.Show("¿Seguro que desea terminar la compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {



                        producto.Codigo_compra = Convert.ToInt32(compra.Text);
                        producto.Descripcion_fecha = fecha.Text;
                        producto.Descripcion_proveedor = proveedor.Text;
                        producto.Codigo_proveedor = producto.buscarProveedor(producto.Descripcion_proveedor);
                        producto.Descripcion_pago = pago.Text;
                        producto.Codigo_pago = producto.buscarPago(producto.Descripcion_pago);
                        producto.agregarCompra();




                    }


                    catch (Exception)
                    {

                        MessageBox.Show("Error al ingresar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    for (int u = 0; u < contador; u++)
                    {
                        try
                        {
                            producto.Codigo_producto = Convert.ToInt32(productosArrays[u, 0]);

                            if (producto.buscarProducto(productosArrays[u, 0]) != producto.Codigo_producto)
                            {
                                producto.Codigo_producto = Convert.ToInt32(productosArrays[u, 0]);
                                producto.Descripcion = productosArrays[u, 1];
                                producto.Cantidad = Convert.ToInt32(productosArrays[u, 6]);
                                producto.Precio_actual = Convert.ToDouble(productosArrays[u, 5]);
                                producto.Descuento = Convert.ToDouble(productosArrays[u, 7]);
                                producto.Talla = productosArrays[u, 3];
                                producto.Descripcion_Categoria = productosArrays[u, 2];
                                producto.Categoria = Convert.ToInt32(producto.buscarCategoria(producto.Descripcion_Categoria));
                                producto.agregarProducto();
                                cargarDatosProductos(dgvProductos, "Productos");




                            }

                            else
                                if (producto.buscarProducto(productosArrays[u, 0]) == producto.Codigo_producto)
                            {


                                producto.Codigo_producto = Convert.ToInt32(productosArrays[u, 0]);


                                int cant = producto.buscarProducto2(productosArrays[u, 0]);

                                producto.Cantidad = Convert.ToInt32(productosArrays[u, 6]) + cant;
                                producto.Precio_actual = Convert.ToDouble(productosArrays[u, 5]);
                                producto.Descuento = Convert.ToDouble(productosArrays[u, 7]);

                                producto.actualizarProducto();
                                cargarDatosProductos(dgvProductos, "Productos");



                            }

                            producto.Cantidad_compra = Convert.ToInt32(productosArrays[u, 6]);
                            producto.Precio_compra = Convert.ToDouble(productosArrays[u, 4]);

                            producto.agregarDetalleCompra();
                        }




                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al ingresar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                    }




                    this.Close();
                    FrmCompras fact = new FrmCompras();
                    fact.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            cmbCategoria.Enabled = false;
            descripcionProducto.Enabled = false;
            codigoProducto.Enabled = false;
            talla.Enabled = false;
            btnquitar.Visible = true;
            precioCompra.Text = "";
            cantidad.Text = "";
            cmbCategoria.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            codigoProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            descripcionProducto.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            precioActual.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            descuento.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            talla.Text = dgvProductos.CurrentRow.Cells[6].Value.ToString();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2_events();


        }


        private void comboBox2_events()
        {
            int selection = comboBox2.SelectedIndex;
            if (selection == -1)
            {
                txtDescripcion.Enabled = false;
                txtCodigo.Enabled = false;

            }
            else
            {
                if (selection == 0)
                {
                    txtDescripcion.Enabled = true;
                    txtDescripcion.Visible = true;
                    txtCodigo.Visible = false;
                    txtCodigo.Enabled = false;
                    txtDescripcion.Clear();
                    txtCodigo.Clear();
                }
                else
                {
                    txtDescripcion.Visible = false;
                    txtCodigo.Visible = true;
                    txtDescripcion.Enabled = false;
                    txtCodigo.Enabled = true;
                    txtDescripcion.Clear();
                    txtCodigo.Clear();

                }
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var aux = new Buscar_CodigoFrmProductos();
            aux.filtrar1(dgvProductos, this.txtCodigo.Text.Trim());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var aux = new MetodoBuscarDescripcion();
            aux.filtrar(dgvProductos, this.txtDescripcion.Text.Trim());
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            FrmCompras compras = new FrmCompras();
            compras.codigoCompra.Text = compra.Text;
            compras.Show();
            this.Close();
        }

        private void cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void precioCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void precioCompra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void precioActual_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void descuento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmbCategoria.Enabled = true;
            descripcionProducto.Enabled = true;
            codigoProducto.Enabled = true;
            talla.Enabled = true;
            btnquitar.Visible = false;
        }

        private void codigoProducto_TextChanged(object sender, EventArgs e)
        {
            if (codigoProducto.Text.Substring(0) == "0") {
                codigoProducto.Text = "";
            }
            
        }

        private void codigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }
    }
}

