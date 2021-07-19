using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.Models
{
    public class PodCast
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Link { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime TransmissionDate { get; set; }

        public List<PodCastUser> Users { get; set; }

    }
}
