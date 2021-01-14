using System;

namespace TodoListApp.Application.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        private const string displayMessage = "Already exists";

        private string _logMessage;

        public AlreadyExistsException() : base(displayMessage)
        { }

        public AlreadyExistsException(string logMessage) : base(displayMessage)
        {
            _logMessage = logMessage;
        }

        public AlreadyExistsException(string message, string logMessage) : base(message)
        {
            _logMessage = logMessage;
        }
    }
}
