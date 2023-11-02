using LuxiCart.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LuxiCart.EF.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductItem> productItems { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<TypeOfIdentity> typeOfIdentities { get; set; }
        public DbSet<ProofOfIdentity> proofOfIdentities { get; set; }
        
        public DbSet<SellerCreditCard> sellerCreditCards { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }

        public DbSet<ProductCategory> ProductSubCategories { get; set; }
        public DbSet<ProductParentCategory> productParentCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SellerInfo> SellerInfos { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<Promotion> Promotions { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(9,2)");

            builder.Entity<ProductItem>().Property(x => x.Price).HasColumnType("decimal(9,2)");

            builder.Entity<ShopOrder>().Property(x => x.OrderTotal).HasColumnType("decimal(9,2)");

            builder.Entity<ShippingMethod>().Property(x => x.ShippingPrice).HasColumnType("decimal(9,2)");

            builder.Entity<OrderLine>().Property(x => x.Price).HasColumnType("decimal(9,2)");

            builder.Entity<Promotion>().Property(x => x.DiscountRate).HasColumnType("decimal(9,2)");

            base.OnModelCreating(builder);

        }
    }
}
