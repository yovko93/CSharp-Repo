﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        private const string GENDER = "Male";

        public Tomcat(string name, int age)
            : base(name, age, GENDER)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
