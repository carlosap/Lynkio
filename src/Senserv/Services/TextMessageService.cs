using System;
using System.Threading.Tasks;
using Senserv.Events;
namespace Senserv.Services
{
    public class TextMessageService
    {
        public async void OnProductLoggedEvent(object source, ProductEventArgs e)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Sending Msg..{e.Product.SerialNumber}");
            });          
        }
    }
}
