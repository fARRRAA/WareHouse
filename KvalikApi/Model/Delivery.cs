using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Model
{
    public class Delivery
    {
        [Key]
        public int id { get; set; }
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public string prioritet { get; set; }

    }
}
