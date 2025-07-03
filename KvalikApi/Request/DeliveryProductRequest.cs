using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class DeliveryProductRequest
    {
        public int productId { get; set; }  
        public int deliveryId { get; set; }
        public int count { get; set; }  
    }
} 