namespace App.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
