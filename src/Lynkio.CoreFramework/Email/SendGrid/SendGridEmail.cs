using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace Lynkio.CoreFramework.Email.SendGrid
{
    public static class Email
    {
        public static async Task SendPlainText(string toEmail, string toName,string message)
        {
            var key = Config.Email.SendGrid.ApiKey;
            var subject = Config.Email.SendGrid.Subject;
            var fromEmail = Config.Email.SendGrid.From;
            var fromName = Config.Email.SendGrid.FromName;
            var sg = new SendGridClient(key);
            var from = new EmailAddress(fromEmail,fromName);
            var to = new EmailAddress(toEmail,toName);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await sg.SendEmailAsync(msg);           
            //var response = await sg.SendEmailAsync(msg);
        }
    }
}
