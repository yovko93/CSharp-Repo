using System.Linq;

using _2._03.Telephony.Contracts;
using _2._03.Telephony.Exceptions;

namespace _2._03.Telephony.Models
{
    public class Smartphone : Phone, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }
            return $"Browsing: {url}!";
        }

        public sealed override string Call(string phoneNumber)
        {
           
            return $"Calling... {base.Call(phoneNumber)}";
        }


    }
}
