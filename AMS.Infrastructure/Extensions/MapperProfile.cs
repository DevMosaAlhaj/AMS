using System;
using System.Collections.Generic;
using AMS.Core.Dto.CreateDto;
using AMS.Core.Dto.UpdateDto;
using AMS.Core.ViewModel;
using AMS.Data.DbEntity;
using AutoMapper;

namespace AMS.Infrastructure.Extensions
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {

            // From DbEntity To ViewModel

            CreateMap<ChequeDbEntity, ChequeViewModel>();

            CreateMap<ClientDbEntity, ClientViewModel>()
                .ForMember(x => x.Motors, x => x.MapFrom(i => i.Motors.ConvertAll(o => o.Id)))
                .ForMember(x => x.SaleContracts, x => x.MapFrom(i => i.SaleContracts.ConvertAll(o => o.Id)))
                .ForMember(x => x.MaintenanceServices, x => x.MapFrom(i => i.MaintenanceServices.ConvertAll(o => o.Id)))
                .ForMember(x => x.SparePartsSold, x => x.MapFrom(i => i.SparePartsSold.ConvertAll(o => o.Id)));

            CreateMap<CollectionCommissionDbEntity, CollectionCommissionViewModel>();

            CreateMap<EmployeeDbEntity, EmployeeViewModel>()
                .ForMember(x => x.CollectionCommissions, x => x.MapFrom(i => i.CollectionCommissions.ConvertAll(o => o.Id)))
                .ForMember(x => x.MaintenanceCycles, x => x.MapFrom(i => i.MaintenanceCycles.ConvertAll(o => o.Id)))
                .ForMember(x => x.MaintenanceServices, x => x.MapFrom(i => i.MaintenanceServices.ConvertAll(o => o.Id)))
                .ForMember(x => x.SparePartsSold, x => x.MapFrom(i => i.SparePartsSold.ConvertAll(o => o.Id)));

            CreateMap<ExchangeBillDbEntity, ExchangeBillViewModel>();

            CreateMap<FileDbEntity, FileViewModel>();

            CreateMap<MaintenanceContractDbEntity, MaintenanceContractViewModel>()
                .ForMember(x=> x.MaintenanceCycles,x=> x.MapFrom(y=> y.MaintenanceCycles.ConvertAll(o=> o.Id)));

            CreateMap<MaintenanceCycleDbEntity, MaintenanceCycleViewModel>()
                .ForMember(x => x.MaintenanceTeam, x => x.MapFrom(i => i.MaintenanceTeam.ConvertAll(o => o.Id)))
                .ForMember(x => x.SpareParts, x => x.MapFrom(i => i.SpareParts.ConvertAll(o => o.Id)));

            CreateMap<MaintenanceServiceDbEntity, MaintenanceServiceViewModel>();

            CreateMap<MotorDbEntity, MotorViewModel>()
                .ForMember(x => x.MaintenanceContracts, x => x.MapFrom(i => i.MaintenanceContracts.ConvertAll(o => o.Id)))
                .ForMember(x => x.MaintenanceCycles, x => x.MapFrom(i => i.MaintenanceCycles.ConvertAll(o => o.Id)))
                .ForMember(x => x.MaintenanceServices, x => x.MapFrom(i => i.MaintenanceServices.ConvertAll(o => o.Id)))
                .ForMember(x => x.SaleContracts, x => x.MapFrom(i => i.SaleContracts.ConvertAll(o => o.Id)))
                .ForMember(x => x.SparePartsSold, x => x.MapFrom(i => i.SparePartsSold.ConvertAll(o => o.Id)));

            CreateMap<PriceOfferDbEntity, PriceOfferViewModel>()
                .ForMember(x => x.SpareParts, x => x.MapFrom(i => i.SpareParts.ConvertAll(o => o.Id)));

            CreateMap<SaleContractDbEntity, SaleContractViewModel>()
                .ForMember(x => x.AccessorySpareParts, x => x.MapFrom(i => i.AccessorySpareParts.ConvertAll(o => o.Id)));

            CreateMap<SparePartDbEntity, SparePartViewModel>();

            CreateMap<SparePartSoldDbEntity, SparePartSoldViewModel>()
                .ForMember(x => x.SalesStaff, x => x.MapFrom(i => i.SalesStaff.ConvertAll(o => o.Id)))
                .ForMember(x=> x.SpareParts,x=> x.MapFrom(i=> i.SpareParts.ConvertAll(o=> o.Id)));

            CreateMap<TransactionDbEntity, TransactionViewModel>()
                .ForMember(x => x.AccessoryFiles, x => x.MapFrom(a => a.AccessoryFiles.ConvertAll(i=> i.Id) ))
                .ForMember(x => x.ExchangeBills, x => x.MapFrom(a => a.ExchangeBills.ConvertAll(i=> i.Id) ))
                .ForMember(x => x.Cheques, x => x.MapFrom(a => a.Cheques.ConvertAll(i=> i.Id) ));

            CreateMap<UserDbEntity, UserViewModel>().ForMember(x=> x.UserType,x=> x.MapFrom(i=> i.UserType.ToString()));







            // From CreateDto to DbEntity

            CreateMap<ChequeCreateDto, ChequeDbEntity>();

            CreateMap<ClientCreateDto, ClientDbEntity>();

            CreateMap<CollectionCommissionCreateDto, CollectionCommissionDbEntity>();

            CreateMap<EmployeeCreateDto, EmployeeDbEntity>();

            CreateMap<ExchangeBillCreateDto, ExchangeBillDbEntity>();

            CreateMap<FileCreateDto, FileDbEntity>().ForMember(x => x.FilePath, otp => otp.Ignore());

            CreateMap<MaintenanceContractCreateDto, MaintenanceContractDbEntity>();

            CreateMap<MaintenanceCycleCreateDto, MaintenanceCycleDbEntity>();

            CreateMap<MaintenanceServiceCreateDto, MaintenanceServiceDbEntity>();

            CreateMap<MotorCreateDto, MotorDbEntity>();

            CreateMap<PriceOfferCreateDto, PriceOfferDbEntity>();

            CreateMap<SaleContractCreateDto, SaleContractDbEntity>();

            CreateMap<SparePartCreateDto, SparePartDbEntity>();

            CreateMap<SparePartSoldCreateDto, SparePartSoldDbEntity>();

            CreateMap<TransactionCreateDto, TransactionDbEntity>();

            CreateMap<UserCreateDto, UserDbEntity>();







            // From UpdateDto to DbEntity



            CreateMap<ChequeUpdateDto, ChequeDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<ClientUpdateDto, ClientDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<CollectionCommissionUpdateDto, CollectionCommissionDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<EmployeeUpdateDto, EmployeeDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<ExchangeBillUpdateDto, ExchangeBillDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<FileUpdateDto, FileDbEntity>()
                .ForMember(x => x.FilePath, otp => otp.Ignore())
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<MaintenanceContractUpdateDto, MaintenanceContractDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<MaintenanceCycleUpdateDto, MaintenanceCycleDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<MaintenanceServiceUpdateDto, MaintenanceServiceDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<MotorUpdateDto, MotorDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<PriceOfferUpdateDto, PriceOfferDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<SaleContractUpdateDto, SaleContractDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<SparePartUpdateDto, SparePartDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<SparePartSoldUpdateDto, SparePartSoldDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<TransactionUpdateDto, TransactionDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

            CreateMap<UserUpdateDto, UserDbEntity>()
                .ForAllMembers(otp => otp.Condition((src, destination, srcMember) => srcMember != null));

        }

        private void List<T>()
        {
            throw new NotImplementedException();
        }
    }
}