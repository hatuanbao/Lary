using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lary.Models
{
    public class Order: Base.Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Customer")]
        public long CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}