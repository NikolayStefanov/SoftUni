using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(18, 70)]
        public int Age { get; set; }
        
        [Required, Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }
        public virtual ICollection<SongPerformer> PerformerSongs  { get; set; }
    }
}
