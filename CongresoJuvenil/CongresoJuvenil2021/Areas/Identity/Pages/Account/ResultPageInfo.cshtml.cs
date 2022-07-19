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

namespace CongresoJuvenil2021.Areas.Identity.Pages.Account
{
    public class ResultPageInfoModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public ResultPageInfoModel(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailService emailService,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailService = emailService;
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


            var stringHTML = string.Format(
                    @"
                    <div style='text-align: center; padding:5px; margin-bottom:10px'>
                        <img width='900px' height='auto' src='https://www.congreso.ccnjuvenil.com/img/banner-correo.png' alt='Alternate Text' />
                    </div>
                    <div style='text-align: center; padding:5px;'>                        
                        <h2>¡Bienvenidos a la primera fase del congreso: operación MOXA!</h2>
                        <p style='font-size: 16px;'>Has sido seleccionado para formar parte del equipo {0}.</p>
                        <br />
                        <p style='font-size: 16px;'>Este congreso consta de 3 fases, el cual, ya estamos listos para que inicies esta experiencia que tenemos preparada para el congreso.<p>
                        <br />
                        <p style='font-size: 16px;'>Aquí te dejamos el enlace de tu equipo</p>
                        <a href='{1}' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        Grupo de Telegram</a>
                        <br />
                        <br />
                        <p style='font-size: 16px; margin-top: 30px;'>Para más información comunícate a través de nuestra cuenta de Instagram</p>
                        <a href='https://www.instagram.com/ccnjuvenil/' style='color: #fff;background-color: #17a2b8;border-color: #17a2b8;text-decoration: none;padding: 10px;border-radius: .25rem;margin-bottom:10px;'>
                        @ccnjuvenil</a>
                        <br />
                        <br />
                    </div>
                    ", MyTeam.Id, MyTeam.Link);

            await _emailService.Send(CurrentUser.Email, "¡Ya estás inscrito al Congreso Juvenil 2022! | MOXA - Sangre, Espíritu y Gracia", stringHTML);


        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = "/")
        {

            return LocalRedirect(returnUrl);

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
