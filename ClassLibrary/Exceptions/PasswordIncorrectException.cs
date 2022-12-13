using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class PasswordIncorrectException : Exception
    {
        public PasswordIncorrectException(string message, Exception es) : base(message) { }
        public PasswordIncorrectException() { }


    }
}
