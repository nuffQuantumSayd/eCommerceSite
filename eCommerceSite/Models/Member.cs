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

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Email")]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
