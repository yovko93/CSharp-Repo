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

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepoInputFormModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Repository name should be between 3 and 10 characters.");
            }

            if (model.RepositoryType != "Public" && model.RepositoryType != "Private")
            {
                return this.Error($"Repository type can be either 'Public' or 'Private'.");
            }

            var ownerId = this.GetUserId();

            this.repositoriesService.Create(model.Name, model.RepositoryType, ownerId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var repositories = this.repositoriesService.GetAll();

            return this.View(repositories);
        }

    }
}
