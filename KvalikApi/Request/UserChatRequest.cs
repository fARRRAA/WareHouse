using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class UserChatRequest
    {
        public int firstUserId { get; set; }
        public int secondUserId { get; set; }
        public DateTime created_at { get; set; }
    }
} 