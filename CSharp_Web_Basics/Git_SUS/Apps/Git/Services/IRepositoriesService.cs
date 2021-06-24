using Git.Data;
using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        ICollection<Repository> GetAllPublic();

        void Create(string name, string isPublic, string ownerId);

        RepositoryListingViewModel GetRepositoryById(string repositoryId);
    }
}
