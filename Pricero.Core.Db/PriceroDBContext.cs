using Microsoft.EntityFrameworkCore;
using Pricero.Core.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pricero.Core.Db
{
    public class PriceroDBContext : DbContext
    {
        private static bool _created = false;
        public PriceroDBContext() : base() {
            if (!_created)
            {
                _created = true;
                Database.Migrate();
            }
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
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=local_db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sets the composites for favourites
            // See: https://stackoverflow.com/questions/40898365/asp-net-add-migration-composite-primary-key-error-how-to-use-fluent-api/40898681
            modelBuilder.Entity<FavouriteProduct>()
                .HasKey(c => new { c.ProductID, c.UserID});
            modelBuilder.Entity<FavouriteShop>()
                .HasKey(c => new { c.ShopID, c.UserID });
            modelBuilder.Entity<Message>()
                    .HasOne(m => m.MessageReceiver)
                    .WithMany(t => t.ReceivedMessages)
                    .HasForeignKey(m => m.MessageReceiverId)
                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                        .HasOne(m => m.MessageSender)
                        .WithMany(t => t.SentMessages)
                        .HasForeignKey(m => m.MessageSenderId)
                        .OnDelete(DeleteBehavior.Cascade);
        }


    }
}