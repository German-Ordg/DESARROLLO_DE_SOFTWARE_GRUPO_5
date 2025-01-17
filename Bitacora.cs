﻿using System;
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
                "WHERE[dbo].[Usuarios].[codigo_estado] = '1'";

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

            conect2.abrir();
            int actividad = 1;
            SqlCommand cmd = new SqlCommand("bitacora_PA", conect2.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoUsuario", buscarCodigoEmpleado(Cashe.UserCache.LoginName));
            cmd.Parameters.AddWithValue("@CodigoActividad", actividad);
            cmd.ExecuteNonQuery();
            conect2.cerrar();


        }

        public void ventaRealizada()
        {


            conect2.abrir();
            int actividad = 2;
            SqlCommand cmd = new SqlCommand("bitacora_PA", conect2.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoUsuario", buscarCodigoEmpleado(Cashe.UserCache.LoginName));
            cmd.Parameters.AddWithValue("@CodigoActividad", actividad);
            cmd.ExecuteNonQuery();
            conect2.cerrar();


        }

        public void compraRealizada()
        {


            conect2.abrir();
            int actividad = 3;
            SqlCommand cmd = new SqlCommand("bitacora_PA", conect2.conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoUsuario", buscarCodigoEmpleado(Cashe.UserCache.LoginName));
            cmd.Parameters.AddWithValue("@CodigoActividad", actividad);
            cmd.ExecuteNonQuery();
            conect2.cerrar();


        }



    }
}