using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Models
{
    public class WalletModel
    {
        [HiddenInput(DisplayValue = false)]  
        public int Id { get; set; }


        [Required]
        [Range(1, 20000000)]
        public double Balance { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}