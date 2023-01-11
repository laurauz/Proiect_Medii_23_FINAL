using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Pages.SizesDetails
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Medii_23.Data.Proiect_Medii_23Context _context;

        public DetailsModel(Proiect_Medii_23.Data.Proiect_Medii_23Context context)
        {
            _context = context;
        }

      public SizeDetails SizeDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SizeDetails == null)
            {
                return NotFound();
            }

            var sizedetails = await _context.SizeDetails.FirstOrDefaultAsync(m => m.ID == id);
            if (sizedetails == null)
            {
                return NotFound();
            }
            else 
            {
                SizeDetails = sizedetails;
            }
            return Page();
        }
    }
}
