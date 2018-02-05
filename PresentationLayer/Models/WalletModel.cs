using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class WalletModel
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
    }
}