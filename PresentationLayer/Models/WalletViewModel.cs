using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class WalletViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }        
    }
}