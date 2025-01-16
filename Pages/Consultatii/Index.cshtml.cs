using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_consultatii_clinica_veterinara.Data;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Pages.Consultatii
{
    public class IndexModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public IndexModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        public IList<Consultatie> Consultatie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Consultatie = await _context.Consultatie
                .Include(c => c.Medic)
                .Include(c => c.Pacient)
                .ToListAsync();
        }
    }
}
