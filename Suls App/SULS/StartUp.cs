using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Data;
using SULS.Services;
using SULS.Services.Interfaces;
using System.Collections.Generic;

namespace SULS.App
{
    public class StartUp : IMvcApplication
    {

        public void Configure(IList<Route> routeTable)
        {
            using var db = new SulsDbContext();
            db.Database.EnsureCreated();
            //db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //throw new System.NotImplementedException();
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<IProblemService, ProblemService>();
            serviceCollection.Add<ISubmissionService, SubmissionService>();
        }
    }
}