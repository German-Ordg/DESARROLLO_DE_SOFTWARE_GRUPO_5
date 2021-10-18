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
        private string des_categoria;

        private int codigo_compra;
        private int codigo_proveedor;
        private int codigo_pago;
        private double precio_compra;
        private double sub_total;
        private int cantidad_compra;
        private string descripcion_pago;
        private string descripcion_proveedor;
        private string descripcion_fecha;




        // encapsulamiento 
        public int Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Cantidad_compra { get => cantidad_compra; set => cantidad_compra = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Precio_actual { get => precio_actual; set => precio_actual = value; }
        public double Precio_compra { get => precio_compra; set => precio_compra = value; }
        public double Sub_total { get => sub_total; set => sub_total = value; }
        public string Talla { get => talla; set => talla = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public string Descripcion_Categoria { get => des_categoria; set => des_categoria = value; }
        public int Codigo_compra { get => codigo_compra; set => codigo_compra = value; }
        public int Codigo_proveedor { get => codigo_proveedor; set => codigo_proveedor = value; }
        public int Codigo_pago { get => codigo_pago; set => codigo_pago = value; }
        public string Descripcion_proveedor { get => descripcion_proveedor; set => descripcion_proveedor = value; }

        public string Descripcion_pago { get => descripcion_pago; set => descripcion_pago = value; }

        public string Descripcion_fecha { get => descripcion_fecha; set => descripcion_fecha = value; }

















        ClsConexionBD conect2 = new ClsConexionBD();
        SqlCommand cmd; // comandos de sql



        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //metodo para agregar productos

        public void agregarProducto()
        {
            conect2.abrir();
            cmd = new SqlCommand(" SET IDENTITY_INSERT Productos ON Insert into Productos (codigo_producto, codigo_categoria, descripcion_producto," +
                " cantidad_existente, precio_actual, descuento_producto, talla ) values(" + codigo_producto + ", " + Categoria + ", '" + descripcion + "'," + cantidad + "," + precio_actual + "," + descuento + ",'" + talla + "') SET IDENTITY_INSERT Productos OFF ", conect2.conexion); //Asignacion de valores en la bd
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
            cmd = new SqlCommand(" SET IDENTITY_INSERT Compras ON Insert into Compras (codigo_compra, fecha_compra ) values(" + codigo_compra + ", '" + descripcion_fecha + "') SET IDENTITY_INSERT Compras OFF ", conect2.conexion); //Asignacion de valores en la bd
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

            sub_total = precio_compra * cantidad;
            cmd = new SqlCommand(" Insert into Detalle_Compra (codigo_compra, codigo_producto,codigo_proveedor, codigo_pago, cantidad, precio_compra, sub_total) values(" + codigo_compra + "," + codigo_producto + "," + codigo_proveedor + "," + codigo_pago + "," + cantidad_compra + "," + precio_compra + "," + sub_total + ") ", conect2.conexion); //Asignacion de valores en la bd
            cmd.ExecuteNonQuery();
            conect2.cerrar();

        }

        public void buscarCategoria()
        {

            conect2.abrir();


            string query = "Select codigo_categoria from Categoria_Producto where descripcion_categoria ='" + des_categoria + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            categoria = Convert.ToInt32(command.ExecuteScalar());




            conect2.cerrar();
           


        }


        public int buscarProveedor(String dgv)
        {

            conect2.abrir();


            string query = "Select *from Proveedores where nombre_proveedor =" + "'" + descripcion_proveedor + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());


            conect2.cerrar();
            return lastId;


        }

        public int buscarPago(String dgv)
        {

            conect2.abrir();


            string query = "Select *from Metodo_Pago where descripcion_pago =" + "'" + descripcion_pago + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());


            conect2.cerrar();
            return lastId;


        }


        public int buscarCompra(String dgv)
        {

            conect2.abrir();


            string query = "Select *from Compras where codigo_compra =" + codigo_compra ;
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());


            conect2.cerrar();
            return lastId;


        }


        public int buscarProducto()
        {

            conect2.abrir();


            string query = "Select * from Productos where codigo_producto =" +  codigo_producto ;
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());


            conect2.cerrar();
            return lastId;


        }




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