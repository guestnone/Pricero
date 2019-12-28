using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FindDiscount.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordInitValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
        public virtual ICollection<FavouriteShop> FavouriteShops { get; set; }
        public virtual ICollection<FavouriteProduct> FavouriteProducts { get; set; }
    }
}