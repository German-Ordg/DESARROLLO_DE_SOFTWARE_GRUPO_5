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
    class MetodoBuscarProveedor
    {
        ClsConexionBD conect = new ClsConexionBD();

        public void filtrar(DataGridView data, string buscarnombre)
        {


            try
            {
                conect.cerrar();
                conect.abrir();
                SqlCommand sql = new SqlCommand("BusquedaProveedor", conect.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.Add("@filtro", SqlDbType.VarChar, 200).Value = buscarnombre;

                sql.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(dt);
                data.DataSource = dt;
                conect.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error es: " + ex.ToString());
            }

        }
    }
}
