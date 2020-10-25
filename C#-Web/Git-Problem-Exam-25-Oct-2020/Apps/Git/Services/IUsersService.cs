using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IUsersService
    {
        void CreateUser(RegisterInputModel inputModel);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}
