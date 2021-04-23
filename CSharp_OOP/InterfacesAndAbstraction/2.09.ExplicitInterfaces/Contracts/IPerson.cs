using System;
using System.Collections.Generic;
using System.Text;

namespace _2._09.ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string GetName();

    }
}
