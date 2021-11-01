using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_proyecto.EmailServices
{
    class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail()
        {
            //Datos del Servidor de Correo Electronico
            ClsConexionBD conex = new ClsConexionBD();
            senderMail = conex.correo();
            password = conex.contra();
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
