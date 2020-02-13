using SULS.Data;
using SULS.Models;
using SULS.Services.Interfaces;
using SULS.ViewModes;
using System.Linq;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private SulsDbContext db;
        public ProblemService(SulsDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = (int)points
            };

            db.Problems.Add(problem);
            db.SaveChanges();
        }

        public DetailsViewModel GetSubmissionProblem(string problemid, string userId)
        {
            var submission = db.Problems.Where(p => p.Id == problemid).Select(p => new DetailsViewModel
            {
                Name = p.Name,
                Submissions = p.Submissions.Select(s => new DetailsSubmissionViewModel
                {
                    Username = s.User.Username,
                    CreatedOn = s.CreatedOn,
                    AchievedResult = s.AchievedResult,
                    MaxPoints = p.Points,
                    SubmissionId = s.Id
                }).ToList()

            }).FirstOrDefault();

            return submission;
        }

    }
}
