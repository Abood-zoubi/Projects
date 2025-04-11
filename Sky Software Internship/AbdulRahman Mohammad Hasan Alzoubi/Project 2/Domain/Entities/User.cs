using System.ComponentModel.DataAnnotations;

namespace Biding_management_System.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = "Bidder";


        public User() { }

        public User(string username, string email, string password, string role)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
