using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ValorantMoments.Models
{
    public class Moment
    {
        public int Id { get; set; }
        [StringLength(255, MinimumLength = 4, ErrorMessage = "{0} phai dai tu {2} -> {1} ki tu ")]
        [Required(ErrorMessage = " {0} khong dc de trong")]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "TimeCreated")]        
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        

        public string MomentLink { get; set; }
        
    }
}
