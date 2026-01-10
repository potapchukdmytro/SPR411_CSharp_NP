using System.Net;
using System.Net.Mail;

namespace _04_SMTP
{
    public class EmailService
    {
        private readonly string host;
        private readonly int port;
        private readonly string email;
        private readonly string password;
        private readonly SmtpClient smtpClient;

        public EmailService()
        {
            password = "";
            email = "";
            host = "smtp.gmail.com";
            port = 587;

            smtpClient = new SmtpClient(host, port);
            smtpClient.Credentials = new NetworkCredential(email, password);
            smtpClient.EnableSsl = true;
        }

        public void SendTextMessage()
        {
            smtpClient.Send(email, "", "Тест smtp", "Привіт це перще повідомлення відправлене мовою C#");
        }

        public void SendMessage()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(email); // Від кого
            message.To.Add(""); // Кому
            message.To.Add(""); // Кому
            message.Subject = "Тест smtp"; // Тема
            message.Body = "Привіт, лист було відправлено із використанням класу MailMessage"; // Тіло листа

            smtpClient.Send(message);
        }

        public void SendMessageByFileList()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(email); // Від кого

            var emails = File.ReadAllLines(@"C:\itstep\3 семестр\SP411\NP\04_SMTP\04_SMTP\emails.txt");
            foreach (var item in emails)
            {
                message.To.Add(item);
            }

            message.Subject = "Тест smtp"; // Тема
            message.Body = "Привіт, лист було відправлено із використанням класу MailMessage"; // Тіло листа

            smtpClient.Send(message);
        }

        public void SendHtmlMessage()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(email); // Від кого

            string to = "";
            message.To.Add(to);

            string html = File.ReadAllText(@"C:\itstep\3 семестр\SP411\NP\04_SMTP\04_SMTP\templates\mailMessage.html");
            html = html.Replace("$UserEmail", to);

            message.Subject = "Тест smtp html"; // Тема
            message.Body = html; // Тіло листа

            message.IsBodyHtml = true;

            smtpClient.Send(message);
        }

        public void SendMessage(string[] to, string subject, string body, bool isHtml = false)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(email); // Від кого
            foreach (var item in to)
            {
                message.To.Add(item);
            }
            message.Subject = subject; // Тема
            message.Body = body; // Тіло листа
            message.IsBodyHtml = isHtml;
            smtpClient.Send(message);
        }

        public void SendMessageWithAttachment()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(email); // Від кого

            string to = "";
            message.To.Add(to);

            string html = File.ReadAllText(@"C:\itstep\3 семестр\SP411\NP\04_SMTP\04_SMTP\templates\mailMessage.html");
            html = html.Replace("$UserEmail", to);

            message.Subject = "Тест smtp html"; // Тема
            message.Body = html; // Тіло листа

            message.IsBodyHtml = true;

            // Додаємо вкладення
            Attachment attachment = new Attachment(@"C:\itstep\3 семестр\c# homes\04_home.txt");
            message.Attachments.Add(attachment);
            var stream = new FileStream(@"C:\Users\traig\Downloads\code.bat", FileMode.Open, FileAccess.Read);
            attachment = new Attachment(stream, "image.pdf");
            message.Attachments.Add(attachment);

            smtpClient.Send(message);

            stream.Dispose();
        }
    }
}
