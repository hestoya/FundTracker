using System.ComponentModel.DataAnnotations;

namespace FundTracker.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
