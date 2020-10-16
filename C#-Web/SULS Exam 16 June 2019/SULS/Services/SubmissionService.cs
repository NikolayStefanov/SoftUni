using SULS.Data;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;

        public SubmissionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string code, string problemId, string currentUserId)
        {
            var problemPoints = this.db.Problems.Where(x => x.Id == problemId).Select(x => x.Points).FirstOrDefault();
            var newSubmission = new Submission
            {
                Code = code,
                AchievedResult = new Random().Next(0, problemPoints +1),
                CreatedOn = DateTime.UtcNow,
                Problem = this.db.Problems.FirstOrDefault(x => x.Id == problemId),
                User = this.db.Users.FirstOrDefault(x => x.Id == currentUserId)
            };
            this.db.Submissions.Add(newSubmission);
            this.db.SaveChanges();
        }

        public bool Delete(string id, string userId)
        {

            var submission = this.db.Submissions.Where(x => x.UserId == userId && x.Id == id).FirstOrDefault();
            if (submission == null)
            {
                return false;
            }
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
            return true;
        }
    }
}
