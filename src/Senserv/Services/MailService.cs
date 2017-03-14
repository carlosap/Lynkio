using Senserv.Events;
using System;
using System.Threading.Tasks;
namespace Senserv.Services
{
    public class MailService
    {
        public async void OnProductLoggedEvent(object source, ProductEventArgs e)
        {
            //Email.SendPlainText()
            await Task.Run(() =>
            {
                Console.WriteLine($"Sending Mail..{e.Product.SerialNumber}");
            });
        }
    }
}
