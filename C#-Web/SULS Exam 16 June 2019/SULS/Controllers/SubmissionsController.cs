using SULS.Services;
using SULS.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class SubmissionsController: Controller
    {
        private readonly ISubmissionService submissionService;
        private readonly IProblemService problemService;

        public SubmissionsController(ISubmissionService submissionService, IProblemService problemService)
        {
            this.submissionService = submissionService;
            this.problemService = problemService;
        }
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = new CreateViewModel
            {
                Name = this.problemService.GetNameById(id),
                ProblemId = id
            };

            return this.View(viewModel);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            var isDeleted = this.submissionService.Delete(id, userId);
            if (!isDeleted)
            {
                return this.Error("You can delete only your submissions!");
            }
            return this.Redirect("/");
        }
        [HttpPost]
        public HttpResponse Create(string code, string problemId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (string.IsNullOrWhiteSpace(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("The submission code must be between 30 and 800 symbols!");
            }

            var currentUserId = this.GetUserId();
            this.submissionService.Create(code, problemId, currentUserId);

            return this.Redirect("/");
        }
    }
}
