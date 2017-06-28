using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lary.ViewModel.Product
{
    public class CreateItemViewModel
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        public string CalculationUnit { get; set; }
        public long? Input { get; set; }
        public long? Output { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}