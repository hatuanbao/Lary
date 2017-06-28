using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lary.ViewModel.Branch
{
    public class CreateBranchViewModel
    {
        [Required]
        public string BranchName { get; set; }
    }
}