using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_proyecto.Cashe
{
    //Declaracion de metodos Get y Set, para la pantalla de Usuarios.
    public static class UserCache
    {
        public static int IdUser { get; set; }
        public static string LoginName { get; set; }
        public static string Password { get; set; }
        public static string Position { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static int numero { get; set; }
        public static string estado { get; set; }

    }
}
