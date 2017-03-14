using Senserv.Events;
using Senserv.Services;
namespace Senserv
{
    public class Publishers
    {
        public static ProductLogger ProductLogger { get; set; }
        private static MailService EmailService { get; set; }
        private static TextMessageService TextMessageService { get; set; }
        public Publishers()
        {
            ProductLogger = new ProductLogger();
            EmailService = new MailService();
            TextMessageService = new TextMessageService();
            //Register Subscribers
            ProductLogger.ProductLoggedEvent += EmailService.OnProductLoggedEvent;
            ProductLogger.ProductLoggedEvent += TextMessageService.OnProductLoggedEvent;
        }
    }
}
