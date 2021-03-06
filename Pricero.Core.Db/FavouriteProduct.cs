﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class FavouriteProduct
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}