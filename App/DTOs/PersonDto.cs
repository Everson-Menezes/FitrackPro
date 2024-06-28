using Core.Enums;

namespace App.DTOs
{
    public class PersonDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public decimal TargetWeight { get; set; }
    }
}
