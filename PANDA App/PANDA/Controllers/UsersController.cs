using PANDA.Services;
using PANDA.ViewModels;
using PANDA.ViewModels.UserViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using Xunit.Sdk;

namespace PANDA.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username,string password)
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var userId = usersService.GetUserId(username, password);

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                this.Redirect("/");
            }

            this.SignOut();

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterViewModel input)
        {

            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (string.IsNullOrEmpty(input.Username))
            {
                return Redirect("/Users/Register");
            }
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return Redirect("/Users/Register");
            }

            if (string.IsNullOrEmpty(input.Password))
            {
                return Redirect("/Users/Register");

            }

            if (input.Password.Length < 4 || input.Password.Length > 30)
            {
                return Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return Redirect("/Users/Register");

            }

            if (input.Email.Length < 5 || input.Email.Length > 20)
            {
                return Redirect("/Users/Register");
            }

            usersService.CreateUser(input);

            return Redirect("/Users/Login");
        }
    }
}