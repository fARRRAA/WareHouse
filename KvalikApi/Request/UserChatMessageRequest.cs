using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class UserChatMessageRequest
    {
        public int chatId { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
        public DateTime sent_at { get; set; }
        public string photoUrl { get; set; }
    }
} 