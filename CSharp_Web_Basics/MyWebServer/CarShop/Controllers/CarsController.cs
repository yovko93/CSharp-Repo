﻿using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Cars;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService users;
        private readonly CarShopDbContext data;

        public CarsController(
           IValidator validator,
           IUserService users,
           CarShopDbContext data)
        {
            this.validator = validator;
            this.users = users;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.data.Cars.AsQueryable();

            if (this.users.IsMechanic(this.User.Id))
            {
                carsQuery = carsQuery
                   .Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery
                    .Where(c => c.OwnerId == this.User.Id);
            }

            var cars = carsQuery
                .Select(c => new AllCarViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Image = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    RemainingIssues = c.Issues.Count(i => !i.IsFixed),
                    FixedIssues = c.Issues.Count(i => i.IsFixed)
                })
                .ToList();

            return this.View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.users.IsMechanic(this.User.Id))
            {
                return this.Error("Mechanics cannot add cars.");
            }

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarFormModel model)
        {
            var modelErrors = this.validator.ValidateCar(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id,
            };

            this.data.Cars.Add(car);
            this.data.SaveChanges();

            return this.Redirect("/Cars/All");
        }
    }
}
