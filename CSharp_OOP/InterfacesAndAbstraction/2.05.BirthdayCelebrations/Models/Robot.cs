using _2._05.BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._05.BirthdayCelebrations.Models
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
