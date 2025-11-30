using AutoMapper;
using Ecommerce.Core.Dto;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, AuthenticationResponse>()
                .ForMember(des => des.UserId, op => op.MapFrom(src => src.UserId))
                .ForMember(des => des.Token, op => op.Ignore())
                .ForMember(des => des.sucess, op => op.Ignore()).ReverseMap();
        }
    }
}
