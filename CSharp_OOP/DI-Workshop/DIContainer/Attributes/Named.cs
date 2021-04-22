using System;

namespace DIContainer.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class Named : Attribute
    {

        public Named(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
