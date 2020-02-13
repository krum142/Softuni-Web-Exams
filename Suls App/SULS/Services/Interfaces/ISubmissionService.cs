using SULS.ViewModes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface ISubmissionService
    {
        SubmissionViewModel GetSubmissionView(string problemId);

        void CreateSubmission(string code, string problemId, string userId);

        bool Delete(string SubmissionId);
    }
}
