using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using System.Collections.Generic;

namespace PetStore.Services.Interfaces
{
    public interface IProductService 
    {
        void AddProduct(AddProductInputServiceModel model);
        ProductDetailsServiceModel GetById(string id);
        List<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type);
        List<ListAllProductsServiceModels> GetAll();
        List<ListAllProductsByNameServiceModel> ListAllByName(string name, bool caseSensetive);
        bool RemoveById(string id);
        bool RemoveByName(string name);
        void EditProduct(string id, EditProductInputServiceModel model);

    }
}
