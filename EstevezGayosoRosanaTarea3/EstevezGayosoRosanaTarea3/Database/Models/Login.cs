using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EstevezGayosoRosanaTarea3.Database.Models

{
    public class Login
    {
        [Key]
        [Column("Id")]
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
