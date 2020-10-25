using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoryService repositoryService;
        private readonly ICommitsService commitsService;

        public CommitsController(IRepositoryService repositoryService, ICommitsService commitsService)
        {
            this.repositoryService = repositoryService;
            this.commitsService = commitsService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            var userId = this.GetUserId();
            var commits = this.commitsService.GetAll(userId);
            return this.View(commits);
        }
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            var repo = this.repositoryService.GetRepoById(id);
            return this.View(repo);
        }
        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            var userId = this.GetUserId();
            if (description.Length < 5)
            {
                return this.Error("Description must has at least 5 characters.");
            }
            this.commitsService.Create(description, id, userId);
            return this.Redirect("/Repositories/All");
        }
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            this.commitsService.Delete(id);
            return this.Redirect("/Commits/All");
        }
    }
}
