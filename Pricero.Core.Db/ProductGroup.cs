using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class ProductGroup
    {
        public string ProductGroupID { get; set; }

        public double BaseVATCharge { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}