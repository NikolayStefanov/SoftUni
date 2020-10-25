using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string description, string repoId, string creatorId);
        IEnumerable<CommitViewModel> GetAll(string userId);
        void Delete(string commitId);
    }
}
