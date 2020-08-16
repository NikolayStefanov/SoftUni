using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required, RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$"), XmlElement("Key")]
        public string ProductKey { get; set; }

        [Required]
        public string Date { get; set; }

        [Required, RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$"), XmlElement("Card")]
        public virtual string Card { get; set; }
    }
}
