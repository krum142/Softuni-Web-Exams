using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService homeService;

        public HomeController(HomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var problems = homeService.GetProblems();

                return View(problems,"IndexLoggedIn");
            }

            return this.View();
        }

 
    }
}