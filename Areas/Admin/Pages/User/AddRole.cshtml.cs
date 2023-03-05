using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ValorantMoments.Models;

namespace ValorantMoments.Areas.Admin.Pages.User
{
    public class AddRoleModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleModel(SignInManager<AppUser> signInManager, 
                            UserManager<AppUser> userManager,
                            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public AppUser User { get; set; }

        public SelectList AllRoles { get; set;}

        [BindProperty]
        [Display(Name = "User's Roles")]
        public string[] RolesName { get; set; } 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("not found user");
            }
            
            User = await _userManager.FindByIdAsync(id);

            if (User == null)
            {
                return NotFound($"Not found user,id = {id}");
            }

            RolesName = (await _userManager.GetRolesAsync(User)).ToArray<string>();

            List<string> rolesExist = await _roleManager.Roles.Select(r =>r.Name).ToListAsync();

            AllRoles = new SelectList(rolesExist);

            return Page();  
        }
    }
}
