using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.ViewModels
{
    public class UserCongregation
    {
        public int CongregationId { get; set; }
        [Display(Name = "Congregacion")]
        public string CongregationName { get; set; }
        [Display(Name = "Total")]
        public int TotalUser { get; set; }
    }
}
