using System;
using System.Collections.Generic;
using System.Text;

namespace Pricero.Core.Db
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductWeight { get; set; }
        public string UpcCode { get; set; }

        // Relations
        public Guid ProducerId { get; set; }
        public string ProductGroupType { get; set; }

    }
}
