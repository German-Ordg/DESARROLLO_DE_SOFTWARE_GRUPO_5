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

    class Bitacora
    {
        ClsConexionBD conect2 = new ClsConexionBD(); //Conexion con la base de datos
        SqlCommand cmd; // comandos de sql
         SqlDataReader dr;

        public void cargarComboboxVendedor2(ComboBox cmb)
        {
            String comboboxVendedor = "SELECT [dbo].[Empleados].nombre_empleado+' '+[dbo].[Empleados].apellido_empleado nombre " +
                "FROM[dbo].[Empleados] JOIN[dbo].[Usuarios] ON [dbo].[Empleados].codigo_empelado =[dbo].[Usuarios].codigo_empleado " +
                "WHERE[dbo].[Usuarios].[Estado] = 'ACTIVO'";

            conect2.abrir();
            try
            {

                cmd = new SqlCommand(comboboxVendedor, conect2.conexion);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmb.Items.Add(dr["nombre"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el combobox " + ex.ToString());
            }
            conect2.cerrar();
        }
        public int buscarCodigoEmpleado(string usuario)
        {

            string query = "SELECT dbo.Empleados.codigo_empelado FROM dbo.Empleados " +
                "INNER JOIN dbo.Usuarios ON dbo.Empleados.codigo_empelado = dbo.Usuarios.codigo_empleado where dbo.Usuarios.nombre_usuario = '" + usuario + "'";
            SqlCommand command = new SqlCommand(query, conect2.conexion);

            int lastId = Convert.ToInt32(command.ExecuteScalar());

            return lastId;


        }
        public void inicioSecion()
        {


            DateTime hoy = DateTime.Now;
            string fecha = hoy.ToShortDateString() + " " + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second;

            conect2.abrir();
            cmd = new SqlCommand("insert into Bitacora values ('" + fecha + "'," + buscarCodigoEmpleado(Cashe.UserCache.LoginName) + ",1 )", conect2.conexion);
            cmd.ExecuteNonQuery();
            conect2.cerrar();


        }

        public void ventaRealizada()
        {


            DateTime hoy = DateTime.Now;
            string fecha = hoy.ToShortDateString() + " " + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second;

            conect2.abrir();
            cmd = new SqlCommand("insert into Bitacora values ('" + fecha + "'," + buscarCodigoEmpleado(Cashe.UserCache.LoginName) + ",2 )", conect2.conexion);
            cmd.ExecuteNonQuery();
            conect2.cerrar();


        }

        public void compraRealizada()
        {


            DateTime hoy = DateTime.Now;
            string fecha = hoy.ToShortDateString() + " " + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second;

            conect2.abrir();
            cmd = new SqlCommand("insert into Bitacora values ('" + fecha + "'," + buscarCodigoEmpleado(Cashe.UserCache.LoginName) + ",3 )", conect2.conexion);
            cmd.ExecuteNonQuery();
            conect2.cerrar();


        }



    }
}