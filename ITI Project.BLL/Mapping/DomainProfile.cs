﻿using AutoMapper;
using ITI_Project.BLL.ModelVM;
using ITI_Project.DAL.Entites;

namespace ITI_Project.BLL.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            
            CreateMap<CreateVendorVM, Vendor>();
            CreateMap<UpdateVendorVM, Vendor>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
