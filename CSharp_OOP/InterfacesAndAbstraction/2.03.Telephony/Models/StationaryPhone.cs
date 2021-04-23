using System.Linq;

using _2._03.Telephony.Contracts;
using _2._03.Telephony.Exceptions;

namespace _2._03.Telephony.Models
{
    public class StationaryPhone : Phone
    {
        public sealed override string Call(string phoneNumber)
        {
           
            return $"Dialing... {base.Call(phoneNumber)}";
        }

    }
}
