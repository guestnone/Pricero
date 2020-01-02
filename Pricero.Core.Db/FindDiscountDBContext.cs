using Microsoft.EntityFrameworkCore;
using Pricero.Core.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class FindDiscountDBContext : DbContext
    {
        public FindDiscountDBContext() : base() {

        }
        
        public DbSet<Shop> Shops { get; set; }
        public DbSet<FavouriteShop> FavouriteShops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FavouriteProduct> FavouriteProducts { get; set; }
        public DbSet<Chain> Chains { get; set; }
        public DbSet<ChainProduct> ChainProducts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<PriceReport> PriceReports { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}