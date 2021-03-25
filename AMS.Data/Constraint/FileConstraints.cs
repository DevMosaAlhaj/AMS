using AMS.Core.Constant;
using AMS.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMS.Data.Constraint
{
    public class FileConstraints : IEntityTypeConfiguration<FileDbEntity>
    {
        public void Configure(EntityTypeBuilder<FileDbEntity> builder)
        {
            builder.ToTable(DbTablesName.FileTable);

            builder.Property(x => x.FilePath).IsRequired();

            builder.HasOne(x => x.Transaction).WithMany(x => x.AccessoryFiles).OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}