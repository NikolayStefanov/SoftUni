using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetStore.ViewModels.Product.InputModels
{
    public class CreateProductInputModel
    {
        [Required, MinLength(GlobalConstants.ProductNameMinLength), MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }
        [Required, Range(GlobalConstants.ProductMinprice, Double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int Type { get; set; }
    }
}
