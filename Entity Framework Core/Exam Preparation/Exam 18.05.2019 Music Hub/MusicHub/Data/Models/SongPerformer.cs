using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [Required]
        public int SongId { get; set; }
        [Required]
        public virtual Song Song { get; set; }

        [Required]
        public int PerformerId { get; set; }
        [Required]
        public virtual Performer Performer { get; set; }
    }
}
