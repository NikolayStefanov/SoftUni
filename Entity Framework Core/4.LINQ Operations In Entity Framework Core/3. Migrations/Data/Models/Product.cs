using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desctiption { get; set; } 

        [Required]
        public float Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
