using SULS.Data;
using SULS.Models;
using SULS.ViewModes;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SulsDbContext db;

        public Random Random { get; }

        public SubmissionService(SulsDbContext db,Random random)
        {
            this.db = db;
            Random = random;
        }
        public SubmissionViewModel GetSubmissionView(string problemId)
        {

            var problem = db.Problems.Where(p => p.Id == problemId).Select(p => new SubmissionViewModel
            {
                ProblemId = p.Id,
                Name = p.Name
            }).FirstOrDefault();

            return problem;
        }

        public void CreateSubmission(string code, string problemId,string userId)
        {
            var problem = db.Problems.FirstOrDefault(p => p.Id == problemId);

            var submission = new Submission()
            {
                UserId = userId,
                Code = code,
                Problem = problem,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = Random.Next(50, problem.Points),
            };

            db.Submissions.Add(submission);
            db.SaveChanges();
        }

        public bool Delete(string SubmissionId)
        {
            var submission = db.Submissions.FirstOrDefault(s => s.Id == SubmissionId);

            if (submission == null)
            {
                return false;
            }

            db.Submissions.Remove(submission);
            db.SaveChanges();

            return true;
        }

    }
}
