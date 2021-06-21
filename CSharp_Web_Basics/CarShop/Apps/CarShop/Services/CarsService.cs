using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(string userId, string model, int year, string imagePath, string plateNumber)
        {
            var car = new Car
            {
                Id = Guid.NewGuid().ToString(),
                Model = model,
                Year = year,
                PictureUrl = imagePath,
                PlateNumber = plateNumber,
                OwnerId = userId,
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public ICollection<CarViewModel> All()
        {
            var cars = this.db.Cars
                .Where(c => c.Issues.Any(i => i.IsFixed == false))
                .Select(c => new CarViewModel
                {
                    Id = c.Id,
                    Image = c.PictureUrl,
                    Model = c.Model,
                    PlateNumber = c.PlateNumber,
                    Year = c.Year,
                    FixedIssues = c.Issues.Count(i => i.IsFixed == true),
                    RemainingIssues = c.Issues.Count(i => i.IsFixed == false),
                })
                .ToList();

            return cars;
        }

        public ICollection<CarViewModel> AllByUser(string userId)
        {
            var cars = this.db.Cars
                .Where(c => c.OwnerId == userId)
                .Select(c => new CarViewModel
                {
                    Id = c.Id,
                    Image = c.PictureUrl,
                    Model = c.Model,
                    PlateNumber = c.PlateNumber,
                    Year = c.Year,
                    FixedIssues = c.Issues.Count(i => i.IsFixed == true),
                    RemainingIssues = c.Issues.Count(i => i.IsFixed == false),
                })
                .ToList();

            return cars;
        }

        public bool IsUserMechanic(string userId)
        {
            var user = this.db.Users.Find(userId);

            return user.IsMechanic;
        }
    }
}
