
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
        private bool validacion1 = false;
        private bool validacion2 = false;
        private bool validacion3 = false;

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

        ClsConexionBD conect2 = new ClsConexionBD();
        Productos producto = new Productos();
        SqlDataAdapter da;
        DataTable dt;


        /*Método creado especialmente para la carga de datos. Por medio de una consulta SQL*/
        public void cargarDatosCompras(DataGridView dgv, string nombreTabla)
        {
            try
            {
                /*Asignación de la consulta SQL a la variable da (data adapter) para cargar 
                los datos de forma adecuada. */
                da = new SqlDataAdapter("Select  Compras.codigo_compra Codigo, Proveedores.nombre_proveedor Proveedor , fecha_compra Fecha , Metodo_Pago.descripcion_pago Pago From " + nombreTabla +
                    ", Detalle_Compra, Proveedores, Metodo_Pago Where (Compras.codigo_compra= Detalle_Compra.codigo_compra ) and (Detalle_Compra.codigo_proveedor=Proveedores.codigo_proveedor) and" +
                    "(Detalle_Compra.codigo_pago= Metodo_pago.codigo_pago );", conect2.conexion);
                /*Se le asigna la creación de una nueva tabla interna a la variable dt para
                 la carga de datos que resulte de la carga de datos.*/
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                /*En caso de que no pudiesen cargarse bien los datos a causa de algún mal
                 funcionamiento tanto de la base de datos o del sistema en general, se 
                liberará una ventana de error.*/
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            dtpFechaCompra.MaxDate = DateTime.Now.AddDays(0);
            dtpFechaCompra.MinDate = DateTime.Now.AddMonths(-1);
            conect2.abrir();
            cargarDatosCompras(dgvCompras, "Compras");

            /*Try-Catch que servirá para la carga de datos de los registros existentes de
             compras que se hayan realizado con anterioridad*/
            try
            {
                da = new SqlDataAdapter("SELECT nombre_proveedor as 'Nombre del Proveedor' FROM Proveedores where codigo_estado=1", conect2.conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgvProveedor.DataSource = dt;
                conect2.cerrar();
            }
            catch(Exception)
            {
                MessageBox.Show("Error al cargar los datos de los proveedores", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*Try-Catch que servirá para carga de datos de los métodos de pago hacia
             un combobox para que el usuario pueda tenerlos a su disposición*/
            try
            {
                SqlCommand comando = new SqlCommand("SELECT descripcion_pago FROM Metodo_Pago", conect2.conexion);
                conect2.abrir();
                SqlDataReader registro = comando.ExecuteReader();
                
                /*El ciclo no se detendrá hasta que se hayan terminado de leer
                 todos los registros dentro de la tabla de la base de datos
                para luego transformarse en String*/
                while (registro.Read())
                {
                    cmbMetodoPago.Items.Add(registro["descripcion_pago"].ToString());
                }
                conect2.cerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /*Validación de espacios en blanco dentro del programa por medio de
         variables de verificación en booleano*/
        private void button2_Click_2(object sender, EventArgs e)
        {

            validacion1 = false;
            validacion2 = false;
            validacion3 = false;

            /*Validación para TextBox del número de facturacción*/
            if (validacion.Espacio_Blanco(errorProvider1, txtNumeroFactura))
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtNumeroFactura))
                    errorProvider1.SetError(txtNumeroFactura, "no se puede dejar en blanco");
            }
            else
            {
                validacion1 = true;
            }

            /*Validación para TextBox del nombre del proveedor*/
           if (validacion.Espacio_Blanco(errorProvider1, txtProveedor))
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtProveedor))
                    errorProvider1.SetError(txtProveedor, "no se puede dejar en blanco");
            }
            else
            {
                validacion2 = true;
            }

            /*Validación para ComboBox de métodos de pago*/
            if (validacion.Espacio_Blanco_CB(errorProvider1, cmbMetodoPago))
            {
                if (validacion.Espacio_Blanco_CB(errorProvider1, cmbMetodoPago))
                    errorProvider1.SetError(cmbMetodoPago, "no se puede dejar en blanco");
            }
            else
            {
                validacion3 = true;
            }

            /*En caso de que no esté validado el ComboBox de 
             métodos de pagos*/
            if (txtProveedor.Enabled==true)
            {
                
                errorProvider1.SetError(txtProveedor, "Seleccione una opcion de abajo");
                validacion3 = false;
            }
            else
            {
                validacion3 = true;
            }


            if (validacion1 && validacion2 && validacion3)
            {
                //Cuando se han logrado aceptar las validaciones de la campos en blanco
                try
                {
                    /*En caso de que se de la presencia de campos en blanco
                     se podrá ejecutar esta sección del código para que el usuario ingrese correctamente
                    a los datos requeridos*/
                    if (txtNumeroFactura.Text == string.Empty || txtProveedor.Text==string.Empty||cmbMetodoPago.Text == string.Empty || dtpFechaCompra.Text == string.Empty)
                        MessageBox.Show("Porfavor llene o seleccione todos los campos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        producto.Codigo_compra = Convert.ToInt32(txtNumeroFactura.Text);
                        if (producto.Codigo_compra == producto.buscarCompra(txtNumeroFactura.Text))
                        {
                            MessageBox.Show("Error el codigo de compra ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (producto.Codigo_compra == 0 || Convert.ToInt32(txtNumeroFactura.Text) <= 0)
                            {
                                MessageBox.Show("Ingrese un valor mayor a cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtNumeroFactura.Clear();
                                txtNumeroFactura.Focus();
                            }
                            else 
                            {
                                FrmProductos produc = new FrmProductos();
                                produc.compra.Text = txtNumeroFactura.Text;
                                produc.fecha.Text = dtpFechaCompra.Value.ToString("yyyy/MM/dd");
                                produc.proveedor.Text = proveedorSeleccionado;
                                produc.pago.Text = cmbMetodoPago.SelectedItem.ToString();
                                produc.Show();
                                this.Close();
                                txtNumeroFactura.Clear();
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

        string proveedorSeleccionado;
        int poc1;

        private void dtgprov_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dgvProveedor.CurrentRow.Index;
            proveedorSeleccionado = dgvProveedor[0, poc1].Value.ToString();
            txtProveedor.Text = dgvProveedor[0, poc1].Value.ToString();
            txtProveedor.Enabled = false;
        }

        private void dtgprov_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dgvProveedor.CurrentRow.Index;
            proveedorSeleccionado = dgvProveedor[0, poc1].Value.ToString();
            txtProveedor.Text = dgvProveedor[0, poc1].Value.ToString();
            txtProveedor.Enabled = false;
        }

        private void dtgprov_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            poc1 = dgvProveedor.CurrentRow.Index;
            proveedorSeleccionado = dgvProveedor[0, poc1].Value.ToString();
            txtProveedor.Text = dgvProveedor[0, poc1].Value.ToString();
            txtProveedor.Enabled = false;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            txtProveedor.Text = "";
            txtNumeroFactura.Text = "";
            cmbMetodoPago.SelectedIndex = -1;
            txtProveedor.Enabled = true;
        }

        private void textProveedor_TextChanged(object sender, EventArgs e)
        {
            var aux = new MetodoBuscarProveedor();
            aux.filtrar(dgvProveedor, this.txtProveedor.Text.Trim());
            errorProvider1.Clear();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }



}


