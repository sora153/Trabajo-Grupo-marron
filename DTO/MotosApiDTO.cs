using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo.DTO
{
    public class MotosApiDTO
    {
        public int Year { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
         public string? Specs { get; set; }
    }

}