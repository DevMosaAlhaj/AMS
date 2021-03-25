using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class PriceOfferConstraints : IEntityTypeConfiguration<PriceOfferDbEntity>
    {
        public void Configure(EntityTypeBuilder<PriceOfferDbEntity> builder)
        {
            builder.ToTable(DbTablesName.PriceOfferTable);

            builder.Ignore(x => x.TotalPrice);
            builder.Property(x => x.TotalPriceCurrency).IsRequired().HasMaxLength(15);
            

            builder.HasMany(x => x.SpareParts);
            builder.HasOne(x => x.MaintenanceService)
                .WithOne(x => x.PriceOffer)
                .HasForeignKey<PriceOfferDbEntity>(x=> x.MaintenanceServiceId).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}