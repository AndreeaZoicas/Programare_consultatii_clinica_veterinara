using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_consultatii_clinica_veterinara.Data;
using Programare_consultatii_clinica_veterinara.Models;

namespace Programare_consultatii_clinica_veterinara.Pages.Consultatii
{
    public class CreateModel : PageModel
    {
        private readonly Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext _context;

        public CreateModel(Programare_consultatii_clinica_veterinara.Data.Programare_consultatii_clinica_veterinaraContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MedicID"] = new SelectList(_context.Set<Medic>(), "MedicID", "Nume");
        ViewData["PacientID"] = new SelectList(_context.Pacient, "PacientID", "Nume");
            return Page();
        }

        [BindProperty]
        public Consultatie Consultatie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Consultatie.Add(Consultatie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
