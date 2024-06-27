using Core.Entities;
using Core.Enums;
using System;

public static class PersonTestHelpers
{
    public static Person CreatePersonInstance(string firstName = "John", string lastName = "Doe", 
        DateTime dateOfBirth = default, Gender gender = Gender.Male, decimal height = 1.8m, 
        decimal weight = 75, string email = "john.doe@example.com", string phoneNumber = "(99)99999-9999", 
        decimal targetWeight = 70)
    {
        return new Person(firstName, lastName, dateOfBirth, gender, height, weight, email, phoneNumber, targetWeight);
    }
}
