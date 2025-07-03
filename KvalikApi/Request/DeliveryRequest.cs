using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class DeliveryRequest
    {
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public string prioritet { get; set; }
    }
} 