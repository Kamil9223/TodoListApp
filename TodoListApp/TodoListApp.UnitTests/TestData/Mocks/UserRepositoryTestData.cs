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

        public static User CreateUserWithBoardsAndTasks()
        {
            var user = new User(UserEmail, "");

            var firstBoard = new TasksBoard(1, "ogólne");
            var secondBoard = new TasksBoard(2, "programowanie");

            firstBoard.Tasks = new List<SingleTask>()
            {
                new SingleTask(1, "sprzątanie pokoju", DateTime.Now, DateTime.Now.AddDays(1), PriorityLevel.Medium),
                new SingleTask(2, "przeczytanie książki", DateTime.Now, DateTime.Now.AddDays(7), PriorityLevel.Low),
                new SingleTask(3, "kupno zapałek", DateTime.Now, DateTime.Now.AddDays(1), PriorityLevel.High)
            };

            secondBoard.Tasks = new List<SingleTask>()
            {
                new SingleTask(4, "kurs ASP.NET Core", DateTime.Now, DateTime.Now.AddDays(9), PriorityLevel.Medium),
                new SingleTask(5, "artykuł o dockerze", DateTime.Now, DateTime.Now.AddDays(2), PriorityLevel.High)
            };

            user.Boards = new List<TasksBoard> { firstBoard, secondBoard };

            return user;
        }
    }
}
