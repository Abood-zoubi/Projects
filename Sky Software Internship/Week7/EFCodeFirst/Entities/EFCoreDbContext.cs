using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Entities;

public class EFCoreDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Server=LAPTOP-O13CF61E\\SQLEXPRESS;Database=PurchasingDB;TrustServerCertificate=True;Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne<Vendor>(o => o.Vendor)
            .WithMany(v => v.Orders)
            .HasForeignKey(o => o.VendorId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Vendor>()
            .HasOne<PaymentMethod>(v => v.PaymentMethod)
            .WithMany(pm => pm.Vendors)
            .HasForeignKey(v => v.PaymentMethodId);
    }
    
}

