using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }

        public string ProducerName { get; set; }
        public string ProducerCountry { get; set; }
        public string ProducerNIP { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}