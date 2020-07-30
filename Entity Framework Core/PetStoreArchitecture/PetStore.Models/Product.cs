using PetStore.Common;
using PetStore.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Product
    {

        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required, MinLength(GlobalConstants.ProductNameMinLength), MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }
        [Required, Range(GlobalConstants.ProductMinprice, Double.MaxValue)]
        public decimal  Price { get; set; }
        [Required]
        public ProductType Type { get; set; }
    }
}
