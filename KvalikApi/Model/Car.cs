using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KvalikApi.Model
{
    public class Car
    {
        [Key]
        public int id { get; set; }
        public string model { get; set; }
        public string plate { get; set; }
        public DateTime lastTO { get; set; }
        public DateTime nextTO { get; set; }
        [ForeignKey(nameof(user))]
        public int driverId { get; set; }
        public User user { get; set; }
    }
    public class CarService
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(car))]
        public int carId { get; set; }
        public Car car { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }

    }
}