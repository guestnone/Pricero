using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class ProductGroup
    {
        public string ProductGroupID { get; set; }

        public double BaseVATCharge { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}