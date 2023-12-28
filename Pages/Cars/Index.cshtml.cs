using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Data;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext _context;

        public IndexModel(Proiect_Stoica_Ramona.Data.Proiect_Stoica_RamonaContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Model { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CarModel { get; set; }

        public List<EngineType> EngineTypes { get; set; } = new List<EngineType>();

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await _context.Car
                    .Include(b => b.Location)
                    .Include(b=> b.EngineTypes)
                    .ToListAsync();
            }

            // Use LINQ to get list of genres.
            IQueryable<string> modelQuery = from c in _context.Car
                                            orderby c.Model
                                            select c.Model;
            var cars = from c in _context.Car
                       select c;
            if (!string.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(CarModel))
            {
                cars = cars.Where(x => x.Model == CarModel);
            }
            Model = new SelectList(await modelQuery.Distinct().ToListAsync());
            Car = await cars.ToListAsync();
            EngineTypes = await _context.EngineType.ToListAsync();
        }
    }
    
}

