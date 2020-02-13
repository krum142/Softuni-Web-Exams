using SULS.Models;
using System.Collections.Generic;

namespace SULS.ViewModes
{
    public class DetailsViewModel
    {
        public string Name { get; set; }

        public ICollection<DetailsSubmissionViewModel> Submissions { get; set; }
    }
}
