using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        [Required]
        [ForeignKey(nameof(Trip))]
        public string TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
