using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lary.Models
{
    public class Item: Base.Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string CalculationUnit { get; set; }
        public long? Input { get; set; }
        public long? Output { get; set; }
        public decimal Price { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}