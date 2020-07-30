using PetStore.Common;
using PetStore.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetStore.ServiceModels.Products.InputModels
{
    public class EditProductInputServiceModel
    {
        [Required, MinLength(GlobalConstants.ProductNameMinLength), MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }
        [Required, Range(GlobalConstants.ProductMinprice, Double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
