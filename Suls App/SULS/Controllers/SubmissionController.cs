using SIS.HTTP;
using SIS.MvcFramework;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            this.submissionService = submissionService;
        }
        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var submission = submissionService.GetSubmissionView(id);

            if(submission == null)
            {
               return this.Error("Problem not found!");
            }

            return this.View(submission);
        }

        [HttpPost]
        public HttpResponse Create(string code, string problemId)
        {
         

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please provide code with at least 30 characters.");
            }

            this.submissionService.CreateSubmission(code,problemId, this.User);

            return Redirect("/");

        }



        public HttpResponse Delete(string id)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (submissionService.Delete(id) == false)
            {
                return this.Error("No Such Submission");
            }

            return Redirect("/");
        }
    }
}
