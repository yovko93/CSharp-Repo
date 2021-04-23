using _2._07.MilitaryElite.Contracts;
using _2._07.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id,
            string firstName, 
            string lastName, 
            decimal salary, 
            SoldierCorpEnum soldierCorpEnum,
            ICollection<IMission> missions) : base(id, firstName, lastName, salary, soldierCorpEnum)
        {

            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"{mission}");
            }

            return $"{base.ToString()}" +
                Environment.NewLine +
                $"Corps: {this.SoldierCorpEnum}" +
                Environment.NewLine +
                "Missions:" + 
                Environment.NewLine + 
                sb;
        }
    }
}
