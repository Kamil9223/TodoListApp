using System;
using System.Collections.Generic;
using TodoListApp.Core.Domain;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public class UserRepositoryTestData
    {
        public const string UserEmail = "test@email.com";

        public static User CreateUser()
        {
            return new User(1, UserEmail, "", 11);
        }
    }
}
