using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(string carId, string description)
        {
            var issue = new Issue
            {
                Id = Guid.NewGuid().ToString(),
                Description = description,
                IsFixed = false,
                CarId = carId,
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();
        }

        public void Delete(string carId, string issueId)
        {
            var issueForDelete = this.db.Issues
                 .FirstOrDefault(x => x.Id == issueId && x.CarId == carId);

            if (issueForDelete == null)
            {
                return;
            }

            this.db.Issues.Remove(issueForDelete);
            this.db.SaveChanges();
        }

        public void Fix(string issueId, string carId)
        {
            var issue = db.Issues
                .FirstOrDefault(x => x.Id == issueId && x.CarId == carId)
                .IsFixed = true;

            this.db.SaveChanges();
        }

        public CarIssuesViewModel GetAllIssues(string carId)
        {
            var targetCar = this.db.Cars.Find(carId);

            var carModel = new CarIssuesViewModel()
            {
                Model = targetCar.Model,
                Year = targetCar.Year,
                CarId = carId,
                Issues = this.db.Issues
                .Where(c => c.CarId == carId)
                .Select(i => new IssueViewModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    IsFixed = i.IsFixed,
                })
                .ToList()
            };

            return carModel;
        }
    }
}
