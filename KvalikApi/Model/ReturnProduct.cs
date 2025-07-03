using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvalikApi.Model
{
    public class ReturnProduct
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(product))]
        public int productId { get; set; }  
        public Product product { get; set; }
        public string returnType { get; set; }
        public string reason { get; set; }  
        public DateTime date { get; set; }  
    }
}
