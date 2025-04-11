using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Biding_management_System.Domain.Entities.Tender;
namespace Biding_management_System.Persistence.Configurations
{
    public class TenderCategoryConfiguration : IEntityTypeConfiguration<TenderCategory>
    {
        public void Configure(EntityTypeBuilder<TenderCategory> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Industry).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Type).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Location).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Tenders)
                   .WithOne(t => t.Category)
                   .HasForeignKey(t => t.CategoryId);
        }
    }
}
