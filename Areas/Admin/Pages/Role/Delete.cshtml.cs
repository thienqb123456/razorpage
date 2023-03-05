using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ValorantMoments.Areas.Admin.Pages.Role
{
    public class DeleteModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IdentityRole Role { get; set; }
        
        public void OnGet()
        {
        }

        

        public async Task<IActionResult> OnPostAsync(string roleid)
        {

            Role = await _roleManager.FindByIdAsync(roleid);

            IdentityResult result = await _roleManager.DeleteAsync(Role);
            if (result.Succeeded)
            {
                return RedirectToPage("Index");
            } else
            {
                result.Errors.ToList().ForEach(error => { ModelState.AddModelError(String.Empty, error.Description); });
            }

            return Page();
        }
    }
}
