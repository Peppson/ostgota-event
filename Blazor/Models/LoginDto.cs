namespace BlazorStandAlone.Models
{
    public class LoginDto
    {
        public required string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
