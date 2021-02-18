using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Restanta_Saniuta_Robert.Models
{
    public class Production
    {
        public int ID { get; set; }
        public string ProductionName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
