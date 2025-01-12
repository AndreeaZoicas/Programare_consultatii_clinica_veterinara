using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_consultatii_clinica_veterinara.Data;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Pages.Recenzii
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public DetailsModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        public Recenzie Recenzie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recenzie = await _context.Recenzie.FirstOrDefaultAsync(m => m.RecenzieID == id);
            if (recenzie == null)
            {
                return NotFound();
            }
            else
            {
                Recenzie = recenzie;
            }
            return Page();
        }
    }
}
