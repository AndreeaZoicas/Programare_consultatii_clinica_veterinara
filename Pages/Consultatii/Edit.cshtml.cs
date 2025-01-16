using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_consultatii_clinica_veterinara.Data;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Pages.Consultatii
{
    public class EditModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public EditModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultatie Consultatie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultatie =  await _context.Consultatie.FirstOrDefaultAsync(m => m.ConsultatieID == id);
            if (consultatie == null)
            {
                return NotFound();
            }
            Consultatie = consultatie;
           ViewData["MedicID"] = new SelectList(_context.Set<Medic>(), "MedicID", "MedicID");
           ViewData["PacientID"] = new SelectList(_context.Pacient, "PacientID", "PacientID");
            return Page();
        }
.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consultatie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultatieExists(Consultatie.ConsultatieID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConsultatieExists(int id)
        {
            return _context.Consultatie.Any(e => e.ConsultatieID == id);
        }
    }
}
