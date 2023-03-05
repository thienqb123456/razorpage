using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ValorantMoments.Database;
using ValorantMoments.Models;

namespace ValorantMoments.Pages.Moments2
{
    public class EditModel : PageModel
    {
        private readonly ValorantMoments.Database.AppDbContext _context;

        public EditModel(ValorantMoments.Database.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Moment Moment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Moments == null)
            {
                return NotFound();
            }

            var moment =  await _context.Moments.FirstOrDefaultAsync(m => m.Id == id);
            if (moment == null)
            {
                return NotFound();
            }
            Moment = moment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Moment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MomentExists(Moment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MomentExists(int id)
        {
          return _context.Moments.Any(e => e.Id == id);
        }
    }
}
