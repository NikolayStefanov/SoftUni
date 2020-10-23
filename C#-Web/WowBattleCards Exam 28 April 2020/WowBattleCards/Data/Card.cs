using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WowBattleCards.Data
{
    public class Card
    {
        public Card()
        {
            this.UserCards = new HashSet<UserCard>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        public int Attack { get; set; }

        [Required]
        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<UserCard> UserCards { get; set; }
    }
}
