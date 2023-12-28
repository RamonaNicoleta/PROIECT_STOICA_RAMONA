using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.Cars
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public CreateModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Car Car { get; set; } = default!;

        [BindProperty]
        public List<EngineType> EngineTypes { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "LocationName");

            // Fetch available EngineTypes from the database
            EngineTypes = await _context.EngineType.ToListAsync();

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Car == null || Car == null)
            {
                return Page();
            }

            // Find checked EngineTypes and associate them with the Car
            Car.EngineTypes = EngineTypes.Where(e => e.Assigned).ToList();


            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
