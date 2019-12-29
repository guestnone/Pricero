using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class Discount
    {
        public int DiscountID { get; set; }

        public double DiscountPrice { get; set; }
        public DateTime DiscountFrom { get; set; }
        public DateTime DiscountTo { get; set; }

        public virtual ChainProduct ChainProduct { get; set; }
    }
}