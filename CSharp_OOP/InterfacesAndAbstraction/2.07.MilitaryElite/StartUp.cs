using System;
using System.Linq;
using System.Collections.Generic;

using _2._07.MilitaryElite.Models;
using _2._07.MilitaryElite.Contracts;
using _2._07.MilitaryElite.Enumerations;

namespace _2._07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();

            ISoldier soldier;

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split().ToArray();

                string type = data[0];
                int id = int.Parse(data[1]);
                string firstName = data[2];
                string lastName = data[3];

                switch (type)
                {
                    case "Private":
                        decimal salaryPrivate = decimal.Parse(data[4]);

                        soldier = new Private(id, firstName, lastName, salaryPrivate);

                        soldiers.Add(soldier);
                        break;

                    case "LieutenantGeneral":
                        decimal salaryGeneral = decimal.Parse(data[4]);
                        List<int> ids = data.Skip(5).Select(int.Parse).ToList();

                        List<IPrivate> privates = new List<IPrivate>();

                        foreach (int currentId in ids)
                        {
                            privates.Add((IPrivate)soldiers.FirstOrDefault(x => x.Id == currentId));
                        }

                        soldier = new LieutenantGeneral(id, firstName, lastName, salaryGeneral, privates);

                        soldiers.Add(soldier);
                        break;

                    case "Engineer":
                        decimal salaryEngineer = decimal.Parse(data[4]);
                        string corp = data[5];
                        SoldierCorpEnum soldierCorpEnum = new SoldierCorpEnum();

                        if (corp == "Airforces")
                        {
                            soldierCorpEnum = SoldierCorpEnum.Airforces;
                        }
                        else if (corp == "Marines")
                        {
                            soldierCorpEnum = SoldierCorpEnum.Marines;
                        }
                        else
                        {
                            return;
                        }

                        List<IRepair> repairs = new List<IRepair>();

                        for (int i = 6; i < data.Length - 1; i+=2)
                        {
                            IRepair repair = new Repair(data[i], int.Parse(data[i + 1]));
                            repairs.Add(repair);
                        }

                        soldier = new Engineer(id, firstName, lastName, salaryEngineer, soldierCorpEnum, repairs);

                        soldiers.Add(soldier);
                        break;

                    case "Commando":
                        decimal salaryCommando = decimal.Parse(data[4]);
                        string corpCommando = data[5];

                        SoldierCorpEnum corpCommandoEnum = new SoldierCorpEnum();

                        if (corpCommando == "Airforces")
                        {
                            corpCommandoEnum = SoldierCorpEnum.Airforces;
                        }
                        else if (corpCommando == "Marines")
                        {
                            corpCommandoEnum = SoldierCorpEnum.Marines;
                        }
                        else
                        {
                            return;
                        }

                        List<IMission> missions = new List<IMission>();
                        for (int i = 6; i < data.Length - 1; i+=2)
                        {
                            string state = data[i + 1];
                            MissionStateEnum missionState = new MissionStateEnum();

                            if (state == "inProgress")
                            {
                                missionState = MissionStateEnum.inProgress;
                            }
                            else if (state == "Finished")
                            {
                                missionState = MissionStateEnum.Finished;
                            }
                            else
                            {
                                return;
                            }
                            IMission mission = new Mission(data[i], missionState);

                            missions.Add(mission);
                        }

                        soldier = new Commando(id, firstName, lastName, salaryCommando, corpCommandoEnum, missions);

                        soldiers.Add(soldier);
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(data[4]);

                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        soldiers.Add(soldier);
                        break;

                }
            }

            PrintResult(soldiers);
        }

        public static void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

    }
}
