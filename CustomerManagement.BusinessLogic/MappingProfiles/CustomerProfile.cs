using AutoMapper;
using CustomerManagement.BusinessLogic.Commands;
using CustomerManagement.Core.Entities;

namespace CustomerManagement.BusinessLogic.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerCommand, Customer>();
        }
    }
}
