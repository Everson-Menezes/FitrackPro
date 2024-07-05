namespace App.DTOs
{
    public class CreateUserDto
    {
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public PersonDto Person { get; set; } = default!;
    }
}
