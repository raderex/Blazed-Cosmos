namespace BlazedCosmos.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // In real apps, use hashed passwords
    }
}