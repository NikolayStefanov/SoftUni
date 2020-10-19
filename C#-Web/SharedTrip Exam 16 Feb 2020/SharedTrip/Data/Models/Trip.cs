using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class Trip
    {
        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserTrips = new HashSet<UserTrip>();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "dd.MM.yyyy HH:mm")]
        public DateTime DepartureTime { get; set; }

        [Required]
        [MaxLength(6)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }

    }
}
