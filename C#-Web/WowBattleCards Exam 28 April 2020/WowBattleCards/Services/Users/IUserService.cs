using WowBattleCards.Users.ViewModels;

namespace WowBattleCards.Services.Users
{
    public interface IUserService
    {
        void RegisterUser(UserRegisterViewModel inputModel);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string email);
        string GetUserId(string username, string password);
    }
}
