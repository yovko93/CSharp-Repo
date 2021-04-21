using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            this.SeedProcedures();
        }

        public string Charge(string robotName, int procedureTime)
        {
            return this.DoService(robotName, procedureTime, ProcedureType.Charge, OutputMessages.ChargeProcedure);
        }

        public string Chip(string robotName, int procedureTime)
        {
            return this.DoService(robotName, procedureTime, ProcedureType.Chip, OutputMessages.ChipProcedure);
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);

            IProcedure procedure = this.procedures[procedureTypeEnum];

            return procedure.History().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            return this.DoService(robotName, procedureTime, ProcedureType.Polish, OutputMessages.PolishProcedure);
        }

        public string Rest(string robotName, int procedureTime)
        {
            return this.DoService(robotName, procedureTime, ProcedureType.Rest, OutputMessages.RestProcedure);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = this.GetRobotByName(robotName);

            this.garage.Sell(robotName, ownerName);

            string result = string.Empty;

            if (robot.IsChipped)
            {
                result = String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                result = String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            return this.DoService(robotName, procedureTime, ProcedureType.TechCheck, OutputMessages.TechCheckProcedure);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            IProcedure procedure = this.procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);

            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private IRobot GetRobotByName(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return this.garage.Robots[robotName];
        }


        private string DoService(string robotName, int procedureTime, ProcedureType procedureType, string outputTemplate)
        {
            IRobot robot = this.GetRobotByName(robotName);

            IProcedure procedure = this.procedures[procedureType];
            procedure.DoService(robot, procedureTime);

            return String.Format(outputTemplate, robot.Name);
        }

        private void SeedProcedures()
        {
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
            this.procedures.Add(ProcedureType.Work, new Work());
        }
    }
}
