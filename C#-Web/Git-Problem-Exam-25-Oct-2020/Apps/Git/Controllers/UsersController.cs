using Git.Services;
using Git.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }
            this.SignIn(userId);
            return this.Redirect("/Repositories/All");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }
            if (inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }
            if (inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }
            if (!this.usersService.IsEmailAvailable(inputModel.Email) || 
                !this.usersService.IsUsernameAvailable(inputModel.Username))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.CreateUser(inputModel);

            return this.Redirect("/Users/Login");
        }
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }
            this.SignOut();
            return this.Redirect("/Users/Login");
        }
    }
}
