using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Contracts.V1.Requests;
using Web1.Domain;
using Web1.Helpers;

namespace Web1.MappingProfiles
{
    public class RequestToDomainProfile: Profile
    {
        //private readonly Hash _hash;

        //public RequestToDomainProfile(Hash hash)
        //{
        //    _hash = hash;

        //    CreateMap<DepartmentRequest, Department>();
        //    CreateMap<RegisterRequest, Employee>().ForMember(dest => dest.PasswordHash, opt =>

        //    opt.MapFrom(src => _hash.Create(src.Password))
        //    ); 
        //}

        public RequestToDomainProfile()
        {

            CreateMap<DepartmentRequest, Department>();
            CreateMap<RegisterRequest, Employee>().ForMember(dest => dest.PasswordHash, opt =>

            opt.MapFrom(src => src.Password)
            );
        }
    }
}
