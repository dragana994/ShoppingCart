using AutoMapper;
using EmployeeManagement.BusinessLogic.Commands;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.BusinessLogic.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<AddEmployeeCommand, Employee>();
        }
    }
}
