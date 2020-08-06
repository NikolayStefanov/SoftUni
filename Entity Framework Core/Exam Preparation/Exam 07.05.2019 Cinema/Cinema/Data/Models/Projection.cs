using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Projection
    {
        public Projection()
        {
            this.Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Required, ForeignKey(nameof(Hall))]
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
