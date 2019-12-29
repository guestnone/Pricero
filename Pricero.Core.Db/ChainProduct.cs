using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class ChainProduct
    {
        public int ChainProductID { get; set; }

        public double Price { get; set; }

        public virtual Chain Chain { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<PriceReport> PriceReports { get; set; }
    }
}