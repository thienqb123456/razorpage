using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValorantMoments.Database;
using ValorantMoments.Models;

namespace ValorantMoments.Pages.Moments2
{
    public class DetailsModel : PageModel
    {
        private readonly ValorantMoments.Database.AppDbContext _context;

        public DetailsModel(ValorantMoments.Database.AppDbContext context)
        {
            _context = context;
        }

      public Moment Moment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Moments == null)
            {
                return NotFound();
            }

            var moment = await _context.Moments.FirstOrDefaultAsync(m => m.Id == id);
            if (moment == null)
            {
                return NotFound();
            }
            else 
            {
                Moment = moment;
            }
            return Page();
        }
    }
}
