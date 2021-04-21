using System;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Happiness -= 5;

            if (robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.IsChipped = true;

            this.Robots.Add(robot);
        }
    }
}
