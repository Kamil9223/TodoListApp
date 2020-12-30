using System;
using System.Security.Cryptography;
using System.Text;
using TodoListApp.Application.Users.Services.Abstractions;

namespace TodoListApp.Application.Users.Services.Implementations
{
    public class Encrypter : IEncrypter
    {
        public string Encrypt(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text)); 
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
