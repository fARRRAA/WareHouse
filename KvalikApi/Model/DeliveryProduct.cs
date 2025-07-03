using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KvalikApi.Model
{
    public class DeliveryProduct
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(product))]
        public int productId { get; set; }  
        public Product product { get; set; }
        [ForeignKey(nameof(delivery))]
        public int deliveryId { get; set; }
        public Delivery delivery { get; set; }
        public int count { get; set; }  
    }
}
