using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public int Email { get; set; }

        public int Password { get; set; }

        public int Phone { get; set; }

        public int Username { get; set; }
    }
}
