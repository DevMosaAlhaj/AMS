using AMS.Data.Constraint;
using Microsoft.EntityFrameworkCore;

namespace AMS.Data.Extension
{
    public static class DbConstraintsExtensions
    {

        public static ModelBuilder ApplyConstrains(this ModelBuilder builder)
        {

            builder.ApplyConfiguration(new ChequeConstraints());
            builder.ApplyConfiguration(new ClientConstraints());
            builder.ApplyConfiguration(new CollectionCommissionConstraints());
            
            builder.ApplyConfiguration(new EmployeeConstraints());
            builder.ApplyConfiguration(new ExchangeBillConstraints());
            
            builder.ApplyConfiguration(new FileConstraints());
            
            builder.ApplyConfiguration(new MaintenanceContractConstraints());
            builder.ApplyConfiguration(new MaintenanceCycleConstraints());
            builder.ApplyConfiguration(new MaintenanceServiceConstraints());
            builder.ApplyConfiguration(new MotorConstraints());
            
            builder.ApplyConfiguration(new PriceOfferConstraints());
            
            builder.ApplyConfiguration(new SaleContractConstraints());
            builder.ApplyConfiguration(new SparePartConstraints());
            builder.ApplyConfiguration(new SparePartSoldConstraints());
            
            builder.ApplyConfiguration(new TransactionConstraints());
            
            return builder;
        }
        
    }
}