using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PANDA.Data;
using PANDA.Services;
using PANDA.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;

namespace PANDA
{
    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            using var db = new PandaContext();


           // db.Database.Migrate();
           //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            //db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //throw new System.NotImplementedException();
             serviceCollection.Add<IUsersService, UsersService>();
             serviceCollection.Add<IPackageService, PackageService>();
             serviceCollection.Add<IRecipientService,RecipientService>();
        }
    }
}