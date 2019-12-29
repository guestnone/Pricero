using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class FavouriteShop
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int ShopID { get; set; }

        public virtual User User { get; set; }
        public virtual Shop Shop { get; set; }
    }
}