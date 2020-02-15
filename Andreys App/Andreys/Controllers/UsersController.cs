using Andreys.App.Services;
using Andreys.App.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {

            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (password == null || password.Length == 0)
            {
                return this.Error("Password Can't be empty!");
            }

            if (password.Length < 6 || password.Length > 20)
            {
                return this.Error("Password should be between [6-20]");
            }

            if (username == null || username.Length == 0)
            {
                return this.Error("Username Can't be empty!");
            }

            if (username.Length < 5 || username.Length > 20)
            {
                return this.Error("Username should be between [5-20]");
            }

            var userId = usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("There is no such user!");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (input.Password == null || input.Password.Length == 0)
            {
                return this.Error("Password Can't be empty!");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between [6-20]");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            if (input.Username == null || input.Username.Length == 0)
            {
                return this.Error("Username Can't be empty!");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between [5-20]");
            }

            if (input.Email == null || input.Email.Length == 0)
            {
                return this.Error("Email cannot be Empty");
            }

            if (!usersService.IsValidEmail(input.Email))
            {
                return this.Error("The Email is not vailid");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (IsUserLoggedIn())
            {
                this.SignOut();

                return Redirect("/");
            }

            return Redirect("/Users/Login");
        }
    }
}