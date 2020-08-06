using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required, Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required, ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        [Required, ForeignKey(nameof(Projection))]
        public int ProjectionId { get; set; }
        public virtual Projection Projection { get; set; }

    }
}
