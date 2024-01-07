using InvoiceApplication.Models.Companies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Areas.Identity.Pages.Account
{
    public class Manage : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public Manage(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty]
        public UpdateModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public async Task OnGet()
        {

            ReturnUrl = Url.Content("~/");
            var user = await _userManager.GetUserAsync(User);
            Input = new UpdateModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };

        }
        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.UserName = Input.Email;
                user.Email = Input.Email;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/");
                }
            }

            return Page();

        }
        public class UpdateModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            [MinLength(4)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [MinLength(4)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        }
    }
}
