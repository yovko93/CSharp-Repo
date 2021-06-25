using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService users;
        private readonly CarShopDbContext data;

        public IssuesController(IValidator validator, IUserService users, CarShopDbContext data)
        {
            this.data = data;
            this.users = users;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            var issue = new AddIssueViewModel 
            { 
                CarId = carId 
            };

            return this.View(issue);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            if (!this.UserCanAccessCar(model.CarId))
            {
                return Unauthorized();
            }

            var modelErrors = this.validator.ValidateIssue(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var issue = new Issue
            {
                Description = model.Description,
                CarId = model.CarId,
            };

            this.data.Issues.Add(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var carIssues = this.data
                .Cars
                .Where(i => i.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    UserIsMechanic = this.users.IsMechanic(this.User.Id),
                    Issues = c.Issues.Select(i => new IssueListingViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed,
                        IsFixedInformation = i.IsFixed ? "Yes" : "Not Yet"
                    })
                })
                .FirstOrDefault();

            if (carIssues == null)
            {
                return NotFound();
            }

            return this.View(carIssues);
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            var issue = this.data.Issues.Find(issueId);
            this.data.Issues.Remove(issue);
            this.data.SaveChanges();

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            if (!this.users.IsMechanic(this.User.Id))
            {
                return this.Error("User should be a mechanic.");
            }

            var issue = this.data.Issues.Find(issueId);
            issue.IsFixed = true;

            this.data.SaveChanges();

            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }


        private bool UserCanAccessCar(string carId)
        {
            var userIsMechanic = this.users.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                var userOwnsCar = this.users.OwnsCar(this.User.Id, carId);

                if (!userOwnsCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
