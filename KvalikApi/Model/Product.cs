using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Model
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime expirationDate { get; set; }    
        public string conditions { get; set; }  
        public int count { get; set; }  
        public bool active { get; set; }
    }
}
