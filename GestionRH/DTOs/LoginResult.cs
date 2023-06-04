using System.Text.Json.Serialization;

namespace GestionRH.DTOs
{
    public class LoginResult
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
