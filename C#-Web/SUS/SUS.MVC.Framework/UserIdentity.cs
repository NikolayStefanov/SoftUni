using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SUS.MVC.Framework
{
    public class UserIdentity
    {
        public string Id { get; set; }

        [MinLength(5), MaxLength(20), Required]
        public string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
