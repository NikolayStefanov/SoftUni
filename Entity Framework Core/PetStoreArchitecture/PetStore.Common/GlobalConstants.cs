using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Common
{
    public static class GlobalConstants
    {
        //CLIENT
        public const int ClientPasswordMinLength = 5;
        public const int ClientPasswordMaxLength = 20;
        public const int ClientUsernameMinLength = 6;

        //ORDER
        public const int OrderTownNameMaxLength = 30;
        public const int OrderAddressMaxLength = 100;

        //PET
        public const int PetNameMinLength = 3;
        public const int MinimumPetAge = 0;
        public const int MaximumPetAge = 200;

        //BREED
        public const int BreedNameMinLength = 3;
        public const int BreedNameMaxLength = 30;
    }
}
