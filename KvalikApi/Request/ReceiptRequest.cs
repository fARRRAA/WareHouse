using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class ReceiptRequest
    {
        public int productId { get; set; }
        public int count { get; set; }
        public DateTime date { get; set; }
        public int batchNumber { get; set; }
        public string conditions { get; set; }
    }
} 