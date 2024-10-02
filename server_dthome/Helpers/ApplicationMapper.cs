using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //VM || đổ data từ entitie vào VM
            CreateMap<Room, RoomVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Rental, RentalVM>().ReverseMap();
            CreateMap<MemberOfRental, MemberOfRentalVM>().ReverseMap();
            CreateMap<Power, PowerVM>().ReverseMap();
            CreateMap<Trash, TrashVM>().ReverseMap();   
            CreateMap<Water, WaterVM>().ReverseMap();
            CreateMap<Invoice, InvoiceVM>().ReverseMap();
            CreateMap<OwnerAccount, OwnerAccountVM>().ReverseMap();
            CreateMap<OwnerBuilding, OwnerBuildingVM>().ReverseMap();
            //for update and create || là lấy data từ model đổ vào để tạo hoac sửa data trong entity
            CreateMap<RoomModel, Room>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<RentalModel, Rental>();
            CreateMap<MemberOfRentalModel, MemberOfRental>();
            CreateMap<PowerModel, Power>();
            CreateMap<TrashModel, Trash>(); 
            CreateMap<WaterModel, Water>();
            CreateMap<InvoiceModel, Invoice>();
            CreateMap<OwnerAccountModel, OwnerAccount>();
            CreateMap<OwnerBuildingModel, OwnerBuilding>();
        }
    }
}
