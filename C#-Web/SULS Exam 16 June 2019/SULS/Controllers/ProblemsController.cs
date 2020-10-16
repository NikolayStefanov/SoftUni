using SULS.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }
        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = this.problemService.GetProblemById(id);
            return this.View(viewModel);
        }
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Problem name must be between 5 and 20 characters!");
            }
            if (points < 50 || points > 300)
            {
                return this.Error("Points must be between 50 and 300 !");
            }
            problemService.Create(name, points);
            return this.Redirect("/");
        }
    }
}
