using Core.Entities;
using Core.Enums;

public static class UserTestHelper
{
    public static User CreateUserInstance(string username = "JohnUser", string passwordHash = "passwordHash")
    {
        return new User(username, passwordHash, PersonTestHelper.CreatePersonInstance());
    }
}