using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
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
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.userService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Login();
            }
            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Register();
            }
            if (inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Register();
            }
            if (inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Register();
            }
            this.userService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);
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
