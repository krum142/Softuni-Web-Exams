using System.Linq;
using PANDA.Services.Interfaces;
using PANDA.ViewModels;
using PANDA.ViewModels.PackageViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace PANDA.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPackageService packageService;

        public PackagesController(IUsersService usersService,IPackageService packageService)
        {
            this.usersService = usersService;
            this.packageService = packageService;
        }
        public HttpResponse Pending()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var models = packageService.GetPendingPackages();

            return this.View(models);
        }

        public HttpResponse Deliver(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            packageService.DeliverPackage(id);

            return this.Redirect("/Packages/Delivered");
        }

        public HttpResponse Delivered()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var models = packageService.GetDeliveredPackages();

            return this.View(models);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var users = this.usersService.GetAllUsernames().ToList();

            return this.View(users);
        }

        [HttpPost]
        public HttpResponse Create(CreatePackageViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Description.Length < 5 || input.Description.Length > 20)
            {
               return this.Redirect("/Packages/Create");
            }

            if (input.Weight < 0)
            {
                return this.Redirect("/Packages/Create");
            }

            packageService.CreatePackage(input);

            return Redirect("/Packages/Pending");
        }

    }
}