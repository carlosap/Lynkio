using Lynkio.CoreFramework.Queue;
namespace Senserv.Model
{
    public class Sensor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string CRD { get; set; }
        public string Unit { get; set; }
        public string Symbol { get; set; }
        public string PartNumber { get; set; }       
        public decimal Nominal { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public string OutOfLimitMsg { get; set; }
        public string Lot { get; set; }
        public string Revision { get; set; }
        public string DateCode { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public FixedQueue<decimal> Histogram { get; set; } = new FixedQueue<decimal>();
    }
}


