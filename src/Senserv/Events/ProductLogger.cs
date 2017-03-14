using System;
using Senserv.Model;
using System.Threading.Tasks;
namespace Senserv.Events
{
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; set; }
    }
    public class ProductLogger
    { 
        public event EventHandler<ProductEventArgs> ProductLoggedEvent;
        public async void Log(Product product)
        {
            await Task.Run(() =>
            {
                //Value
                OnProductLoggedEvent(product); //(c) Raise the Event
            });
        }
        protected virtual void OnProductLoggedEvent(Product product)
        {
            ProductLoggedEvent?.Invoke(this, new ProductEventArgs { Product = product });
        }
    }
}
