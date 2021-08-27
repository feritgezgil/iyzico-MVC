using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IyzicoPay.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public double Price { get; set; }
    }
}