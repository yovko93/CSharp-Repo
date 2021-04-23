using System;
using System.Collections.Generic;
using System.Text;

namespace _2._03.Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string INVALID_URL_EXC_MSG = "Invalid URL!";

        public InvalidURLException()
            : base(INVALID_URL_EXC_MSG)
        {

        }
    }
}
