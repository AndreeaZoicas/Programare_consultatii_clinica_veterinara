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
    public class DeleteModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public DeleteModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proprietar Proprietar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietar = await _context.Proprietar.FirstOrDefaultAsync(m => m.ProprietarID == id);

            if (proprietar == null)
            {
                return NotFound();
            }
            else
            {
                Proprietar = proprietar;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietar = await _context.Proprietar.FindAsync(id);
            if (proprietar != null)
            {
                Proprietar = proprietar;
                _context.Proprietar.Remove(Proprietar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
