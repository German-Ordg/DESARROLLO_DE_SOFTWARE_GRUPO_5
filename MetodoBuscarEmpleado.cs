using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    class MetodoBuscarEmpleado
    {
        //Se instancia la clase de conexión
        ClsConexionBD conect = new ClsConexionBD();

        public void filtrar(DataGridView data, string buscarnombre)
        {
            try
            {
                /*Se cierra y se abre la base de datos para posteriormente Ejecutar
                 un procedimiento almacenado que se encuentra principalmente dentro de 
                la tabla de empleados para poder realizar una comparación en tiempo real*/
                conect.cerrar();
                conect.abrir();
                SqlCommand sql = new SqlCommand("busqueda_empleado", conect.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.Add("@filtro", SqlDbType.VarChar, 200).Value = buscarnombre;
                /*Se ejecuta el Query y se devuelven los datos deseados desde la base*/
                sql.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(dt);
                data.DataSource = dt;
                /*Se cierra la conexión a la base de datos*/
                conect.cerrar();
            }
            catch (Exception)
            {
                /*En caso de que no pudiesen cargarse bien los datos a causa de algún mal
                 funcionamiento tanto de la base de datos o del sistema en general, se 
                liberará una ventana de error.*/
                MessageBox.Show("Error al cargar desde la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
