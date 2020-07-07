using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = "No description";

        [Required]
        public float Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
