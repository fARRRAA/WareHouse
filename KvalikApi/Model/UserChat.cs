using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Model
{
    public class UserChat
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(firstUser))]
        public int firstUserId { get; set; }
        public User firstUser { get; set; }
        [ForeignKey(nameof(secondUser))]
        public int secondUserId { get; set; }
        public User secondUser { get; set; }
        public DateTime created_at { get; set; }
    }
}
