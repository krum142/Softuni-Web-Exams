using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.ViewModes
{
    public class DetailsSubmissionViewModel
    {
        public string SubmissionId { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
