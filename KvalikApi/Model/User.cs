using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvalikApi.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string login { get; set; }

        public string password { get; set; }
        [ForeignKey(nameof(role))]
        public int roleId { get; set; }
        public Role role { get; set; }
    }
    public class Role
    {
        [Key]   
        public int id { get; set; }
        public string name { get; set; }    
    }

}
