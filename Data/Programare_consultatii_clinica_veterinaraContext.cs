using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Data
{
    public class Programare_consultatii_clinica_veterinaraContext : DbContext
    {
        public Programare_consultatii_clinica_veterinaraContext (DbContextOptions<Programare_consultatii_clinica_veterinaraContext> options)
            : base(options)
        {
        }

        public DbSet<Programare_consultatii_clinica_veterinara.Models.Pacient> Pacient { get; set; } = default!;
        public DbSet<Programare_consultatii_clinica_veterinara.Models.Proprietar> Proprietar { get; set; } = default!;
        public DbSet<Programare_consultatii_clinica_veterinara.Models.Consultatie> Consultatie { get; set; } = default!;
        public DbSet<Programare_consultatii_clinica_veterinara.Models.Medic> Medic { get; set; } = default!;
        public DbSet<Programare_consultatii_clinica_veterinara.Models.Recenzie> Recenzie { get; set; } = default!;
    }
}
