using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenilMVC.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return (FirstName == null ? "" : FirstName) + " " + (LastName == null ? "" : LastName);
            }
        }

        [NotMapped]
        public string keyAccess { get; set; }


    }
}
