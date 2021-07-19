using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongresoJuvenil2021.Models
{
    public class PodCastUser
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int PodCastId { get; set; }
        public PodCast PodCast { get; set; }

    }
}
