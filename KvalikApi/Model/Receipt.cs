using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvalikApi.Model
{
    public class Receipt
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(product))]
        public int productId { get; set; }
        public Product product { get; set; }
        public int count { get; set; }
        public DateTime date { get; set; }
        public int batchNumber { get; set; }
        public string conditions { get; set; }
    }
}
