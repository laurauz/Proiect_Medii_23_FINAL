using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public CreateModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var echipamentSkiList = _context.EchipamentSki
                 .Include(b => b.SizeDetails)
                 .Select(x => new
                 {
                     x.ID,
                     EchipamentSkiFullName = x.Title + " - " + x.SizeDetails.Sex + " " +
                     x.SizeDetails.Size
                 });


            ViewData["EchipamentSkiID"] = new SelectList(echipamentSkiList, "ID", "EchipamentSkiFullName");
            ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "FullName");
            return Page();
        }

        //        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID");
        //      ViewData["EchipamentSkiID"] = new SelectList(_context.EchipamentSki, "ID", "ID");
        //        return Page();
        //  }

        [BindProperty]
        public Order Order { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
