using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.EngineTypes
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public DeleteModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EngineType EngineType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EngineType == null)
            {
                return NotFound();
            }

            var enginetype = await _context.EngineType.FirstOrDefaultAsync(m => m.Id == id);

            if (enginetype == null)
            {
                return NotFound();
            }
            else 
            {
                EngineType = enginetype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EngineType == null)
            {
                return NotFound();
            }
            var enginetype = await _context.EngineType.FindAsync(id);

            if (enginetype != null)
            {
                EngineType = enginetype;
                _context.EngineType.Remove(EngineType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
