using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersAndCardsDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required, RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, Range(3, 103)]
        public int Age { get; set; }
        public virtual CardDto[] Cards { get; set; }
    }
    public class CardDto
    {
        [Required, RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required, RegularExpression(@"^[0-9]{3}$"), JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }

    }
}
