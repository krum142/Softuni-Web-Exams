using PANDA.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;

namespace PANDA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {

                var username = this.usersService.GetUserNmae(this.User);

                return View(username,"IndexLoggedIn");
            }
            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexLoggedIn ()
        {
            return this.Index();
        }
    }
}