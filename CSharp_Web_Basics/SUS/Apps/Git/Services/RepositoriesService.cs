using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string repositoryType, string ownerId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = repositoryType == "Public",
                OwnerId = ownerId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryListingViewModel> GetAll()
        {
            var repositories = this.db.Repositories
              .Where(r => r.IsPublic)
              .Select(x => new RepositoryListingViewModel
              {
                  Id = x.Id,
                  Name = x.Name,
                  Commits = x.Commits.Count(),
                  CreatedOn = x.CreatedOn.ToLocalTime().ToString("F"),
                  Owner = x.Owner.Username,
              })
              .ToList();

            return repositories;
        }

        public RepositoryListingViewModel GetRepositoryById(string repositoryId)
        {
            var repository = db.Repositories
           .Where(x => x.Id == repositoryId)
           .Select(x => new RepositoryListingViewModel
           {
               Id = x.Id,
               Name = x.Name,
               Commits = x.Commits.Count(),
               CreatedOn = x.CreatedOn.ToString(),
               Owner = x.Owner.Username
           })
           .FirstOrDefault();

            return repository;
        }
    }
}
