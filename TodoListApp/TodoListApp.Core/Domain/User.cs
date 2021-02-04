using System.Collections.Generic;

namespace TodoListApp.Core.Domain
{
    public class User : IEntity
    {
        public int UserId { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public int Points { get; private set; }
        public ICollection<TasksBoard> Boards { get; set; }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
            Boards = new HashSet<TasksBoard>();
        }

        public User(int userId, string email, string passwordHash, int points = default)
        {
            UserId = userId;
            Email = email;
            PasswordHash = passwordHash;
            Points = points;
            Boards = new HashSet<TasksBoard>();
        }
    }
}
