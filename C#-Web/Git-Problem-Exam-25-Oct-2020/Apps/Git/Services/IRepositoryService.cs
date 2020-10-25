using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void Create(string name, string type, string userId);
        IEnumerable<PublicRepositoriesViewModel> GetPublicRepositories();

        PublicRepositoriesViewModel GetRepoById(string id);
    }
}
