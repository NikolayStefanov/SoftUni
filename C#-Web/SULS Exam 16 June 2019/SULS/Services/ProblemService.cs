using SULS.Data;
using SULS.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, int points)
        {
            var problem = new Problem { Name = name, Points = points };
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public string GetNameById(string id)
        {
            var problemName = this.db.Problems.Where(x=> x.Id == id)
                .Select(x=> x.Name)
                .FirstOrDefault();
            return problemName;
        }

        public ProblemViewModel GetProblemById(string id)
        {
            var targetProblem = this.db.Problems.Where(x => x.Id == id).Select(x => new ProblemViewModel
            {
                Name = x.Name,
                Submissions = x.Submissions.Select(s => new SubmissionViewModel
                {
                    SubmissionId = s.Id,
                    Username = s.User.Username,
                    CreatedOn = s.CreatedOn,
                    AchievedResult = s.AchievedResult,
                    MaxPoints = x.Points
                }).ToList()
            }).FirstOrDefault();
            return targetProblem;
        }

        public IEnumerable<HomePageProblemViewModel> GetProblems()
        {

            var problems = this.db.Problems.Select(x => new HomePageProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count
            }).ToList();
            return problems;
        }
    }
}
