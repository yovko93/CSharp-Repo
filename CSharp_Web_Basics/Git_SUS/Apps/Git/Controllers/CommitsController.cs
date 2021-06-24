using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var allCommits = this.commitsService.All(this.GetUserId());

            return this.View(allCommits);
        }

        public HttpResponse Create(string repositoryId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repository = this.repositoriesService.GetRepositoryById(repositoryId);

            var viewModel = new CommitToRepositoryViewModel
            {
                Id = repository.Id,
                Name = repository.Name,
            };

            if (repository == null)
            {
                return this.Error("Repository is not found.");
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Description must be minimum 5 characters long");
            }


            this.commitsService.Create(input.Id, this.GetUserId(), input.Description);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string commitId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.commitsService.IsOwner(this.GetUserId(), commitId))
            {
                return this.Error("Only the creator can delete commits");
            }

            this.commitsService.Delete(commitId);

            return this.Redirect("/Commits/All");
        }
    }
}
