using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        public string Create(string repositoryId, string userId, string description);

        public IEnumerable<CommitListingViewModel> All(string userId);

        public void Delete(string commitId);

        public bool IsOwner(string userId, string commitId);

    }
}
