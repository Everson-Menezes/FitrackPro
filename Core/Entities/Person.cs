using Core.Enums;

namespace Core.Entities
{
    public class Person
    {
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public DateTime DateOfBirth { get; private set; } = default!;
        public Gender Gender { get; private set; }
        public decimal Height { get; private set; } // in meters
        public decimal Weight { get; private set; } // in kilograms
        public decimal TargetWeight { get; private set; } // in kilograms
        public string Email { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;

        public Person() { }

        public Person(string firstName, string lastName, DateTime dateOfBirth, Gender gender, decimal height, decimal weight, string email, string phoneNumber, decimal targetWeight = 0)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetDateOfBirth(dateOfBirth);
            SetGender(gender);
            SetHeight(height);
            SetWeight(weight);
            SetTargetWeight(targetWeight);
            SetEmail(email);
            SetPhoneNumber(phoneNumber);
        }

        // Methods to update properties with validation
        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be empty", nameof(firstName));
            }
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be empty", nameof(lastName));
            }
            LastName = lastName;
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth must be in the past", nameof(dateOfBirth));
            }
            DateOfBirth = dateOfBirth;
        }

        public void SetGender(Gender gender)
        {
            if (!Enum.IsDefined(typeof(Gender), gender))
            {
                throw new ArgumentException("Invalid gender value", nameof(gender));
            }
            Gender = gender;
        }

        public void SetHeight(decimal height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Height must be greater than zero", nameof(height));
            }
            Height = height;
        }

        public void SetWeight(decimal weight)
        {
            if (weight <= 0)
            {
                throw new ArgumentException("Weight must be greater than zero", nameof(weight));
            }
            Weight = weight;
        }

        public void SetTargetWeight(decimal targetWeight)
        {
            if (targetWeight <= 0)
            {
                throw new ArgumentException("Target weight must be greater than zero", nameof(targetWeight));
            }
            TargetWeight = targetWeight;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email address", nameof(email));
            }
            Email = email;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || !IsValidBrazilPhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid phone number", nameof(phoneNumber));
            }
            PhoneNumber = phoneNumber;
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }

        private bool IsValidBrazilPhoneNumber(string phoneNumber)
        {
            var regex = @"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, regex);
        }
    }
}
