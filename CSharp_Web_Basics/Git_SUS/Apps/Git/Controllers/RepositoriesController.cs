using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var repositories = this.repositoriesService.GetAllPublic()
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
                    Commits = r.Commits.Count()
                })
                .ToList();

            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepoInputFormModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 3 || input.Name.Length > 10)
            {
                return this.Error("Repository name should be between 3 and 10 characters.");
            }

            if (input.RepositoryType != "Public" && input.RepositoryType != "Private")
            {
                return this.Error($"Repository type can be either 'Public' or 'Private'.");
            }

            var ownerId = this.GetUserId();

            this.repositoriesService.Create(input.Name, input.RepositoryType, ownerId);

            return this.Redirect("/Repositories/All");
        }
    }
}
