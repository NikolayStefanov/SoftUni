using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, string type, string userId)
        {
            var newRepo = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = type.ToLower() == "public" ? true : false,
                OwnerId = userId,
            };
            this.db.Repositories.Add(newRepo);
            this.db.SaveChanges();
        }

        public IEnumerable<PublicRepositoriesViewModel> GetPublicRepositories()
        {
            var publicRepos = this.db.Repositories.Where(x => x.IsPublic).Select(x => new PublicRepositoriesViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn.ToString(),
                CommitsCount = x.Commits.Count,
                Id = x.Id
            }).ToList();
            return publicRepos;
        }

        public PublicRepositoriesViewModel GetRepoById(string id)
        {
            var targetRepo = this.db.Repositories.Where(x => x.Id == id).Select(x => new PublicRepositoriesViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CommitsCount = x.Commits.Count,
                CreatedOn = x.CreatedOn.ToString(),
                Id = x.Id
            }).FirstOrDefault();

            return targetRepo;
        }
    }
}
