using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor.ImportDto
{
    public class MovieDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required, Range(1.0, 10.0)]
        public double Rating { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Director { get; set; }
    }
}
