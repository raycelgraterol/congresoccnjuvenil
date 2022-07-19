using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.Models
{
    public class AppUser: IdentityUser<long>
    {
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Correo")]
        public override string Email { get; set; }

        [Display(Name = "Numero de Telefono")]
        public override string PhoneNumber { get; set; }
        

        [Display(Name = "Edad")]
        [Range(1, 120)]
        public int Age { get; set; }

        [Display(Name = "Instagram")]
        [StringLength(255)]
        public string Instagram { get; set; }
        [Display(Name = "Facebook")]
        [StringLength(255)]
        public string Facebook { get; set; }
        [Display(Name = "Tik Tok")]
        [StringLength(255)]
        public string TikTok { get; set; }
        [Display(Name = "Twitter")]
        [StringLength(255)]
        public string Twitter { get; set; }

        [Required]
        public bool NeedContact { get; set; }

        public int CongregationId { get; set; }
        public Congregation Congregation { get; set; }

        [Display(Name = "Equipo")]
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public bool IsNewConverted { get; set; }

        public string CommentMOXA2022 { get; set; }

        [Display(Name = "Nombre Completo")]
        [NotMapped]
        public string FullName
        {
            get
            {
                return (FirstName == null ? "" : FirstName) + " " + (LastName == null ? "" : LastName);
            }
        }

        [Display(Name = "Congregación")]
        [NotMapped]
        public string CongregationName
        {
            get
            {
                return Congregation == null ? "" : Congregation.Name;
            }
        }

        [Display(Name = "Equipo")]
        [NotMapped]
        public string TeamName
        {
            get
            {
                return Team == null ? "" : Team.Name;
            }
        }

        public List<PodCastUser> PodCasts { get; set; }
    }
}
