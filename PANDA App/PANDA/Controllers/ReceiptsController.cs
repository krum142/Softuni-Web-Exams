using PANDA.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace PANDA.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly RecipientService recipientService;

        public ReceiptsController(RecipientService recipientService)
        {
            this.recipientService = recipientService;
        }
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }


            var model = recipientService.GetAllReceiptsForUser(this.User);

            return this.View(model);
        }
    }
}