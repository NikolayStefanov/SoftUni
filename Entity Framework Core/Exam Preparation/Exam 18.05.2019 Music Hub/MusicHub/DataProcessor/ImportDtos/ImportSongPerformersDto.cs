using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongPerformersDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(18, 70)]
        public int Age { get; set; }

        [Required, Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public SongDto[] Songs { get; set; }
    }

    [XmlType("Song")]
    public class SongDto
    {
        [XmlAttribute("id")]
        public int SongId { get; set; }
    }
}

