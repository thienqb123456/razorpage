using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValorantMoments.Database;
using ValorantMoments.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ValorantMoments.Pages.Moments2
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ValorantMoments.Database.AppDbContext _context;

        public IndexModel(ValorantMoments.Database.AppDbContext context)
        {
            _context = context;
        }

        public IList<Moment> Moment { get;set; } = default!;

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            if (_context != null)
            {
             //   Moment = await _context.Moments.ToListAsync();
                
                var query = from mm in _context.Moments
                            orderby mm.TimeCreated descending
                            select mm;
                Moment = await query.ToListAsync();

                if (!string.IsNullOrEmpty(searchString))
                {
         
                    Moment = query.Where(mm => mm.Name.Contains(searchString)).ToList();
                    //Moment = query.Where(mm => mm.Description.Contains(searchString)).ToList();
                }
                else
                {
                    Moment = await query.ToListAsync();
                }
            }
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Moment != null)
            {
                await _context.SaveChangesAsync();

            }
            return RedirectToPage("./Index");

        }
    }
}
