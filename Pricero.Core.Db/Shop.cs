using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    public class Shop
    {
        public Guid ShopId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
