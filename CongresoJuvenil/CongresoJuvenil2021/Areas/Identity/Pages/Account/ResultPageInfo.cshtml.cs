using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CongresoJuvenil2021.Areas.Identity.Pages.Account
{
    public class ResultPageInfoModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ResultPageInfoModel(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public AppUser CurrentUser { get; set; }

        [BindProperty]
        public Team MyTeam { get; set; }

        public async Task OnGet()
        {
            if (User != null)
            {
                CurrentUser = await _userManager.GetUserAsync(User);

                MyTeam = _context.Teams.FirstOrDefault(x => x.Id == CurrentUser.TeamId);
            }
            else
            {
                MyTeam = new Team()
                {
                    Id = 0,
                    Name = "N/A",
                    Link = "N/A"
                };
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = "/")
        {


            return LocalRedirect(returnUrl);

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
