using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pantallas_proyecto.SqlServerDB;

namespace Pantallas_proyecto.Dominio
{
    //Funcion de seguridad de la aplicación, valida que el usuario exista en la base de datos.
    public class UserModel 
    {
        UserDao userDao = new UserDao();
        

        public string recoverPassword(string userRequesting)
        {
            return userDao.recoverPassword(userRequesting);
        }
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }
        public bool securityLogin()
        {
            if (Cashe.UserCache.IdUser >= 1)
            {
                if (userDao.existsUser(Cashe.UserCache.IdUser, Cashe.UserCache.LoginName, Cashe.UserCache.Password) == true)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        
    }
}
