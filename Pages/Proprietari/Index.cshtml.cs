using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_consultatii_clinica_veterinara.Data;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Pages.Proprietari
{
    public class IndexModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public IndexModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        public IList<Proprietar> Proprietar { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Proprietar = await _context.Proprietar.ToListAsync();
        }
    }
}
