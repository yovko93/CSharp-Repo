using _2._07.MilitaryElite.Contracts;
using _2._07.MilitaryElite.Enumerations;

namespace _2._07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            this.CodeName = codeName;
            this.MissionStateEnum = missionStateEnum;
        }

        public string CodeName { get; }

        public MissionStateEnum MissionStateEnum { get; }

        public void CompleteMission(string missionName)
        {
            
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.MissionStateEnum}";
        }
    }
}
