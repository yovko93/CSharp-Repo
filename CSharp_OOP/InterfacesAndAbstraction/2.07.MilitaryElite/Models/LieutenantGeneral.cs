using System;
using System.Text;

using System.Collections.Generic;
using _2._07.MilitaryElite.Contracts;

namespace _2._07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var @private in this.Privates)
            {
                sb.AppendLine($"  {@private.ToString()}");
            }

            return $"{base.ToString()}" +
                Environment.NewLine +
                "Privates:" +
                Environment.NewLine +
                sb.ToString().Trim();
        }
    }
}
