using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class Chain
    {
        public int ChainId { get; set; }
        public string ChainName { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}