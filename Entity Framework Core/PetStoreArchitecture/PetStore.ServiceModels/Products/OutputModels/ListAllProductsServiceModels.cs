using PetStore.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.ServiceModels.Products.OutputModels
{
    public class ListAllProductsServiceModels
    {
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
    }
}
