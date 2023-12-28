using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.Locations
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public DeleteModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Location Location { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }

            var location = await _context.Location.FirstOrDefaultAsync(m => m.ID == id);

            if (location == null)
            {
                return NotFound();
            }
            else 
            {
                Location = location;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Location == null)
            {
                return NotFound();
            }
            var location = await _context.Location.FindAsync(id);

            if (location != null)
            {
                Location = location;
                _context.Location.Remove(Location);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
