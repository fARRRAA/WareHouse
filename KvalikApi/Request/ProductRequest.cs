using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class ProductRequest
    {
        public string name { get; set; }
        public DateTime expirationDate { get; set; }    
        public string conditions { get; set; }  
        public int count { get; set; }  
        public bool active { get; set; }
    }
} 