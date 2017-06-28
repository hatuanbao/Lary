using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lary.Models
{
    public class Customer: Base.Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(200)]
        public string CustomerCode { get; set; }

        [MaxLength(200)]
        public string CustomerName { get; set; }

        [MaxLength(200)]
        public string Phone { get; set; }

       
        public string Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Referral { get; set; }

        [ForeignKey("CustomerType")]
        public int CustomerTypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; }


        [ForeignKey("District")]
        public int DistrictId { get; set; }

        public virtual District District { get; set; }


        public virtual List<Order> Orders { get; set; }
    }
}