using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.ViewModels.Product;
using PetStore.ViewModels.Product.InputModels;
using PetStore.ViewModels.Product.OutputModels;
using System;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Product
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x=> x.Type, y=> y.MapFrom(x=> (ProductType)x.Type));

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();

            this.CreateMap<Product, ListAllProductsServiceModels>()
                .ForMember(x=> x.ProductId, y=> y.MapFrom(x=> x.Id))
                .ForMember(x=> x.ProductType, y=> y.MapFrom(x=> x.Type.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.Type, y => y.MapFrom(x => x.Type.ToString()));

            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x=> x.Type, y=> y.MapFrom(x=> Enum.Parse(typeof(ProductType), x.Type)));

            this.CreateMap<ListAllProductsServiceModels, ListAllProductsViewModel>();

            this.CreateMap<CreateProductInputModel, AddProductInputServiceModel>();

            this.CreateMap<Product, ProductDetailsServiceModel>()
                .ForMember(x => x.Type, y => y.MapFrom(x => x.Type.ToString()));

            this.CreateMap<ProductDetailsServiceModel, ProductDetailsViewModel>();
        }

    }
}
