using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CongresoJuvenil2021.Areas.Identity.Pages.Account
{
    public class RegisterPodCastModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public RegisterPodCastModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }

        public PodCast[] PodCasts { get; set; }

        [BindProperty]
        public string CurrentUserId { get; set; } = "";

        [BindProperty]
        public List<int> PodCastsChecked { get; set; }

        public class PodCast
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        public string returnUrl { get; set; }

        public async Task OnGetAsync()
        {
            returnUrl = Url.Content("~/Identity/Account/Register");

            if (User != null && !string.IsNullOrEmpty(User.Identity.Name))
            {
                CurrentUserId = (await _userManager.FindByEmailAsync(User.Identity.Name)).Id;
            }
            else
            {
                LocalRedirect(returnUrl);
            }
            

            PodCasts = await _context.PodCasts
                                .Select(x =>
                                    new PodCast()
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Selected = false
                                    }
                                ).ToArrayAsync();

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = "~/Identity/Account/ResultPageInfo")
        {
            returnUrl = Url.Content("~/Identity/Account/ResultPageInfo");

            if (!string.IsNullOrEmpty(CurrentUserId))
            {
                foreach (var PodCastId in PodCastsChecked)
                {
                    //await _context.PodCastUsers.AddAsync(new PodCastUser()
                    //{
                    //    AppUserId = CurrentUserId,
                    //    PodCastId = PodCastId
                    //});
                    //_context.SaveChanges();
                }

                return LocalRedirect(returnUrl);
            }            

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
