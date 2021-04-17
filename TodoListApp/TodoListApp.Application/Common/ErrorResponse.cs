using System;
using System.Collections.Generic;

namespace TodoListApp.Application.Common
{
    public class ErrorResponse
    {
        public Dictionary<string, string> Errors { get; }

        public ErrorResponse()
        {
            Errors = new Dictionary<string, string>();
        }

        public bool TryGetValue(string key, out string value)
        {
            return Errors.TryGetValue(key, out value);
        }

        public void AddModelError(string key, string errorMessage)
        {
            Errors.Add(key, errorMessage);
        }

        public string this[string key]
        {
            get
            {
                string value;
                Errors.TryGetValue(key, out value);
                return value;
            }
            set { Errors[key] = value; }
        }

        private string GetModelStateForKey(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            string modelState;
            if (!TryGetValue(key, out modelState))
            {
                this[key] = modelState;
            }

            return modelState;
        }
    }
}
