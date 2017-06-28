using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lary.ViewModel.Staff
{
    public class CreateStaffViewModel
    {
        [Required]
        public string StaffName { get; set; }
    }
}