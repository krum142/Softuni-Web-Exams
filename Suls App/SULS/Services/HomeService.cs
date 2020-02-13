using SULS.Data;
using SULS.Models;
using SULS.Services.Interfaces;
using SULS.ViewModes;
using System.Linq;

namespace SULS.Services
{
    public class HomeService : IHomeService
    {
        private SulsDbContext db;

        public HomeService(SulsDbContext db)
        {
            this.db = db;
        }

        public LoggedInProblemsViewModels GetProblems()
        {
           var problem = db.Problems.Select(x => new ProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count

            }).ToList();

            var problems = new LoggedInProblemsViewModels()
            {
                Problems = problem
            };

            return problems;
        }
    }
}
