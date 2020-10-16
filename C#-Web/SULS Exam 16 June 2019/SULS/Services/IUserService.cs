namespace SULS.Services
{
    public interface IUserService
    {
        void CreateUser(string username, string email, string password);
        string GetUserId(string username, string password);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string email);
    }
}
