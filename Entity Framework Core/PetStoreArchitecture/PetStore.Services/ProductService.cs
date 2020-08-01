using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;
        public ProductService(PetStoreDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.invalidProductType);
            }
            
        }
        public List<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type)
        {
            ProductType productType;
            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.invalidProductType);
            }

            var productsServiceModels = this.dbContext.Products
                .Where(x => x.Type == productType)
                .ProjectTo<ListAllProductsByProductTypeServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public List<ListAllProductsServiceModels> GetAll()
        {
            var products = this.dbContext.Products
                .ProjectTo<ListAllProductsServiceModels>(this.mapper.ConfigurationProvider)
                .ToList();

            return products;
        }

        public bool RemoveById(string id)
        {
            var productToRemove = this.dbContext
                .Products
                .FirstOrDefault(x => x.Id == id);
            if (productToRemove == null)
            {
                throw new ArgumentNullException(ExceptionMessages.invalidId);
            }
            this.dbContext.Products.Remove(productToRemove);
            var affectedRows = this.dbContext.SaveChanges();

            var wasDeleted = affectedRows == 1;

            return wasDeleted;
                
        }

        public bool RemoveByName(string name)
        {
            var productToRemove = this.dbContext
                .Products
                .FirstOrDefault(x => x.Name == name);
            if (productToRemove == null)
            {
                throw new ArgumentNullException(ExceptionMessages.invalidName);
            }
            this.dbContext.Products.Remove(productToRemove);
            var affectedRows = this.dbContext.SaveChanges();

            var wasDeleted = affectedRows == 1;
            return wasDeleted;
        }

        public List<ListAllProductsByNameServiceModel> ListAllByName(string name, bool caseSensetive)
        {
            List<ListAllProductsByNameServiceModel> productServiceModel;
            if (caseSensetive)
            {
                productServiceModel = this.dbContext
                .Products
                .Where(x => x.Name == name)
                .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
            }
            else
            {
                productServiceModel = this.dbContext
                .Products
                .Where(x => x.Name.ToLower() == name.ToLower())
                .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
            }
            
            return productServiceModel;
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                var product = this.mapper.Map<Product>(model);

                var targetProduct = dbContext.Products
                    .FirstOrDefault(x => x.Id == id);

                if (product == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.invalidId);
                }

                targetProduct = product;
                this.dbContext.SaveChanges();
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.invalidProductType);
            }
        }

        public ProductDetailsServiceModel GetById(string id)
        {
            Product product = this.dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new ArgumentNullException(ExceptionMessages.invalidId);
            }

            ProductDetailsServiceModel serviceModel = this.mapper.Map<ProductDetailsServiceModel>(product);

            return serviceModel;
        }
    }
}
