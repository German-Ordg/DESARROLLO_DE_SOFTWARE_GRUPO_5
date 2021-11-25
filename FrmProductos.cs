
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        int contador = 0;

        SqlDataAdapter da;
        DataTable dt;

        //Quitar boton X de la ventana
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

        //Cargar datos de Productos En el data
        public void cargarDatosProductos(DataGridView dgv)//Metodo cargar dato productos
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Pro_ver_productos", conect2.conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter(cmd);        
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //boton de Agregar productos a la compra
        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                double validar = Convert.ToDouble(precioActual.Text);
            }
            catch (Exception)
            {
                errorProvider1.SetError(precioActual, "Escriba un Valor Valido");
                return;
            }
            try
            {
                double validar = Convert.ToDouble(descuento.Text);
            }
            catch (Exception)
            {
                errorProvider1.SetError(descuento, "Escriba un Valor Valido");
                return;
            }

            letra = false;
            letra2 = false;
            letra3= false;
            letra4 = false;
            letra5 = false;
            letra6 = false;
            letra7 = false;
            

            if (validacion.Espacio_Blanco(errorProvider1, descripcionProducto))
            {
                    errorProvider1.SetError(descripcionProducto, "no se puede dejar en blanco");             
            }
            else
            {
                letra = true;
            }
            if (validacion.Espacio_Blanco(errorProvider1, txtcategoria))
            {             
                    errorProvider1.SetError(txtcategoria, "no se puede dejar en blanco");
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
            if (txtcategoria.Enabled == true)
            {

                errorProvider1.SetError(txtcategoria, "Seleccione una opcion de abajo");
                letra3 = false;
            }
            else
            {
                letra3 = true;
            }

            if (letra && letra2 && letra3 && letra4 && letra5 && letra6&& letra7 )
            {

                if (Convert.ToDouble(precioActual.Text) < Convert.ToDouble(precioCompra.Text) || Convert.ToDouble(descuento.Text)> Convert.ToDouble(precioActual.Text))
                {
                    if (Convert.ToDouble(precioActual.Text) < Convert.ToDouble(precioCompra.Text))
                    {
                        errorProvider1.SetError(precioActual, "El precio de Venta es menor que el de Compra");
                    }
                    else if (Convert.ToDouble(descuento.Text) > Convert.ToDouble(precioActual.Text)) { errorProvider1.SetError(descuento, "Descuento es mayor que el precio de venta"); }

                }
                else
                {
                    try
                    {
                        if (codigoProducto.Text == string.Empty || descripcionProducto.Text == string.Empty || txtcategoria.Text == string.Empty || precioCompra.Text == string.Empty || precioActual.Text == string.Empty || cantidad.Text == string.Empty || descuento.Text == string.Empty)
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
                                errorProvider1.SetError(codigoProducto, "Ingrese un valor mayor a cero");                                
                                codigoProducto.Clear();
                                codigoProducto.Focus();
                            }
                            else if (producto.Precio_actual == 0 || producto.Precio_actual <= 0)
                            {
                                errorProvider1.SetError(precioActual, "Ingrese un valor mayor a cero");
                                precioActual.Clear();
                                precioActual.Focus();
                            }

                            else if (producto.Precio_compra == 0 || producto.Precio_compra <= 0)
                            {
                                errorProvider1.SetError(precioCompra, "Ingrese un valor mayor a cero");
                                precioCompra.Clear();
                                precioCompra.Focus();
                            }

                            else if (producto.Cantidad == 0 || producto.Cantidad <= 0)
                            {
                                errorProvider1.SetError(cantidad, "Ingrese un valor mayor a cero");
                                cantidad.Clear();
                                cantidad.Focus();
                            }

                            else if (producto.Descuento < 0)
                            {                               
                                errorProvider1.SetError(descuento, "Ingrese un valor mayor a cero");
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

                                foreach (DataGridViewRow row in dgvProductosCompra.Rows)
                                {
                                    if (codigoProducto.Text == Convert.ToString(row.Cells["CodProductodgv"].Value))
                                    {
                                        igual = true;
                                        errorProvider1.SetError(codigoProducto, "Ya agrego este producto anteriormente a la factura");
                                    }
                                }
                                if (igual == false)
                                {
                                 
                                    contador++;

                                    producto.Codigo_producto = Convert.ToInt32(codigoProducto.Text);
                                    int RowsEscribir = dgvProductosCompra.Rows.Count ;
                                    dgvProductosCompra.Rows.Add(1);
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[0].Value = codigoProducto.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[1].Value = descripcionProducto.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[2].Value = txtcategoria.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[3].Value = talla.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[4].Value = precioCompra.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[5].Value = precioActual.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[6].Value = cantidad.Text;
                                    dgvProductosCompra.Rows[RowsEscribir].Cells[7].Value = descuento.Text;

                                    totalCompra();

                                    codigoProducto.Clear();
                                    descripcionProducto.Clear();
                                    cantidad.Clear();
                                    precioActual.Clear();
                                    descuento.Clear();
                                    talla.Clear();
                                    txtcategoria.Clear();
                                    descripcionProducto.Clear();
                                    precioCompra.Clear();
                                    txtcategoria.Enabled = true;
                                    descripcionProducto.Enabled = true;
                                    codigoProducto.Enabled = true;
                                    talla.Enabled = true;
                                    btnquitar.Visible = false;
                                    btnEliminarCompra.Visible = true;
                                    dtgprov.Enabled = true;
                                    btnreseleccionar.Visible = false;
                                    errorProvider1.Clear();


                                }                          

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

        //Mostrar suma total de la compra
        private void totalCompra() {
            double total = 0;
            foreach (DataGridViewRow row in dgvProductosCompra.Rows)
            {

                double subcompra = Convert.ToDouble(row.Cells["PrecioCompradgv"].Value);
                double subcantidad = Convert.ToDouble(row.Cells["Cantidaddgv"].Value);
                total = total + (subcompra * subcantidad);

            }
            lbltotal.Visible = true;
            lbltotal.Text = "Total de la Compra: Lps." + Convert.ToString(total);
        }

        //Cargar las descripciones de las categorias en el dtgprov
        private void cargarCategorias() {
            try
            {
                da = new SqlDataAdapter("SELECT [descripcion_categoria] as 'Categoria' FROM Categoria_Producto", conect2.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dtgprov.DataSource = dt;
                conect2.cerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos de los proveedores", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Carga del Formulario
        private void FrmProductos_Load(object sender, EventArgs e)
        {

            txtDescripcion.Enabled = false;
            txtCodigo.Enabled = false;
            timer1.Enabled = true;
   
            //Obtener valores de pantalla para poder centrarlo bien ya que teniamos problemas con el starposicion
            /*Screen resPantalla = Screen.PrimaryScreen;
            int height = resPantalla.Bounds.Height;
            int width = resPantalla.Bounds.Width;
            int posY = height -1000; 
            int posX = width -1650; 
            this.Location = new Point(posX, posY);*/
            //

            cargarDatosProductos(dgvProductos);
            cargarCategorias();
        }

        //Boton de btnEndCompra terminar la compra      
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (dgvProductosCompra.RowCount<=0)
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

                    foreach (DataGridViewRow row in dgvProductosCompra.Rows)
                        {
                        try
                        {
                            producto.Codigo_producto = Convert.ToInt32(row.Cells["CodProductodgv"].Value);

                            if (producto.buscarProducto() != producto.Codigo_producto) //Si el producto no existe
                            {
                                producto.Codigo_producto = Convert.ToInt32(row.Cells["CodProductodgv"].Value);
                                producto.Descripcion = Convert.ToString(row.Cells["descripciondgv"].Value);
                                producto.Cantidad = Convert.ToInt32(row.Cells["Cantidaddgv"].Value);
                                producto.Precio_actual = Convert.ToDouble(row.Cells["PrecioVentadgv"].Value);
                                producto.Descuento = Convert.ToDouble(row.Cells["descuentodgv"].Value);
                                producto.Talla = Convert.ToString(row.Cells["talladgv"].Value);
                                producto.Descripcion_Categoria = Convert.ToString(row.Cells["categoriadgv"].Value);
                                producto.buscarCategoria();
                                producto.agregarProducto();
                                cargarDatosProductos(dgvProductos);
                            }

                            else
                                if (producto.buscarProducto() == producto.Codigo_producto) //Si el producto ya existe
                            {


                                producto.Codigo_producto = Convert.ToInt32(row.Cells["CodProductodgv"].Value);
                                int cant = producto.buscarProducto2(Convert.ToString(row.Cells["CodProductodgv"].Value));
                                producto.Cantidad = Convert.ToInt32(row.Cells["Cantidaddgv"].Value) + cant;
                                producto.Precio_actual = Convert.ToDouble(row.Cells["PrecioVentadgv"].Value);
                                producto.Descuento = Convert.ToDouble(row.Cells["descuentodgv"].Value);

                                producto.actualizarProducto();
                                cargarDatosProductos(dgvProductos);

                            }

                            producto.Cantidad_compra = Convert.ToInt32(row.Cells["Cantidaddgv"].Value);
                            producto.Precio_compra = Convert.ToDouble(row.Cells["PrecioCompradgv"].Value);
                            producto.agregarDetalleCompra();
                            Bitacora bitacora = new Bitacora();
                            bitacora.compraRealizada();
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

        //Accion al clickear el Boton de seleccionar button3
        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtcategoria.Enabled = false;
            descripcionProducto.Enabled = false;
            codigoProducto.Enabled = false;
            talla.Enabled = false;
            btnquitar.Visible = true;
            precioCompra.Text = "";
            cantidad.Text = "";
            txtcategoria.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            codigoProducto.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
            descripcionProducto.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            precioActual.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            descuento.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            talla.Text = dgvProductos.CurrentRow.Cells[6].Value.ToString();
            dtgprov.Enabled = false;

        }

        //accion al seleccionar una opcion de la lista desplegable de "Busqueda por"
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2_events();
        }

        //Acciones depende el elemento que se selecciono en la lista deplegable
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
                if (selection == 0)//la primera opcion de descripcion
                {
                    txtDescripcion.Enabled = true;
                    txtDescripcion.Visible = true;
                    txtCodigo.Visible = false;
                    txtCodigo.Enabled = false;
                    txtDescripcion.Clear();
                    txtCodigo.Clear();
                }
                else//la segunda opcion de Codigo
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

        //Accion de buscar con el filtro
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var aux = new Buscar_CodigoFrmProductos();
            aux.filtrar1(dgvProductos, this.txtCodigo.Text.Trim());
        }

        //Accion de buscar con el otro filtro
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var aux = new MetodoBuscarDescripcion();
            aux.filtrar(dgvProductos, this.txtDescripcion.Text.Trim());
        }

        //Accion de cancelar la compra
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea Cancelar la compra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmCompras compras = new FrmCompras();
                compras.txtNumeroFactura.Text = compra.Text;
                compras.Show();
                this.Close();
            }
        }

        //Solo permitir numeros en el filtro
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

        //Permitir solo numeros en el precio de compra
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

        //Permitir solo numeros en el precio actual
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

        //Permitir solo numeros en la cantidad
        private void cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        //Permitir solo numeros en el descuento
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

        //Cargar fecha en el toolStrip
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        //Cargar fecha de la Pc
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        //Accion del boton quitar seleccion
        private void button1_Click(object sender, EventArgs e)
        {
            txtcategoria.Enabled = true;
            descripcionProducto.Enabled = true;
            codigoProducto.Enabled = true;
            talla.Enabled = true;
            btnquitar.Visible = false;
            dtgprov.Enabled = true;
        }

        //No perimitir 0 de primero en el codigo de producto
        private void codigoProducto_TextChanged(object sender, EventArgs e)
        {
            if (codigoProducto.Text.Substring(0) == "0") {
                codigoProducto.Text = "";
            }
            
        }

        //Solo perimitir numeros en el Codigo de Producto
        private void codigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        //Accion de dar doble click en una celda del dtgprov
        int poc1;
        string categoriaSeleccionada;
        private void dtgprov_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dtgprov.CurrentRow.Index;
            categoriaSeleccionada = dtgprov[0, poc1].Value.ToString();
            txtcategoria.Text = dtgprov[0, poc1].Value.ToString();
            txtcategoria.Enabled = false;
            btnreseleccionar.Visible = true;
            dtgprov.Enabled = false;

        }

        //Accion de dar click en una celda del dtgprov
        private void dtgprov_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dtgprov.CurrentRow.Index;
            categoriaSeleccionada = dtgprov[0, poc1].Value.ToString();
            txtcategoria.Text = dtgprov[0, poc1].Value.ToString();
            txtcategoria.Enabled = false;
            btnreseleccionar.Visible = true;
            dtgprov.Enabled = false;
            
        }

        //Accion dek filtro en buscar por categoria
        private void txtcategoria_TextChanged(object sender, EventArgs e)
        {
                var aux = new MetodoBuscarProveedor();
                aux.filtrarCategoria(dtgprov, this.txtcategoria.Text.Trim());
                errorProvider1.Clear();
        }

        //Accion del boton reseleccionar
        private void btnreseleccionar_Click(object sender, EventArgs e)
        {
            txtcategoria.Enabled = true;
            btnreseleccionar.Visible = false;
            dtgprov.Enabled = true;
        }

        //Boton de eliminar producto de la compra
        private void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            if (dgvProductosCompra.SelectedRows.Count != 0)
            {

                try { 
                    dgvProductosCompra.Rows.RemoveAt(dgvProductosCompra.CurrentRow.Index);
                    totalCompra();
                    if (dgvProductosCompra.RowCount <= 0) { btnEliminarCompra.Visible = false;lbltotal.Visible = false; }
                }
                catch
                {
                    MessageBox.Show("No se puede eliminar esta fila", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No ha seleccionado un FILA a borrar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtcategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
             poc1 = dtgprov.CurrentRow.Index;
            categoriaSeleccionada = dtgprov[0, poc1].Value.ToString();
            txtcategoria.Text = dtgprov[0, poc1].Value.ToString();
            txtcategoria.Enabled = false;
            btnreseleccionar.Visible = true;
            dtgprov.Enabled = false;
            }
        }
    }
}

