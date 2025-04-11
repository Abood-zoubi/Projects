using System.Security.Cryptography;
using Biding_management_System.Domain.Entities;
using Biding_management_System.Domain.Entities.Bids;
using Biding_management_System.Domain.Entities.Tender;
using Microsoft.EntityFrameworkCore;

namespace Biding_management_System.Infrastructure.Data
{    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tender> Tenders { get; set; } = null!;
        public DbSet<TenderCategory> Categories { get; set; } = null!;
        public DbSet<Document> Documents { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<BidDocument> BidDocuments { get; set; }
        public DbSet<BidEvaluation> BidEvaluations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Server=LAPTOP-O13CF61E\\SQLEXPRESS;Database=RestApi1DB;TrustServerCertificate=True;Trusted_Connection=true;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Username).IsRequired().HasMaxLength(200);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
                entity.Property(u => u.Password).IsRequired();
            });

            modelBuilder.Entity<Tender>(entity =>
            {
                entity.HasKey(t => t.TenderId);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).IsRequired();
                entity.Property(t => t.Budget);
                entity.HasOne<TenderCategory>()
                    .WithMany()
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TenderCategory>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.Industry).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Type).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Location).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Tender)
                .WithMany(t => t.Documents)
                .HasForeignKey(d => d.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Tender)
                .WithMany(t => t.Bids)
                .HasForeignKey(b => b.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BidDocument>()
                .HasOne(d => d.Bid)
                .WithMany(b => b.Documents)
                .HasForeignKey(d => d.BidId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BidEvaluation>()
                .HasOne(b => b.Bid)
                .WithMany()
                .HasForeignKey(b => b.BidingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tender>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tenders)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
                .Property(b => b.BidAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BidEvaluation>()
                .Property(b => b.PriceScore)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BidEvaluation>()
                .Property(b => b.ExperienceScore)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BidEvaluation>()
                .Property(b => b.ComplianceScore)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BidEvaluation>()
                .Property(b => b.TotalScore)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Tender>()
                .Property(t => t.Budget)
                .HasColumnType("decimal(18,2)");
        }
    }
}
