using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.EchipamenteSki
{
    [Authorize(Roles = "Admin")]
    public class EditModel : EchipamentSkiCategoriesPageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public EditModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

        [BindProperty]
        public EchipamentSki EchipamentSki { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EchipamentSki == null)
            {
                return NotFound();
            }

            EchipamentSki = await _context.EchipamentSki
 .Include(b => b.Brand)
 .Include(b => b.EchipamentSkiCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);
            if (EchipamentSki == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, EchipamentSki);
            
            EchipamentSki = EchipamentSki;

            ViewData["SizeDetailsID"] = new SelectList(_context.Set<SizeDetails>(), "ID", "SexAndSize");
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID",
"BrandName");
    //        ViewData["SizeDetailsID"] = new SelectList(_context.Set<SizeDetails>(), "ID",
    //"SexAndSize");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var echipamentSkiToUpdate = await _context.EchipamentSki
            .Include(i => i.Brand)
            .Include(i => i.EchipamentSkiCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (echipamentSkiToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<EchipamentSki>(
            echipamentSkiToUpdate,
            "EchipamentSki",
            i => i.Title, i => i.SizeDetails,
            i => i.Price, i => i.StocDate, i => i.Brand))
            {
                UpdateUpdateBookCategoriesCategories(_context, selectedCategories, echipamentSkiToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateUpdateBookCategoriesCategories(_context, selectedCategories, echipamentSkiToUpdate);
            PopulateAssignedCategoryData(_context, echipamentSkiToUpdate);
            return Page();
        }
    }
}
