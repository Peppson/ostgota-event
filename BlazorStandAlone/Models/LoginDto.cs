using System.Text.Json.Serialization;

namespace BlazorStandAlone.Models
{
    public class LoginDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public UserRole Role { get; set; }
    }
}
