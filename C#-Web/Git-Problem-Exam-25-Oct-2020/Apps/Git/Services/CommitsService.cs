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
        public void Create(string description, string repoId, string creatorId)
        {
            var newCommit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = creatorId,
                RepositoryId = repoId
            };

            this.db.Commits.Add(newCommit);
            this.db.SaveChanges();
        }

        public void Delete( string commitId)
        {
            var targetCommit = this.db.Commits.Where(x => x.Id == commitId).FirstOrDefault();
            this.db.Commits.Remove(targetCommit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            var commits = this.db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
            {
                CreatedOn = x.CreatedOn.ToString(),
                Description = x.Description,
                RepositoryName = x.Repository.Name,
                Id = x.Id
            }).ToList();
            return commits;
        }
    }
}
