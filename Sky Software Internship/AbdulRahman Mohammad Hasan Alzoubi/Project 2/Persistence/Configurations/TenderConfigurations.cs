using Biding_management_System.Domain.Entities.Tender;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Biding_management_System.Persistence.Configurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.HasKey(t => t.TenderId);

            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).IsRequired();
            builder.Property(t => t.EligibilityCriteria).IsRequired();

            builder.HasMany(t => t.Documents)
                   .WithOne(d => d.Tender)
                   .HasForeignKey(d => d.TenderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
