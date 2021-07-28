using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.ViewModels
{
    public class UsersPodCast
    {
        public int PodCastId { get; set; }
        [Display(Name = "PodCast")]
        public string PodCastName { get; set; }
        [Display(Name = "Cantidad")]
        public int TotalUser { get; set; }
    }
}
