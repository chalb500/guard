using AutoMapper;
using guard.Api.Resources;
using guard.Core.Models;

namespace guard.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Resource
            CreateMap<Employee, EmployeeResource>();

            // Resource to Domain
            CreateMap<EmployeeResource, Employee>();
        }
    }
}