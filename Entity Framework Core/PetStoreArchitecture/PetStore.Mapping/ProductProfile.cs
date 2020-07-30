using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using System;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Product
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x=> x.Type, y=> y.MapFrom(x=> Enum.Parse(typeof(ProductType), x.Type)));
            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();
            this.CreateMap<Product, ListAllProductsServiceModels>()
                .ForMember(x=> x.ProductType, y=> y.MapFrom(x=> x.Type.ToString()));
            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.Type, y => y.MapFrom(x => x.Type.ToString()));
            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x=> x.Type, y=> y.MapFrom(x=> Enum.Parse(typeof(ProductType), x.Type)));
        }

    }
}
