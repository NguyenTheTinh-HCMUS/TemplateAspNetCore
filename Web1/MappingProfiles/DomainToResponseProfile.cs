using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Contracts.V1.Responses;
using Web1.Domain;
using Web1.Helpers;

namespace Web1.MappingProfiles
{
    public class DomainToResponseProfile:Profile
    {

        public DomainToResponseProfile()
        {


            CreateMap< Employee, EmployeeDTO>();
            CreateMap< Role, RoleDTO>();
            CreateMap< Department, DepartmentDTO>();
            CreateMap<PagePagination<Department>, PagePagination<DepartmentDTO>>()
                .ForMember(dest => dest.data, opt => opt.MapFrom(src => src.data));





            CreateMap<AuthResult, AuthResponseSuccess>();
        


        }    
    }
}
