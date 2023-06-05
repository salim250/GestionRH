using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace GestionRH.Model
{
    public class User
    {
        public int Id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public Role role { get; set; }
        public String Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
