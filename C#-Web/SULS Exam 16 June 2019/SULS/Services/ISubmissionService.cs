namespace SULS.Services
{
    public interface ISubmissionService
    {
        void Create(string code, string problemId, string currentUserId);
        bool Delete(string id, string userId);
    }
}
