using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        [Key]
        public int CountryId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
