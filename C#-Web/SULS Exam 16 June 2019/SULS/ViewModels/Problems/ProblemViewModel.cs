using System.Collections.Generic;

namespace SULS.ViewModels.Problems
{
    public class ProblemViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SubmissionViewModel> Submissions { get; set; }
    }
}
