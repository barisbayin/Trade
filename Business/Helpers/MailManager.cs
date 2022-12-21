using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Business.Helpers
{

    public class MailManager
    {
        public string MailFrom { get; set; }
        public string MailFromPassword { get; set; }
        public string MailTo { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }

        public MailManager()
        {
            // Varsayılan değerler
            SmtpServer = "smtp.office365.com";
            SmtpPort = 587;
            EnableSsl = true;
        }

        public void SendMail()
        {
            // SMTP istemcisi oluşturma
            SmtpClient smtpClient = new SmtpClient(SmtpServer, SmtpPort);
            smtpClient.Credentials = new NetworkCredential(MailFrom, MailFromPassword);
            smtpClient.EnableSsl = EnableSsl;

            // Mail oluşturma
            MailMessage mailMessage = new MailMessage(MailFrom, MailTo, MailSubject, MailBody);

            // Mail gönderme
            smtpClient.Send(mailMessage);
        }
    }
}



