using System;
using System.Collections.Generic;
namespace Senserv.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string ProductNumber { get; set; }
        public string AssemblyNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public string Value { get; set; }
        public string Author { get; set; }
        public string Lic { get; set; }
        public List<Sensor> Sensors { get; set; } = new List<Sensor>();
        public IList<Product> ChildProducts { get; set; } = new List<Product>();
        public DateTime LastModified { get; set; } = DateTime.Now;
    }

}
