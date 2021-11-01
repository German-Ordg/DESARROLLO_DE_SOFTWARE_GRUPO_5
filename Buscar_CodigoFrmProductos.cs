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
    class Buscar_CodigoFrmProductos
    {
        ClsConexionBD conect = new ClsConexionBD();

        public void filtrar1(DataGridView data, string buscarcodigo1)
        {
            /*Este codigo permite buscar en la clase buscar codigo, el codigo de producto en el datagridview el frmProductos
            a traves de la clase conexion de la base de datos*/
            try
            {
                conect.cerrar();
                conect.abrir();
                SqlCommand sql = new SqlCommand("Buscar_codigo1", conect.conexion);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.Add("@Buscar", SqlDbType.VarChar, 200).Value = buscarcodigo1;

                sql.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql);
                da.Fill(dt);
                data.DataSource = dt;
                conect.cerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("error es: " + ToString());
            }
        }
    }
}
