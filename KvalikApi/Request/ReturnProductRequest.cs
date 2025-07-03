using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class ReturnProductRequest
    {
        public int productId { get; set; }  
        public string returnType { get; set; }
        public string reason { get; set; }  
        public DateTime date { get; set; }  
    }
} 