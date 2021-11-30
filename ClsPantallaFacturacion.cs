using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    class ClsPantallaFacturacion
    {
        //instancias a la clase de la conexión
        ClsConexionBD con = new ClsConexionBD();

        SqlCommand cmd;
        SqlDataReader dr;


        //declaración de variables
        private static String   descripcionProducto;
        private static int      codigoProducto;
        private static int      cantidadProducto;
        private static int      cantidadInventario;
        private static double   precioProducto;
        private static double   descuentoProducto;
        private static double   totalProducto;

        
        //función para cargar el combobox de los tipos de pago
        public void cargarComboboxPago(ComboBox cmb)
        {

            String ComboboxPago = "SELECT descripcion_pago FROM [dbo].[Metodo_Pago]";
            con.abrir();
            try
            {

                cmd = new SqlCommand(ComboboxPago, con.conexion);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmb.Items.Add(dr["descripcion_pago"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el combobox " + ex.ToString());
            }
            con.cerrar();
        }

        //función para validar para la validación de sólo números
        public static void validarSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Sólo se admiten números");
            }
        }

        //función para validar sólo letras
        public static void validarSoloLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Sólo se admiten letras");
            }

        }



        public string DescripcionProducto { get => descripcionProducto; set => descripcionProducto = value; }
        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public int CantidadProducto { get => cantidadProducto; set => cantidadProducto = value; }
        public double PrecioProducto { get => precioProducto; set => precioProducto = value; }
        public double DescuentoProducto { get => descuentoProducto; set => descuentoProducto = value; }
        public int CantidadInventario { get => cantidadInventario; set => cantidadInventario = value; }
        public double TotalProducto { get => totalProducto; set => totalProducto = value; }
    }
}
