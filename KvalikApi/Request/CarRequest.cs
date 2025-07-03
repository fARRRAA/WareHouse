using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class CarRequest
    {
        public string model { get; set; }
        public string plate { get; set; }
        public DateTime lastTO { get; set; }
        public DateTime nextTO { get; set; }
        public int driverId { get; set; }
    }

    public class CarServiceRequest
    {
        public int carId { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
    }
} 