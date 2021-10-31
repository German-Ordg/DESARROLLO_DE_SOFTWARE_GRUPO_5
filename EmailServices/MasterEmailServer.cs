using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Pantallas_proyecto.EmailServices
{
    public abstract class MasterMailServer
    {
        //Se declaran los atributos respectivos de las variables
        
        private SmtpClient smtpClient;
        protected string senderMail { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        //inicializar propiedades del cliente SMTP
        protected void initializeSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public void sendMail(string subject, string body, List<string> recipientMail)
        {
            //Se declara una variable de tipo var para que contenga la nueva instancia
            var mailMessage = new MailMessage();
            //Abrimos un try catch and finally para iniciar el proceso
            try
            {
                mailMessage.From = new MailAddress(senderMail);
                foreach (string mail in recipientMail)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);//Enviar mensaje
            }
            catch (Exception) { }
            finally
            {
                //Terminamos el proceso
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

    }
}
