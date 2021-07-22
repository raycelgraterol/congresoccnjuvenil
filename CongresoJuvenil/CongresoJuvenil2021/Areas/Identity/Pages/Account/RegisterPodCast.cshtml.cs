using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongresoJuvenil2021.Data;
using CongresoJuvenil2021.Models;
using CongresoJuvenil2021.Services;
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

        private readonly IEmailService _emailService;

        public RegisterPodCastModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ApplicationDbContext context,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailService = emailService;

        }

        public PodCast[] PodCasts { get; set; }

        [BindProperty]
        public AppUser CurrentUser { get; set; }

        [BindProperty]
        public List<int> PodCastsChecked { get; set; }

        public class PodCast
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        [BindProperty]
        public Team MyTeam { get; set; }

        public string returnUrl { get; set; }

        public async Task OnGetAsync()
        {
            returnUrl = Url.Content("~/Identity/Account/Register");

            if (User != null && !string.IsNullOrEmpty(User.Identity.Name))
            {
                CurrentUser = (await _userManager.FindByEmailAsync(User.Identity.Name));
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

            if (User != null && !string.IsNullOrEmpty(User.Identity.Name))
            {
                CurrentUser = (await _userManager.FindByEmailAsync(User.Identity.Name));
            }

            if (CurrentUser != null)
            {
                MyTeam = _context.Teams.FirstOrDefault(x => x.Id == CurrentUser.TeamId);

                foreach (var PodCastId in PodCastsChecked)
                {
                    await _context.PodCastUsers.AddAsync(new PodCastUser()
                    {
                        AppUserId = CurrentUser.Id,
                        PodCastId = PodCastId
                    });
                    _context.SaveChanges();
                }

                var stringHTML = string.Format(
                    @"
                    <div style='text-align: center; padding:5px; margin-bottom:10px'>
                        <img width='900px' height='auto' src='https://congresoccnjuvenil.com/img/banner-correo.png' alt='Alternate Text' />
                        <h1>Nivel 1 - Operaci�n MOXA</h1>
                    </div>
                    <div style='text-align: center; padding:5px;'>                        
                        <h2>�Bienvenidos a la primera fase del congreso: operaci�n MOXA!</h2>
                        <p style='font-size: 16px;'>Has sido seleccionado para formar parte del equipo {0}.</p>
                        <br />
                        <p style='font-size: 16px;'>Este congreso consta de 3 niveles, el cual, ya estamos listos para que inicies esta aventura que tenemos preparada para el congreso.<p>
                        <br />
                        <p style='font-size: 16px;'>Aqu� te dejamos el enlace de tu equipo</p>
                        <a href='{1}' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;'>
                        Grupo de Telegram</a>
                        <br />
                    </div>
                    ", MyTeam.Id, MyTeam.Link);

                _emailService.Send(CurrentUser.Email, "Bienvenido al congreso juvenil operaci�n MOXA", stringHTML);

                return LocalRedirect(returnUrl);
            }            

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
