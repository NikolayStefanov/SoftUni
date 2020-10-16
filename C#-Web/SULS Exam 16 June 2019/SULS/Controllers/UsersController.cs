using SULS.Services;
using SULS.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace SULS.Controllers
{
    public class UsersController : Controller
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
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            if (string.IsNullOrEmpty(input.Username) ||input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters!");
            }
            if (!userService.IsUsernameAvailable(input.Username))
            {
                return this.Error("The username is already taken.");
            }
            if (string.IsNullOrWhiteSpace(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email address.");
            }
            if (!userService.IsEmailAvailable(input.Email))
            {
                return this.Error("The email is already taken!");
            }
            if (string.IsNullOrWhiteSpace(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters!");
            }
            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("The passwords are not identical.");
            }

            this.userService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
