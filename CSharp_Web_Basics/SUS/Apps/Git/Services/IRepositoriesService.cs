using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<RepositoryListingViewModel> GetAll();

        void Create(string name, string repositoryType, string ownerId);

        RepositoryListingViewModel GetRepositoryById(string repositoryId);
    }
}
