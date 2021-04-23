using _2._07.MilitaryElite.Enumerations;

namespace _2._07.MilitaryElite.Contracts
{
    public interface IMission
    {

        public string CodeName { get; }

        MissionStateEnum MissionStateEnum { get; }

        void CompleteMission(string missionName);
    }
}
