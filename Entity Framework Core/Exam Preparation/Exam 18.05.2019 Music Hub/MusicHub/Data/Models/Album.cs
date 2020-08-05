using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate  { get; set; }

        [Required]
        public decimal Price => this.Songs.Sum(x => x.Price);

        [ForeignKey("Producer")]
        public int? ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
