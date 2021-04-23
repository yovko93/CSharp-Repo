using _2._07.MilitaryElite.Contracts;
using _2._07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, 
            string firstName,
            string lastName, 
            decimal salary,
            SoldierCorpEnum soldierCorpEnum,
            ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var repair in this.Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return $"{base.ToString()}" + 
                Environment.NewLine + 
                $"Corps: {this.SoldierCorpEnum}" + 
                Environment.NewLine + 
                $"Repairs:" + 
                Environment.NewLine+
                sb;
        }
    }
}
