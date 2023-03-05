using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ValorantMoments.Database;
using ValorantMoments.Models;

namespace ValorantMoments.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IList<Moment> Moment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Moments != null)
            {
                Moment = await _context.Moments.ToListAsync();
            }
        }
    }
}