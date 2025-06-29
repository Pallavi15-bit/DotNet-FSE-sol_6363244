using System.Net;
using System.Net.Mail;

namespace MailServiceLib
{
    public interface IEmailSender
    {
        bool SendEmail(string toAddress, string message);
    }

    public class EmailSender : IEmailSender
    {
        public bool SendEmail(string toAddress, string message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("your_email_address@gmail.com");
            mail.To.Add(toAddress);
            mail.Subject = "Test Mail";
            mail.Body = message;

            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("username", "password");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);

            return true;
        }
    }
}
