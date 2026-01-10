namespace _04_SMTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailService = new EmailService();
            //emailService.SendTextMessage();
            //emailService.SendMessage();
            //emailService.SendMessageByFileList();
            //emailService.SendHtmlMessage();
            emailService.SendMessageWithAttachment();
        }
    }
}
