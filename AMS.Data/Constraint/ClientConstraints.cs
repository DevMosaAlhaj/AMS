using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class ClientConstraints : IEntityTypeConfiguration<ClientDbEntity>
    {
        public void Configure(EntityTypeBuilder<ClientDbEntity> builder)
        {
            builder.ToTable(DbTablesName.ClientTable);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Mediator).HasMaxLength(40);
            builder.Property(x => x.Address).HasMaxLength(250);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.IdentityNo).HasMaxLength(9);

            builder.HasMany(x => x.Motors).WithOne(x => x.Client).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SparePartsSold).WithOne(x => x.Client).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.MaintenanceContracts).WithOne(x => x.Client).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.SaleContracts).WithOne(x => x.Client).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.MaintenanceServices).WithOne(x => x.Client).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}