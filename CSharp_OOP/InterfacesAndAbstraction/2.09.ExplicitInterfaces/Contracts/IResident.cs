﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2._09.ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
