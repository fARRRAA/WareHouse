using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Model
{
    public class UserChatMessage
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(chat))]
        public int chatId { get; set; }
        public UserChat chat { get; set; }
        [ForeignKey(nameof(user))]
        public int userId { get; set; }
        public User user { get; set; }
        public string message { get; set; }
        public DateTime sent_at { get; set; }
        public string photoUrl { get; set; }
    }
}
