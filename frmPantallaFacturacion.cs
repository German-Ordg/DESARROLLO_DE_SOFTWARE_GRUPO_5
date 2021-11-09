using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Text.RegularExpressions;

namespace Pantallas_proyecto
{
    public partial class frmPantallaFacturacion : Form
    {

        

        public frmPantallaFacturacion()
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

        //Instancias necesarias para el uso de componentes y también instancas a clases
        SqlCommand cmd;
        SqlDataReader dr;

        ClsConexionBD con = new ClsConexionBD();
        ClsClientes clie = new ClsClientes();
        ClsPantallaFacturacion fac = new ClsPantallaFacturacion();
        validaciones val = new validaciones();

        bool val1 = false, val2 = false, val3 = false;

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //botón de calcular este al tener todos los articulos de la venta actual hace las operaciones y carga los text box de la parte inferior
            btnImprimirFactura.Enabled = true;
            txtImporteAgrabado15.Text = "0";

            double sumaTotales=0;
            double subTotal;
            double descuentos=0;
            double isv;
            double total;


            foreach (DataGridViewRow row in lstCompras.Rows)
            {
                if (row.Cells[5].Value != null)
                    sumaTotales += (Double)double.Parse(row.Cells[5].Value.ToString());
            }

            foreach (DataGridViewRow row in lstCompras.Rows)
            {
                if (row.Cells[4].Value != null)
                    descuentos += (Double)double.Parse(row.Cells[4].Value.ToString());
            }
                  
            subTotal = sumaTotales - descuentos;

            isv = (subTotal) * 0.15;

            total = subTotal + isv;

            txtDescuentosOtorgados.Text = descuentos.ToString();
            txtTotalPagar.Text = total.ToString();
            txtISV15.Text = isv.ToString();
            txtSubTotal.Text = subTotal.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //validación para regresar a la pantalla anterior en caso que la persona sea vendedor o gerente se le mostrarán diferentes cosa
            if (Cashe.UserCache.Position == "Vendedor")
            {
                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                menu.Show();
                this.Hide();
            }
            if (Cashe.UserCache.Position == "Gerente")
            {
                FrmMenuPrincipalGerente menu = new FrmMenuPrincipalGerente();
                menu.Show();
                this.Hide();
            }
            
        }

        private void frmPantallaFacturacion_Load(object sender, EventArgs e)
        {
            //Al cargar el formulario se ejecuta esto para cargar ciertas herramientas 
                                 
            con.abrir();
            fac.cargarComboboxPago(cmbTipoPago);
            fac.cargarComboboxVendedor(cmbVendedor);
            rbSinNombre.Checked = true;
            btnCalcularFactura.Enabled = false;
            btnImprimirFactura.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            timer1.Enabled = true;
            nudCantidad.Value = 1;
           
            this.reportViewer1.RefreshReport();
        }

        private void frmPantallaFacturacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void txtCodProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsPantallaFacturacion.validarSoloNumeros(e);
            
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            val1 = false;
            //validación para los espacios en blanco y sólo numeros del campo de búsqueda de producto
            if (val.Espacio_Blanco(ErrorProvider, txtCodProducto) || val.Solo_Numeros(ErrorProvider, txtCodProducto))
            {
                if (val.Espacio_Blanco(ErrorProvider, txtCodProducto))
                    ErrorProvider.SetError(txtCodProducto, "no se puede dejar en blanco");
                else
                    if (val.Solo_Numeros(ErrorProvider, txtCodProducto))
                    ErrorProvider.SetError(txtCodProducto, "solo se permite numeros");
            }
            else
            {
                val1 = true;
            }

            if (val1)
            {
                //ejecución del query para buscar el producto y también luego para hacer una vista de él en los text box
                if(val.Solo_Numeros(ErrorProvider,txtCodProducto)==false)
                {
                    fac.CodigoProducto = Int32.Parse(txtCodProducto.Text);


                    String buscarProducto = "SELECT [descripcion_producto] descripcion, " +
                        "[cantidad_existente] cantidad, [precio_actual] precio, " +
                        "[descuento_producto] descuento FROM [dbo].[Productos] " +
                        "WHERE [codigo_producto]=" + fac.CodigoProducto;

                    con.abrir();
                    try
                    {

                        cmd = new SqlCommand(buscarProducto, con.conexion);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                fac.DescripcionProducto = dr["descripcion"].ToString();
                                fac.CantidadInventario = Int32.Parse(dr["cantidad"].ToString());
                                fac.PrecioProducto = Double.Parse(dr["precio"].ToString());
                                fac.DescuentoProducto = Double.Parse(dr["descuento"].ToString());

                            }
                            dr.Close();

                            txtDescuento.Text = fac.DescuentoProducto.ToString();
                            txtPrecioUnitario.Text = fac.PrecioProducto.ToString();
                            txtDescripcion.Text = fac.DescripcionProducto;
                            btnAgregar.Enabled = true;
                        }
                        else
                        {
                            dr.Close();
                            MessageBox.Show("No existe el producto en el sistema");
                            txtDescuento.Clear();
                            txtPrecioUnitario.Clear();
                            txtDescripcion.Clear();
                            btnAgregar.Enabled = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar el producto" + ex.ToString());
                    }
                }
                else
                {
                   
                }
                
            }
            else
            {
                MessageBox.Show("Por favor ingrese un código de producto","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
           
        }

        private void rbConNombre_CheckedChanged(object sender, EventArgs e)
        {
            //esto hace que se muertren ciertos controladores en caso que la factura sea con nombre 
            lblRTN.Show();
            txtRTN.Show();
            txtNombreCliente.Show();
            lblNombre.Show();
        }

        private void rbSinNombre_CheckedChanged(object sender, EventArgs e)
        {
            //esto hace que se oculten ciertos controladores cuando la factura es sin nombre
            lblRTN.Hide();
            txtRTN.Hide();
            txtNombreCliente.Hide();
            lblNombre.Hide();

            txtRTN.Clear();
            txtNombreCliente.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            btnImprimirFactura.Enabled = false;

            //esto valida que no se ingrese el mismo producto dos veces en la venta actual
            bool validar = lstCompras.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["CodProducto"].Value) == txtCodProducto.Text);

            if (!validar)
            {
                //esto ingresa los datos del producto en el data grid view
                if (nudCantidad.Value <= fac.CantidadInventario)
                {
                    if (nudCantidad.Value > 0)
                    {
                        btnEliminar.Enabled = true;
                        btnEditar.Enabled = true;
                        btnCalcularFactura.Enabled = true;

                        fac.CantidadProducto = Int32.Parse(nudCantidad.Value.ToString());

                        int indiceDataGrid = lstCompras.Rows.Count - 1;
                        lstCompras.Rows.Add(1);

                        double total = (fac.PrecioProducto * fac.CantidadProducto) - fac.DescuentoProducto;

                        lstCompras.Rows[indiceDataGrid].Cells[0].Value = fac.CodigoProducto.ToString();
                        lstCompras.Rows[indiceDataGrid].Cells[1].Value = fac.CantidadProducto.ToString();
                        lstCompras.Rows[indiceDataGrid].Cells[2].Value = fac.DescripcionProducto.ToString();
                        lstCompras.Rows[indiceDataGrid].Cells[3].Value = fac.PrecioProducto.ToString();
                        lstCompras.Rows[indiceDataGrid].Cells[4].Value = fac.DescuentoProducto.ToString();
                        lstCompras.Rows[indiceDataGrid].Cells[5].Value = total.ToString();

                        txtCodProducto.Clear();
                        txtDescripcion.Clear();
                        txtDescuento.Clear();
                        txtPrecioUnitario.Clear();
                        nudCantidad.Value = 1;
                        btnAgregar.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Ingrese un número válido en la cantidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("No hay suficiente cantidad en el inventario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se puede duplicar el producto en la tabla", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ae utiliza para los toolStrip que están abajo de la pantalla
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
           
        }

        private void lstCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void editar(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstCompras.CurrentRow != null)
            {
                //Esto se ejecuta al editar uno de los productos del datagrid 
                if (lstCompras.CurrentRow.Index != lstCompras.RowCount - 1)
                {
                    txtCodProducto.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnBuscarProducto.Enabled = false;
                    btnEditar.Enabled = false;
                    btnActualizar.Enabled = true;
                    btnCalcularFactura.Enabled = false;
                    btnImprimirFactura.Enabled = false;
                    btnEliminar.Enabled = false;

                    int a = lstCompras.CurrentRow.Index;
                    txtCodProducto.Text = lstCompras.Rows[a].Cells[0].Value.ToString();
                    nudCantidad.Value = Int32.Parse(lstCompras.Rows[a].Cells[1].Value.ToString());
                    txtDescripcion.Text = lstCompras.Rows[a].Cells[2].Value.ToString();
                    txtPrecioUnitario.Text = lstCompras.Rows[a].Cells[3].Value.ToString();
                    txtDescuento.Text = lstCompras.Rows[a].Cells[4].Value.ToString();
                    lstCompras.Enabled = false;

                    fac.CodigoProducto = Int32.Parse(lstCompras.Rows[a].Cells[0].Value.ToString());
                    fac.CantidadProducto = Int32.Parse(lstCompras.Rows[a].Cells[1].Value.ToString());
                    fac.DescripcionProducto = lstCompras.Rows[a].Cells[2].Value.ToString();
                    fac.PrecioProducto = Double.Parse(lstCompras.Rows[a].Cells[3].Value.ToString());
                    fac.DescuentoProducto = Double.Parse(lstCompras.Rows[a].Cells[4].Value.ToString());


                    String buscarProducto = "SELECT [cantidad_existente] cantidad  FROM [dbo].[Productos] " +
                        "WHERE [codigo_producto]=" + fac.CodigoProducto;

                    con.abrir();
                    //´se ejecuta la consulta para saber la cantidad actual que hay en la base de datos de dicho producto
                    try
                    {

                        cmd = new SqlCommand(buscarProducto, con.conexion);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            fac.CantidadInventario = Int32.Parse(dr["cantidad"].ToString());
                        }
                        dr.Close();
                                           
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la cantidad en inventario" + ex.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("No se puede ediar esta fila", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //actualiza los totales de la venta para poder realizarla
            if (nudCantidad.Value <= fac.CantidadInventario)
            {
                if (nudCantidad.Value >= 1)
                {
                    int n = lstCompras.CurrentRow.Index;
                    double total = Int32.Parse(nudCantidad.Value.ToString()) * fac.PrecioProducto;

                    lstCompras.Rows[n].Cells[0].Value = fac.CodigoProducto.ToString();
                    lstCompras.Rows[n].Cells[1].Value = nudCantidad.Value.ToString();
                    lstCompras.Rows[n].Cells[2].Value = fac.DescripcionProducto.ToString();
                    lstCompras.Rows[n].Cells[3].Value = fac.PrecioProducto.ToString();
                    lstCompras.Rows[n].Cells[4].Value = fac.DescuentoProducto.ToString();
                    lstCompras.Rows[n].Cells[5].Value = total.ToString();

                    lstCompras.Enabled = true;
                    btnAgregar.Enabled = true;
                    txtCodProducto.Enabled = true;
                    btnCalcularFactura.Enabled = true;
                    btnEliminar.Enabled = true;

                    txtCodProducto.Clear();
                    txtDescripcion.Clear();
                    txtDescuento.Clear();
                    txtPrecioUnitario.Clear();
                    nudCantidad.Value = 1;
                    btnActualizar.Enabled = false;
                    btnBuscarProducto.Enabled = true;
                    btnEditar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Se tiene que ingresar al menos 1 artículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay suficiente cantidad en el inventario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //eliminar un producto del datagrid hace la validación para saber si hay una fila seleccionada
            if (lstCompras.SelectedRows.Count != 0)
            {
                btnImprimirFactura.Enabled = false;

                if(lstCompras.CurrentRow.Index != lstCompras.RowCount - 1)
                {
                    lstCompras.Rows.RemoveAt(lstCompras.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("No se puede eliminar esta fila", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("No ha seleccionado un ítem a borrar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //validación y búsqueda del cliente en la base de datos 
            if(txtRTN.Text.Length!=0)
            {

                String consultaRTN = "select [nombre_cliente], [apellido_cliente], [rtn] from [dbo].[Clientes] where [rtn] = "+txtRTN.Text;


                con.abrir();
                //ejecución del query de la búsqueda del cliente
                try
                {
                    cmd = new SqlCommand(consultaRTN, con.conexion);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        clie.NombreCliente = dr["nombre_cliente"].ToString();
                        clie.ApellidoCliente = dr["apellido_cliente"].ToString();
                        clie.Rtn = dr["rtn"].ToString();
                        
                    }
                    dr.Close();

                    MessageBox.Show("Nombre del cliente: "+clie.NombreCliente+" "+clie.ApellidoCliente, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.cerrar();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No ha encontrado el cliente en la base de datos" + ex.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else
            {
                MessageBox.Show("Ingrese un RTN", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            //vuelve a cargar el formulario para borrar la venta actual
            if (lstCompras.DataSource is DataTable)
            {
                lstCompras.Rows.Clear();
                lstCompras.Refresh();
            }
        }



        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {

            val2 = false;
            val3 = false;


            //validaciones de los campos en caso que la factura sea con nombre 
            if (rbConNombre.Checked)
            {
                if (val.Solo_Numeros(ErrorProvider, txtRTN))
                {

                    if (val.Solo_Numeros(ErrorProvider, txtRTN))
                        ErrorProvider.SetError(txtRTN, "No se permiten letras ni dejar en blanco");
                }
                else
                {
                    val2 = true;
                }

                if (val.Solo_Letras(ErrorProvider, txtNombreCliente))
                {

                    if (val.Solo_Letras(ErrorProvider, txtNombreCliente))
                        ErrorProvider.SetError(txtNombreCliente, "No se permiten números ni dejar en blanco");
                }
                else
                {
                    val3 = true;
                }


            }



            //validaciones anidadas para ejecutar el query de la venta
            if (lstCompras.RowCount<2)
            {
                MessageBox.Show("No hay items en la lista", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnImprimirFactura.Enabled = false;
            }
            else
            {
                if (cmbTipoPago.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cmbVendedor.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione un vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (lstCompras.RowCount == -1)
                        {
                            MessageBox.Show("Ingrese un producto a comprar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (rbConNombre.Checked == false && rbSinNombre.Checked == false)
                            {
                                MessageBox.Show("Seleccione si la factura es con nombre o sin nombre", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (rbConNombre.Checked && val2 && val3)
                                {
                                    if (txtRTN.TextLength == 0)
                                    {
                                        MessageBox.Show("Ingrese el RTN del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (txtNombreCliente.TextLength == 0)
                                        {
                                            MessageBox.Show("Ingrese el nombre del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                           
                                            if (!Regex.IsMatch(txtRTN.Text, "^((010[1-8]|020[1-9]|0210|030[1-9]|031[0-9]|032[0-1]|040[1-9]|041[0-9]|042[0-3]|050[1-9]|051[0-2]|060[1-9]|061[0-6]|070[1-9]|071[0-9]|080[1-9]|081[0-9]|082[0-8]|090[1-6]|100[1-9]|101[0-7]|110[1-4]|120[1-9]|121[0-9]|130[1-9]|131[0-9]|132[0-8]|140[1-9]|141[0-6]|150[1-9]|151[0-9]|152[0-3]|160[1-9]|161[0-9]|162[0-8]|170[1-9]|180[1-9]|181[0-1]))+((19[0-9]{2}|200[0-3])+(([0-9]){6}))$"))
                                            {
                                                MessageBox.Show("El RTN no es válido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                //llamada a las funciones las cuales ejecutan el ingreso de la venta en la base de datos
                                                ingresar();
                                                reporte();
                                                ((Control)this.tabPage1).Enabled = false;
                                            }


                                            
                                        }
                                    }
                                }
                                //validación para las 
                                if (rbSinNombre.Checked)
                                {

                                    //llamada a las funciones las cuales ejecutan el ingreso de la venta en la base de datos
                                    ingresar();
                                    Bitacora bitacora = new Bitacora();
                                    bitacora.ventaRealizada();
                                    reporte();
                                    ((Control)this.tabPage1).Enabled = false;
                                }

                            }
                        }
                    }
                }
            }
            

        }


        public void ingresar()
        {
            //codigo para ingresar una nueva venta
            String codigoEmpleado="";
            String codigoPago="";

            con.abrir();

            String tipoPago = cmbTipoPago.SelectedItem.ToString().Trim();
            String vendedor = cmbVendedor.SelectedItem.ToString().Trim();

            //consultas para extraer código del empleado y el código del tipo de pago de la base de datos
            String consultaEmpleado = "select a.codigo_empleado from [dbo].[Usuarios] a join [dbo].[Empleados] b " +
                "on a.codigo_empleado = b.codigo_empelado where b.[nombre_empleado]+' '+b.[apellido_empleado]= @vendedor";

            String consultaPago = "select [dbo].[Metodo_Pago].codigo_pago from [dbo].[Metodo_Pago]  " +
                "where [dbo].[Metodo_Pago].descripcion_pago = @pago";

            //ejecucuón de la consulta del vendedor
            try
            {

                cmd = new SqlCommand(consultaEmpleado, con.conexion);
                cmd.Parameters.Add("@vendedor", SqlDbType.NVarChar).Value = vendedor;
                dr = cmd.ExecuteReader();
                
                while(dr.Read())
                {
                    codigoEmpleado = dr["codigo_empleado"].ToString();
                }
                

                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" codigo empleado    "+ex.ToString());
            }


            //ejecución de la consulta del tipo de pago
            try
            {
                cmd = new SqlCommand(consultaPago, con.conexion);
                cmd.Parameters.Add("@pago", SqlDbType.NVarChar).Value = tipoPago;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    codigoPago = dr["codigo_pago"].ToString();
                }
               
                dr.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("codigo de pago    " + ex.ToString());
            }
                                    
            try
            {
                con.abrir();

                //ejecución de la consulta para ingresar la venta actual

                String ingresoVenta = "insert into [dbo].[Ventas] " +
                "([codigo_empleado], [codigo_pago], [nombre_cliente], [rtn_cliente], [fecha_venta], [direccion_envio], [impuesto], [total]) " +
                "values (@codigoEmpleado, @codigoPago, @nombreCliente, @rtn, " +
                "@fecha, @direccionEnvio, @isv15, @totalPagar)";

                SqlCommand cmd = new SqlCommand(ingresoVenta, con.conexion);
                cmd.Parameters.Add("@codigoEmpleado", SqlDbType.Int).Value = Int32.Parse(codigoEmpleado) ;
                cmd.Parameters.Add("@codigoPago", SqlDbType.Int).Value = Int32.Parse(codigoPago);
                cmd.Parameters.Add("@nombreCliente", SqlDbType.NVarChar).Value = txtNombreCliente.Text;
                cmd.Parameters.Add("@rtn", SqlDbType.NVarChar).Value = txtRTN.Text;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = DateTime.Now.ToString();
                cmd.Parameters.Add("@direccionEnvio", SqlDbType.NVarChar).Value = txtDireccion.Text;
                cmd.Parameters.Add("@isv15", SqlDbType.Money).Value = txtISV15.Text;
                cmd.Parameters.Add("@totalPagar", SqlDbType.Money).Value = txtTotalPagar.Text;

                cmd.ExecuteNonQuery();

                con.cerrar();

                con.abrir();

                String reducirCantidad = "update [dbo].[Productos] set [cantidad_existente] = [cantidad_existente] - @cantidadVendida where [codigo_producto] = @codigoProducto";

                cmd = new SqlCommand(reducirCantidad, con.conexion);

                //ingreso de los detalles de los productos a la venta 
                foreach (DataGridViewRow row in lstCompras.Rows)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cantidadVendida", Convert.ToInt32(row.Cells["Cantidad"].Value));
                    cmd.Parameters.AddWithValue("@codigoProducto", Convert.ToInt32(row.Cells["CodProducto"].Value));

                    cmd.ExecuteNonQuery();
                }
                con.cerrar();

                con.abrir();

                String ingresoDetalleVenta = "insert into [dbo].[Detalle_Venta] " +
                "([codigo_venta], [codigo_producto], [cantidad], [precio_venta], [sub_total]) " +
                "values ((select top 1 Ventas.codigo_venta from Ventas order by Ventas.codigo_venta desc), @codigoProducto , @cantidad, @precioVenta, @subTotal)";
                cmd = new SqlCommand(ingresoDetalleVenta, con.conexion);


                foreach (DataGridViewRow row in lstCompras.Rows)
                {
                    //ingresa los daros desglozados de la venta 
                    cmd.Parameters.Clear();
                                     
                    cmd.Parameters.AddWithValue("@codigoProducto", Convert.ToInt32(row.Cells["CodProducto"].Value));
                    cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells["Cantidad"].Value));
                    cmd.Parameters.AddWithValue("@precioVenta", Convert.ToDouble(row.Cells["PrecioUnitario"].Value));
                    cmd.Parameters.AddWithValue("@subTotal", Convert.ToDouble(row.Cells["Total"].Value));

                    cmd.ExecuteNonQuery();

                }

                con.cerrar();

                

            }
            catch (Exception)
            {

            }
        }

        public void reporte()
        {
            //reporte de la facturación que es como se muestra la factura al hacer la venta
            List<impresion> impresion = new List<impresion>();
            ReportParameter[] parameters = new ReportParameter[10];

            //asignación de valor a los atributos del reporte
            string impuesto = txtISV15.Text.Trim();
            string importe = txtImporteAgrabado15.Text.Trim();
            string subtotal = txtSubTotal.Text;
            string total = txtTotalPagar.Text;
            string fecha = DateTime.Now.ToString();
            string rtn = txtRTN.Text;
            string cliente = txtNombreCliente.Text;
            string vendedor = cmbVendedor.SelectedItem.ToString();
            string direccion = txtDireccion.Text;
            string tipoPago = cmbTipoPago.SelectedItem.ToString();
            parameters[0] = new ReportParameter("impuesto", impuesto);
            parameters[1] = new ReportParameter("importe", importe);
            parameters[2] = new ReportParameter("subtotal", subtotal);
            parameters[3] = new ReportParameter("total", total);
            parameters[4] = new ReportParameter("cliente", cliente);
            parameters[5] = new ReportParameter("rtn", rtn);
            parameters[6] = new ReportParameter("fecha", fecha);
            parameters[7] = new ReportParameter("vendedor", vendedor);
            parameters[8] = new ReportParameter("direccion", direccion);
            parameters[9] = new ReportParameter("tipoPago", tipoPago);


            reportViewer1.LocalReport.SetParameters(parameters);

            impresion.Clear();

            //datos que se cargan en la tabla del reporte de la venta
            for (int i = 0; i < lstCompras.Rows.Count - 1; i++)
            {
                impresion imp = new impresion();
                imp.cod_producto = (string)this.lstCompras.Rows[i].Cells[0].Value;
                imp.cantidad = (string)this.lstCompras.Rows[i].Cells[1].Value;
                imp.descripcion = (string)this.lstCompras.Rows[i].Cells[2].Value;
                imp.precio = (string)this.lstCompras.Rows[i].Cells[3].Value;
                imp.descuento = (string)this.lstCompras.Rows[i].Cells[4].Value;
                imp.total = (string)this.lstCompras.Rows[i].Cells[5].Value;
                // });
                impresion.Add(imp);

            }

            this.reportes.SelectedTab = reportes.TabPages["tabPage2"];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", impresion));
            this.reportViewer1.RefreshReport();
        }

        //validación rtn
        private void txtRTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsPantallaFacturacion.validarSoloNumeros(e);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //validación nombre del cliente
        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsPantallaFacturacion.validarSoloLetras(e);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //cargar de nuevo el formulario de facturación para realizar otra venta
        private void btnNuevaFactura_Click(object sender, EventArgs e)
        {
            frmPantallaFacturacion ss = new frmPantallaFacturacion();
            ss.Show();
            this.Close();
        }
    }

    public class impresion
    {
        public string cod_producto { get; set; }
        public string cantidad { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string descuento { get; set; }
        public string total { get; set; }





    }



}
