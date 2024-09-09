using AutoMapper;
using ITI_Project.BLL.ModelVM;
using ITI_Project.DAL.Entites;

namespace ITI_Project.BLL.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            CreateMap<CreateVendorVM, Vendor>();

            CreateMap <CreateProductVM, Product>();
            CreateMap<Product, CreateProductVM>();

            CreateMap<GetProductVM, Product>();
            CreateMap<Product, GetProductVM>();

            CreateMap<UpdateProductVM, Product>();
            CreateMap<Product, UpdateProductVM>();
        }
    }
}
