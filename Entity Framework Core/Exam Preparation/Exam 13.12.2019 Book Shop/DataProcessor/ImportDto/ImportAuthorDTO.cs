using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDTO
    {

        [Required, MinLength(3), MaxLength(30)]

        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public List<ImportAuthorBookDTO> Books { get; set; }
    }
}
