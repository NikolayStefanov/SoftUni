using PetStore.Common;
using PetStore.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [Required,MinLength(GlobalConstants.PetNameMinLength)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required, MinLength(GlobalConstants.MinimumPetAge), MaxLength(GlobalConstants.MaximumPetAge)]
        public byte Age { get; set; }

        [Required]
        public bool IsSold { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required, ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public virtual Client Owner { get; set; }
    }
}
