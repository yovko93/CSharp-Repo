using _2._07.MilitaryElite.Contracts;
using _2._07.MilitaryElite.Enumerations;

namespace _2._07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum) 
            : base(id, firstName, lastName, salary)
        {
            this.SoldierCorpEnum = soldierCorpEnum;
        }

        public SoldierCorpEnum SoldierCorpEnum { get; }

        //public override string ToString()
        //{
        //    return $"{base.ToString()}";
        //}
    }
}
