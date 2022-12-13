using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class DBException : Exception
    {
        public DBException(string message) : base(message) { }
        public DBException() { }

    }
}
