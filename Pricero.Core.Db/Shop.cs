using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pricero.Core.Db
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual Chain Chain { get; set; }
        public virtual ICollection<FavouriteShop> FavouriteShops { get; set; }
    }
}