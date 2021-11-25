using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Pantallas_proyecto
{
    class Productos
    {

        private String descripcion;
        private int codigo_producto;
        private int cantidad;
        private int categoria;
        private double precio_actual;
        private double descuento;
        private string talla;
        private string desCategoria;

        private int codigoCompra;
        private int codigoProveedor;
        private int codigoPago;
        private double precioCompra;
        private double subTotal;
        private int cantidadCompra;
        private string descripcionPago;
        private string descripcionProveedor;
        private string descripcionFecha;

        // encapsulamiento 
        public int Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Cantidad_compra { get => cantidadCompra; set => cantidadCompra = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Precio_actual { get => precio_actual; set => precio_actual = value; }
        public double Precio_compra { get => precioCompra; set => precioCompra = value; }
        public double Sub_total { get => subTotal; set => subTotal = value; }
        public string Talla { get => talla; set => talla = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public string Descripcion_Categoria { get => desCategoria; set => desCategoria = value; }
        public int Codigo_compra { get => codigoCompra; set => codigoCompra = value; }
        public int Codigo_proveedor { get => codigoProveedor; set => codigoProveedor = value; }
        public int Codigo_pago { get => codigoPago; set => codigoPago = value; }
        public string Descripcion_proveedor { get => descripcionProveedor; set => descripcionProveedor = value; }
        public string Descripcion_pago { get => descripcionPago; set => descripcionPago = value; }
        public string Descripcion_fecha { get => descripcionFecha; set => descripcionFecha = value; }

        ClsConexionBD conect2 = new ClsConexionBD(); //Conexion con la base de datos
        SqlCommand cmd; // comandos de sql

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo para agregar productos

        public void agregarProducto()
        {
            conect2.abrir();
            SqlCommand cmd = new SqlCommand("PA_NewProduct", conect2.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo_producto", codigo_producto);
            cmd.Parameters.AddWithValue("@codigo_categoria", Categoria);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@precio_actual", precio_actual);
            cmd.Parameters.AddWithValue("@descuento", descuento);
            cmd.Parameters.AddWithValue("@talla", talla);
            cmd.ExecuteNonQuery();
            conect2.cerrar();

        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo para actualizar productos
        public void actualizarProducto()
        {
            conect2.abrir();
            cmd = new SqlCommand("  Update Productos SET " +
                " cantidad_existente = " + cantidad + ", precio_actual= " + precio_actual + ", descuento_producto = " + descuento + " where codigo_producto= " + codigo_producto, conect2.conexion);
            cmd.ExecuteNonQuery();
            conect2.cerrar();

        }


        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo para agregar compra

        public void agregarCompra()
        {
            conect2.abrir();
            cmd = new SqlCommand(" SET IDENTITY_INSERT Compras ON Insert into Compras (codigo_compra, fecha_compra ) values(" + codigoCompra + ", '" + descripcionFecha + "') SET IDENTITY_INSERT Compras OFF ", conect2.conexion); //Asignacion de valores en la bd
            cmd.ExecuteNonQuery();
            MessageBox.Show("La compra fue realizada", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conect2.cerrar();

        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para agregar detalle compra
        public void agregarDetalleCompra()
        {

            conect2.abrir();

            
            cmd = new SqlCommand(" Insert into Detalle_Compra (codigo_compra, codigo_producto,codigo_proveedor, codigo_pago, cantidad, precio_compra) values(" + codigoCompra + "," + codigo_producto + "," + codigoProveedor + "," + codigoPago + "," + cantidadCompra + "," + precioCompra + ") ", conect2.conexion); //Asignacion de valores en la bd
            cmd.ExecuteNonQuery();
            conect2.cerrar();

        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para buscar Categoria
        public void buscarCategoria()
        {

            conect2.abrir();

            string query = "Select codigo_categoria from Categoria_Producto where descripcion_categoria ='" + desCategoria + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            categoria = Convert.ToInt32(command.ExecuteScalar());
            conect2.cerrar();
          
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para buscar Proveedor
        public int buscarProveedor(String dgv)
        {

            conect2.abrir();

            string query = "Select *from Proveedores where nombre_proveedor =" + "'" + descripcionProveedor + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());

            conect2.cerrar();
            return lastId;


        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para buscar Tipo de Pago
        public int buscarPago(String dgv)
        {

            conect2.abrir();


            string query = "Select *from Metodo_Pago where descripcion_pago =" + "'" + descripcionPago + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());

            conect2.cerrar();
            return lastId;


        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para buscar Compra
        public int buscarCompra(String dgv)
        {

            conect2.abrir();

            string query = "Select *from Compras where codigo_compra =" + codigoCompra ;
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());

            conect2.cerrar();
            return lastId;


        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para buscar Producto
        public int buscarProducto()
        {

            conect2.abrir();

            string query = "Select * from Productos where codigo_producto =" +  codigo_producto ;
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());

            conect2.cerrar();
            return lastId;

        }
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo  para buscar Cantidad existente de productos
        public int buscarProducto2(String dgv)
        {

            conect2.abrir();


            string query = "Select cantidad_existente from Productos where codigo_producto ="  + codigo_producto ;
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());


            conect2.cerrar();
            return lastId;


        }
    }
}