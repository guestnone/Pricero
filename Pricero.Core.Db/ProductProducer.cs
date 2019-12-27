using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    class ProductProducer
    {
        public Guid ProducerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string TaxNumber { get; set; }
    }
}
