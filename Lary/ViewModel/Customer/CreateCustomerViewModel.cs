using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lary.ViewModel.Customer
{
    public class CreateCustomerViewModel
    {
        [MaxLength(200)]
        public string CustomerCode { get; set; }

        [MaxLength(200)]
        [Required]
        public string CustomerName { get; set; }

        [MaxLength(200)]
        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Referral { get; set; }
        public int CustomerTypeId { get; set; }
        
        public int DistrictId { get; set; }
    }
}