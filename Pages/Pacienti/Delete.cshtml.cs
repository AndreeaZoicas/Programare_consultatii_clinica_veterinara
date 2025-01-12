using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_consultatii_clinica_veterinara.Data;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Pages.Pacienti
{
    public class DeleteModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public DeleteModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FirstOrDefaultAsync(m => m.PacientID == id);

            if (pacient == null)
            {
                return NotFound();
            }
            else
            {
                Pacient = pacient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FindAsync(id);
            if (pacient != null)
            {
                Pacient = pacient;
                _context.Pacient.Remove(Pacient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
