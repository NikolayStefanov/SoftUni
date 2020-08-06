using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class CustomerTicketsDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(12, 110)]
        public int Age { get; set; }

        [Required, Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public virtual TicketDto[] Tickets { get; set; }
    }
    [XmlType("Ticket")]
    public class TicketDto
    {
        [Required]
        public int ProjectionId { get; set; }

        [Required, Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
