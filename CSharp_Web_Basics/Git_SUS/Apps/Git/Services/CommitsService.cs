using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CommitListingViewModel> All(string userId)
        {
            var commits = this.db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitListingViewModel
                {
                    Id = x.Id,
                    Repository = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToLocalTime().ToString("F"),
                })
                .ToList();

            return commits;
        }

        public string Create(string repositoryId, string userId, string description)
        {
            var commit = new Commit
            {
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = repositoryId,
                Description = description,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();

            return commit?.Id;
        }

        public void Delete(string commitId)
        {
            var commit = this.db.Commits.Find(commitId);

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public bool IsOwner(string userId, string commitId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.CreatorId == userId && x.Id == commitId);

            if (commit == null)
            {
                return false;
            }

            return true;
        }
    }
}
