using System.Collections.Generic;

namespace _2._07.MilitaryElite.Contracts
{
    public interface ICommando
    {

        ICollection<IMission> Missions { get; }
    }
}
