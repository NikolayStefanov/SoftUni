using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WowBattleCards.Data
{
    public class User
    {
        public User()
        {
            this.UserCards = new HashSet<UserCard>();
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public ICollection<UserCard> UserCards{ get; set; }
    }
}
