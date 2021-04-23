using System.Linq;

using _2._03.Telephony.Contracts;
using _2._03.Telephony.Exceptions;

namespace _2._03.Telephony.Models
{
    public abstract class Phone : ICallable
    {
        public virtual string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }

            return phoneNumber;
        }
    }
}
