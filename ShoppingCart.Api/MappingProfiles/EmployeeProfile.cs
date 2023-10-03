using AutoMapper;
using EmployeeManagement.BusinessLogic.Commands;
using ShoppingCart.Api.Requests;

namespace ShoppingCart.Api.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<AddEmployeeRequest, AddEmployeeCommand>();
            CreateMap<ChangeEmployeeStatusRequest, ChangeEmployeeStatusCommand>();
        }
    }
}
