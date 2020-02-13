using SULS.ViewModes;

namespace SULS.Services.Interfaces
{
    public interface IProblemService
    {
        void CreateProblem(string name, int points);

        DetailsViewModel GetSubmissionProblem(string problemid, string userId);


    }
}
