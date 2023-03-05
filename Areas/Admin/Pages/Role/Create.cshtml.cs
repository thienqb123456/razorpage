using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace ValorantMoments.Areas.Admin.Pages.Role
{
    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public class InputModel
        {
            
            [Display(Name= "Role Name")]
            public string Name { get; set; }
        }
        [BindProperty]        
        public InputModel Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var role = new IdentityRole(Input.Name);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToPage("./Index");
            } else
            {
                result.Errors.ToList().ForEach(error => 
                {ModelState.AddModelError(string.Empty, error.Description);
                });
            }

            return Page();
        }
    }
}
