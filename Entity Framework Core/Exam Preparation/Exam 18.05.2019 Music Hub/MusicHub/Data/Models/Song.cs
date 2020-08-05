using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [ForeignKey("Album")]
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [Required,ForeignKey("Writer")]
        public int WriterId { get; set; }
        [Required]
        public virtual Writer Writer { get; set; }

        [Required, Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        public virtual ICollection<SongPerformer> SongPerformers  { get; set; }
    }
}
