using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenilMVC.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}
