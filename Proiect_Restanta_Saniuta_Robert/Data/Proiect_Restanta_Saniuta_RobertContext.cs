using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Saniuta_Robert.Models;

namespace Proiect_Restanta_Saniuta_Robert.Data
{
    public class Proiect_Restanta_Saniuta_RobertContext : DbContext
    {
        public Proiect_Restanta_Saniuta_RobertContext (DbContextOptions<Proiect_Restanta_Saniuta_RobertContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Restanta_Saniuta_Robert.Models.Movie> Movie { get; set; }

        public DbSet<Proiect_Restanta_Saniuta_Robert.Models.Production> Production { get; set; }

        public DbSet<Proiect_Restanta_Saniuta_Robert.Models.Category> Category { get; set; }
    }
}
