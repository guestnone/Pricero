using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public double ProductWeight { get; set; }
        public string UpcCode { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual ICollection<PriceReport> PriceReports { get; set; }
        public virtual ICollection<FavouriteProduct> FavouriteProducts { get; set; }
        public virtual ICollection<ChainProduct> ChainProducts { get; set; }
    }
}