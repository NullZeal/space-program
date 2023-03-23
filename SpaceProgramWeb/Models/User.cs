using System.ComponentModel.DataAnnotations;

namespace SpaceProgramWeb.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public User()
        {
        }
    }
}
