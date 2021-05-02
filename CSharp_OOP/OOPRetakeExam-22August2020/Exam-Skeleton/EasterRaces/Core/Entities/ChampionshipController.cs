using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using EasterRaces.Core.Contracts;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> drivers;
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRace> races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var car = this.cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car;

            car = this.cars.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.cars.Add(car);

            var succMsg = String.Format(OutputMessages.CarCreated, car.GetType().Name, model);

            return succMsg;
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver;

            driver = this.drivers.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            this.drivers.Add(driver);

            var succMsg = String.Format(OutputMessages.DriverCreated, driverName);

            return succMsg;
        }

        public string CreateRace(string name, int laps)
        {
            IRace race;

            race = this.races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);
            this.races.Add(race);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var participants = race.Drivers
                .Where(x => x.CanParticipate)
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(OutputMessages.DriverFirstPosition, participants[0].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.DriverSecondPosition, participants[1].Name, raceName)); 
            sb.AppendLine(String.Format(OutputMessages.DriverThirdPosition, participants[2].Name, raceName));

            this.races.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
