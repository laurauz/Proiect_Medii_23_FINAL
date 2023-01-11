using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.EchipamenteSki
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public DeleteModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

        [BindProperty]
      public EchipamentSki EchipamentSki { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EchipamentSki == null)
            {
                return NotFound();
            }

            var echipamentski = await _context.EchipamentSki.FirstOrDefaultAsync(m => m.ID == id);

            if (echipamentski == null)
            {
                return NotFound();
            }
            else 
            {
                EchipamentSki = echipamentski;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EchipamentSki == null)
            {
                return NotFound();
            }
            var echipamentski = await _context.EchipamentSki.FindAsync(id);

            if (echipamentski != null)
            {
                EchipamentSki = echipamentski;
                _context.EchipamentSki.Remove(EchipamentSki);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
