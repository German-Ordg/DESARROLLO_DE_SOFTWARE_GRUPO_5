using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;


namespace Pantallas_proyecto.SqlServerDB
{
    public class UserDao : ClsConexionBD
    {
        public string recoverPassword(string userRequesting)
        {
            using (var connection = GetSqlConnection())
            {
                //Este codigo es la parte de recuperacion de conraseña del usuarios 
                // A traves del correo electronico se le manda un codigo de verificacion
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Usuarios where nombre_usuario=@user or correo_electronico=@mail";
                    command.Parameters.AddWithValue("@user", userRequesting);
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        Random random = new Random();
                        Cashe.UserCache.numero = random.Next(1000, 9999);

                        string userName = reader.GetString(1);
                        string userMail = reader.GetString(3);
                        string accountPassword = reader.GetString(2);
                        var mailService = new EmailServices.SystemSupportMail();
                        mailService.sendMail(
                          subject: "SISTEMA: Peticion de recuperacion de contraseña",
                          body: "Hola, " + userName + "\nSolicitaste recuperar tu contraseña.\n" +
                          "Tu codigo es: " + Cashe.UserCache.numero +
                          "\n Introduce este codigo en el programa para cambiar de contraseña",
                          recipientMail: new List<string> { userMail }
                          );
                        //Mensaje que le mostrara una vez que le envie un mensaje a su correo personal
                        return "Hola, " + userName + "\n Solicitaste recuperar tu contraseña.\n" +
                          "Porfavor Revisa tu Correo: " + userMail +
                          "\n Ingresa el codigo que aparece en la parte de abajo";
                    }
                    else
                        return "Lo sentimos, tu no tienes una cuenta con ese correo o usuario";
                }
            }
        }

        public bool existsUser(int id, string loginName, string pass)
        {
            //Codigo para verificar si el usuario existe sus datos en sql
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from [dbo].[UsuarioNombre] where codigo_empelado=@id and nombre_usuario=@loginName and contrasena=@pass";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@loginName", loginName);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool Login(string user, string pass)
        {
            //Codigo que permite que uno puede ingresar con su nombre de usuario y su contraña
            //Solo La Gerente y usuarios tienen acceso en esta pantalla
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select* from[dbo].[UsuarioNombre] where  nombre_usuario = @user and contrasena = @pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Cashe.UserCache.IdUser = reader.GetInt32(0);
                            Cashe.UserCache.LoginName = reader.GetString(1);
                            Cashe.UserCache.Password = reader.GetString(2);
                            Cashe.UserCache.Position = reader.GetString(3);
                            Cashe.UserCache.FirstName = reader.GetString(4);
                            Cashe.UserCache.LastName = reader.GetString(5);
                            Cashe.UserCache.estado = reader.GetString(6);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

    }
}
