using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.ViewModels
{
    public class TeamCongregation
    {
        public int TeamId { get; set; }
        [Display(Name = "Equipo")]
        public string TeamName { get; set; }
        [Display(Name = "Cantidad")]
        public int TotalUser { get; set; }
    }
}
