using System.ComponentModel.DataAnnotations;

namespace EstevezGayosoRosanaTarea3.Models
{
    
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        
        public string Password { get; set; }
    }
}
