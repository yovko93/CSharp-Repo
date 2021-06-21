using CarShop.Services;
using CarShop.ViewModels.Issues;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;

        public IssuesController(IIssuesService issuesService, IUsersService usersService)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            CarIssuesViewModel model = issuesService.GetAllIssues(carId);

            return View(model);
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            return View(carId);
        }

        [HttpPost]
        public HttpResponse Add(string carId, string description)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
            {
                return Error("Description must be more than 5 characters long");
            }

            issuesService.Add(carId, description);
            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Delete(string carId, string issueId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            issuesService.Delete(carId, issueId);
            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Fix(string carId, string issueId)
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/Users/Login");
            }

            if (!usersService.IsUserMechanic(GetUserId()))
            {
                return this.Error("User should be a mechanic.");
            }

            issuesService.Fix(issueId, carId);
            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
