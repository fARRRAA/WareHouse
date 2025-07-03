using System.ComponentModel.DataAnnotations;

namespace KvalikApi.Request
{
    public class UserRequest
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
    }

    public class RoleRequest
    {
        public string name { get; set; }
    }
} 