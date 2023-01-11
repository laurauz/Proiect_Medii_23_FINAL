using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Data
{
    public class Proiect_Medii_23Context : DbContext
    {
        public Proiect_Medii_23Context (DbContextOptions<Proiect_Medii_23Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Medii_23.Models.EchipamentSki> EchipamentSki { get; set; } = default!;

        public DbSet<Proiect_Medii_23.Models.Brand> Brand { get; set; }

        public DbSet<Proiect_Medii_23.Models.SizeDetails> SizeDetails { get; set; }

        public DbSet<Proiect_Medii_23.Models.Category> Category { get; set; }
    }
}
