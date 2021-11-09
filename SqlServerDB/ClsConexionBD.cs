using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using Pantallas_proyecto.Properties;
using System.Configuration;

namespace Pantallas_proyecto
{
    public class ClsConexionBD
    {
        //Clase de conexion a la base de datos sql
        public static string ObtenerString() {

            return Settings.Default.db_a75e9e_bderickmoncadaConnectionString;
        }

        SqlDataAdapter da;
        DataTable dt;
        public SqlConnection conexion = new SqlConnection(ObtenerString());
        public void abrir()
        {
            //Este codigo abre la conexion a la base de datos
            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("error al abrir BD ");
            }
        }
        public void cerrar()
        {
            //Este codigo es el cierre de conexion a la Base De Datos al sql 
            conexion.Close();
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ObtenerString());
        }
        public void CargaDeUsuarios(ComboBox cmb)
        {
            //Carga los datos del usuarios desde el sql
            try
            {
                SqlCommand comando = new SqlCommand("select nombre_usuario from Usuarios",conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cmb.Items.Add(registro["nombre_usuario"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos!" , "ERROR",
                                MessageBoxButtons.OK);
            }
        }
        public void CargaDeCategoria(ComboBox cmb)
        {
            //Carga de las categorias a la Base De Datos
            try
            {
                SqlCommand comando = new SqlCommand("select descripcion_categoria from Categoria_Producto", conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cmb.Items.Add(registro["descripcion_categoria"].ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos!", "ERROR",
                                MessageBoxButtons.OK);
            }
        }
        public void CargaDePuestos(ComboBox cmb)
        {
            //Carga de datos de puesto de traba
            try
            {
                SqlCommand comando = new SqlCommand("select descripcion_puesto from Empleados_Puestos", conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cmb.Items.Add(registro["descripcion_puesto"].ToString());
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos!", "ERROR",
                                MessageBoxButtons.OK);
            }
        }

        public void CargaDeNombreUsuarios(ComboBox cmb)
        {
            //Carga los datos del usuario al sql
            try
            {
                SqlCommand comando = new SqlCommand("select [nombre_empleado],[apellido_empleado] from [Empleados]", conexion);
                SqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    cmb.Items.Add(registro["nombre_empleado"].ToString()+" "+ registro["apellido_empleado"].ToString());
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos!", "ERROR",
                                MessageBoxButtons.OK);
            }
        }
        public string correo()
        {
            //Recuperar correo desde sql
            string cont = "g";
            conexion.Close();
            conexion.Open();
            SqlCommand comando = new SqlCommand("select correo from Administrativa", conexion);

            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                cont = registro["correo"].ToString();
            }
            conexion.Close();
            return cont;
        }
        public string contra()
        {
            //Recuperar contrasena del correo desde sql
            string cont = "g";
            conexion.Close();
            conexion.Open();
            SqlCommand comando = new SqlCommand("select contrasena from Administrativa", conexion);

            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                cont = registro["contrasena"].ToString();
            }
            conexion.Close();
            return cont;
        }

        public void CargarDatosUsuario(DataGridView dgv)
        {
            //Cara los datos de usuarios desde el sql
            try
            {
                da = new SqlDataAdapter("select * from VistaUsuarios", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)

            {
                MessageBox.Show(ToString());
                MessageBox.Show("Error al cargar base de datos!", "ERROR...!"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosEmpleados(DataGridView dgv)
        {
            //Carga los datos desde empleados desde el sql
            try
            {
                da = new SqlDataAdapter("Select * From vista_empleados", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosreporte1(DataGridView dgv)
        {
            //Carga de datos de reporte1 a la Base De Datos
            try
            {
                da = new SqlDataAdapter("Select * From View_compras", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos" ,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosreporte2(DataGridView dgv)
        {
            //Carga de datos de reporte2 a la Base De Datos
            try
            {
                da = new SqlDataAdapter("Select * From View_rotacion", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosreporte3(DataGridView dgv)
        {
            //Carga de datos de reporte3 a la Base De Datos
            try
            {
                da = new SqlDataAdapter("Select * From View_ventas", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosreporte5(DataGridView dgv)
        {
            //Carga de datos de reporte5 a la Base De Datos
            try
            {
                da = new SqlDataAdapter("Select * From VCategorias ", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosreporte4(DataGridView dgv)
        {
            //Carga de datos de reporte4 a la Base De Datos
            try
            {
                da = new SqlDataAdapter("Select * From VCategorias where cantidad_existente < 11", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarMetodosPago(DataGridView dgv)
        {
            //Carga de metodo de pagos a la Base De Datos
            try
            {
                da = new SqlDataAdapter("SELECT * FROM VistaMetodoPago", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarDatosProductos(DataGridView dgv)
        {
            //Carga de datos de productos a la Base de Datos
            try
            {
                da = new SqlDataAdapter("Select * From VistaProductos", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargarProveedores(DataGridView dgv)
        {
            //Carga de datos de proveedores a la Base de Datos
            try
            {
                da = new SqlDataAdapter("SELECT * FROM VistaProveedores", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void cargarBitacora(DataGridView dgv)
        {
            //Carga de datos de bitacora a la Base de Datos
            try
            {
                da = new SqlDataAdapter("SELECT * FROM vista_Bitacora", conexion);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden cargar los datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
