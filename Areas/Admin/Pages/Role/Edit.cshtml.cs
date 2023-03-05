using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ValorantMoments.Migrations;

namespace ValorantMoments.Areas.Admin.Pages.Role
{
    public class EditModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public class InputModel
        {
            [Display(Name = "Role Name")]
            public string Name { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IdentityRole Role { get; set; }  
        public async Task<IActionResult> OnGetAsync(string roleid) 
        {
            if (roleid != null)
            {
                Role = await _roleManager.FindByIdAsync(roleid);
                if (Role != null)
                {
                    Input = new InputModel()
                    {
                        Name = Role.Name,
                    };
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid != null)
            {
                Role = await _roleManager.FindByIdAsync(roleid);
                if (Role != null)
                {
                    var newRole = new IdentityRole(Input.Name);
                    Role.Name = newRole.Name;
                    var result = await _roleManager.UpdateAsync(Role);
                    if (result.Succeeded)
                    {
                        return RedirectToPage("Index");
                    }
                }
            }
            return Page();
            
        }
    }
}
