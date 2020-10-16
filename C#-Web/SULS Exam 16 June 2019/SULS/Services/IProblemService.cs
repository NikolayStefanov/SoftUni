using SULS.ViewModels.Problems;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemService
    {
        void Create(string name, int points);
        IEnumerable<HomePageProblemViewModel> GetProblems();
        string GetNameById(string id);
        ProblemViewModel GetProblemById(string id);
    }
}
