using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            this.BoughtPets = new HashSet<Pet>();
            this.BoughtProducts = new HashSet<ClientProduct>();
            this.Id = Guid.NewGuid().ToString();
        }
        
        [Key]
        public string Id { get; set; }

        [Required, MinLength(GlobalConstants.ClientUsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, MinLength(GlobalConstants.ClientPasswordMinLength), MaxLength(GlobalConstants.ClientPasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        public virtual ICollection<Pet> BoughtPets { get; set; }
        public ICollection<ClientProduct> BoughtProducts { get; set; }
    }
}
