using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Pricero.Core.Db
{
    public class FavoriteProducts
    {
        public User User { get; set; }
        public Product Product { get; set; }
    }

    public class FavoriteShops
    {
        public User User { get; set; }
        public Shop Shop { get; set; }
    }
}
