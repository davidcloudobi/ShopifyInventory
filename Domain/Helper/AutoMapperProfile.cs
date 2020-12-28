using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Data.Model.Identity;
using Domain.DTO.Request;

namespace Domain.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<UserRequest, ApplicationUser>().ReverseMap();

            CreateMap<BusinessRequest, Business >().ReverseMap();

            CreateMap<CustomerRequest, Customer>().ReverseMap();

            //CreateMap<CreateRequest, Account>();

            //CreateMap<UpdateRequest, Account>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //            // ignore null & empty string properties
            //            if (prop == null) return false;
            //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            // ignore null role
            //            if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
