using OnlineMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineMarket.Data
{
    public class OnlineMarketDbContext : DbContext
    {
        public OnlineMarketDbContext(DbContextOptions options): base(options)
        {   
        }

        public DbSet<Delivery> Deliveries  { get; set; }
        public DbSet<DeliveryImage> DeliveryImages  { get; set; }
        public DbSet<Order> Orders  { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ReceiptImage> ReceiptImages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Delivery

            modelBuilder.Entity<Delivery>()
                .HasMany(d => d.DeliveryImages)
                .WithOne(i => i.Delivery)
                .HasForeignKey(i => i.DeliveryId);

            #endregion

            #region Orders

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.DeliveryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.PaymentId);

            #endregion

            #region Payment

            modelBuilder.Entity<Payment>()
                .HasMany(p => p.ReceiptImages)
                .WithOne(i => i.Payment)
                .HasForeignKey(i => i.PaymentId);

            #endregion

            #region Products

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(o => o.Products)
                .UsingEntity<ProductOrder>(
                op => op.HasOne(a => a.Order).WithMany(),
                op => op.HasOne(b => b.Product).WithMany()
                );

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            #endregion

            #region ProductOrder

            modelBuilder.Entity<ProductOrder>()
                .HasKey(o  => o.ProductOrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(o => o.Product)
                .WithMany(product => product.ProductOrders)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(o => o.Order)
                .WithMany(order => order.ProductOrders)
                .HasForeignKey(f => f.OrderId);

            #endregion

            #region User

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId);

            #endregion
        }

    }
}
