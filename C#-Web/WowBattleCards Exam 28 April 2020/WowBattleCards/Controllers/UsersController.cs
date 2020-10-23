using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using WowBattleCards.Services.Users;
using WowBattleCards.Users.ViewModels;

namespace WowBattleCards.Controllers
{
    public class UsersController: Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }
            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel inputModel)
        {
            if (inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters!");
            }
            if (!this.userService.IsUsernameAvailable(inputModel.Username))
            {
                return this.Error("Username is unavailable!");
            }
            if (!this.userService.IsEmailAvailable(inputModel.Email) || !new EmailAddressAttribute().IsValid(inputModel.Email))
            {
                return this.Error("Invalid or unavailable email address!");
            }
            if (string.IsNullOrWhiteSpace(inputModel.Password) || inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("The passwords must be identical!");
            }
            if (inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Error("Tha password must be between 6 and 20 characters.");
            }
            this.userService.RegisterUser(inputModel);
            return this.Redirect("/Users/Login");
        }

        [HttpGet("/Logout")]
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
