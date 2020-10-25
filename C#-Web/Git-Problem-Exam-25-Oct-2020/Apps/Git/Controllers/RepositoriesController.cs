using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }
        public HttpResponse All()
        {
            var repos = this.repositoryService.GetPublicRepositories();
            return this.View(repos);
        }
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            var userId = this.GetUserId();
            if (name.Length < 3 || name.Length > 10)
            {
                return this.Redirect("/Repositories/Create");
            }
            this.repositoryService.Create(name, repositoryType, userId);
            return this.Redirect("/Repositories/All");
        }

    }
}
