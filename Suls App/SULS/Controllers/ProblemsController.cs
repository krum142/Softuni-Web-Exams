using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services.Interfaces;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {

        private IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }


        [HttpPost]
        public HttpResponse Create(string name,int points) // model here maybe idk
        {

            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(string.IsNullOrEmpty(name))
            {
                return this.Error("Name cannot be empty");
            }

            if(name.Length < 5 || name.Length > 20)
            {
                return this.Error("Name must be between [5-20] characters long");
            }

            if(points < 0)
            {
                return this.Error("Points cannot be negative");
            }

            if(points < 50 || points > 300)
            {
                return this.Error("Points Must be between [50-300]"); 
            }

            problemService.CreateProblem(name, points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var submissis = problemService.GetSubmissionProblem(id, this.User);

            if(submissis == null)
            {
                return this.Error("No such detail!");
            }

            return this.View(submissis);
        }

    }
}
