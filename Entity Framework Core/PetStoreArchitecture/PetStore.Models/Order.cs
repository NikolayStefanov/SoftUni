using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderedProducts = new HashSet<ClientProduct>();
        }
        [Key]
        public string Id { get; set; }

        [Required, MaxLength(GlobalConstants.OrderTownNameMaxLength)]
        public string Town { get; set; }
        [Required, MaxLength(GlobalConstants.OrderAddressMaxLength)]
        public string Address { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<ClientProduct> OrderedProducts { get; set; }
        public decimal TotalPrice => this.OrderedProducts.Sum(x => x.Product.Price * x.Quantity);
    }
}
