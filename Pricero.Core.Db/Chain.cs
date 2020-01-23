using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class Chain
    {
        [Key]
        public int ChainId { get; set; }
        public string ChainName { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}