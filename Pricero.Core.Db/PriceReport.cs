using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class PriceReport
    {
        public int ReportID { get; set; }

        public string ReportContent { get; set; }

        public virtual ChainProduct ChainProduct { get; set; }
    }
}