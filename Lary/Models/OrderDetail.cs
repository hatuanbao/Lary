using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lary.Models
{
    public class OrderDetail: Base.Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Order")]
        public long OrderId { get; set; }

        public virtual Order Order { get; set; }


        [ForeignKey("Item")]
        public long ItemId { get; set; }

        public virtual Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}