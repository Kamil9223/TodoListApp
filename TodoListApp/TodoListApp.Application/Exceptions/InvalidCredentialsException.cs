using System;

namespace TodoListApp.Application.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        private const string displayMessage = "Invalid credentials";

        private string _logMessage;

        public InvalidCredentialsException() : base(displayMessage)
        { }

        public InvalidCredentialsException(string logMessage) : base(displayMessage)
        {
            _logMessage = logMessage;
        }

        public InvalidCredentialsException(string message, string logMessage) : base(message)
        {
            _logMessage = logMessage;
        }
    }
}
