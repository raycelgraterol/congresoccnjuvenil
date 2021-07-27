using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using CongresoJuvenil2021.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CongresoJuvenil2021.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CongresoJuvenil2021.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public RegisterModel(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole<long>> roleManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; } = "";

        public int RandomId { get; set; }

        public int minValue { 
            get 
            {
                return Convert.ToInt32(string.IsNullOrEmpty(_configuration["defaultValues:minValue"]) ? "1" : _configuration["defaultValues:minValue"]);
            } 
        }

        public int maxValue {
            get 
            {
                return Convert.ToInt32(string.IsNullOrEmpty(_configuration["defaultValues:maxValue"]) ? "5" : _configuration["defaultValues:maxValue"]);
            }
        }

        public IEnumerable<SelectListItem> Congregations { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El E-mail es necesario.")]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "El Nombre es necesario.")]
            [Display(Name = "Nombre")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "El Apellido es necesario.")]
            [Display(Name = "Apellido")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "El Telefono celular es necesario.")]
            [Display(Name = "Teléfono celular")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "La Edad es necesaria.")]
            [Display(Name = "Edad")]
            [Range(1, 120)]
            public int Age { get; set; }

            [Display(Name = "Sede CCN")]
            public int CongregationId { get; set; }

            [Required]
            [Display(Name = "Equipo")]
            public int TeamId { get; set; }

            [Display(Name = "Instagram")]
            [StringLength(255)]
            public string Instagram { get; set; }
            [Display(Name = "Facebook")]
            [StringLength(255)]
            public string Facebook { get; set; }
            [Display(Name = "Tik Tok")]
            [StringLength(255)]
            public string TikTok { get; set; }
            [Display(Name = "Twitter")]
            [StringLength(255)]
            public string Twitter { get; set; }

            [Display(Name = "En caso de no pertenecer a algún CCN")]
            public bool NeedContact { get; set; } = false;
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            Random rnd = new Random();
            RandomId = rnd.Next(minValue, maxValue);


            Congregations = await listItemsCongregation();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = "~/Identity/Account/RegisterPodCast")
        {
            ReturnUrl = returnUrl ?? Url.Content("~/Identity/Account/RegisterPodCast");

            Input.CongregationId = Input.CongregationId == 0 ? 107 : Input.CongregationId;

            var currentUser = await _userManager.FindByEmailAsync(Input.Email);

            if (currentUser == null)
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser
                    {
                        UserName = Input.Email,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        Email = Input.Email,
                        TeamId = Input.TeamId,
                        CongregationId = Input.CongregationId,
                        PhoneNumber = Input.PhoneNumber,
                        Age = Input.Age,
                        Instagram = Input.Instagram,
                        TikTok = Input.TikTok,
                        Twitter = Input.Twitter,
                        Facebook = Input.Facebook,
                        NeedContact = Input.NeedContact
                    };

                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("El usuario creó una nueva cuenta con contraseña.");

                        await _signInManager.SignInAsync(user, isPersistent: true);

                        //Add rol to user.
                        await _userManager.AddToRoleAsync(user, UserRoles.Competitor);

                        return LocalRedirect(returnUrl);

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        if (error.Description.Contains("already taken"))
                        {
                            ErrorMessage = string.Format("'{0}' ya existe como usuario intente otro diferente.", Input.Email);
                        }
                    }
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    currentUser.FirstName = Input.FirstName;
                    currentUser.LastName = Input.LastName;
                    currentUser.Age = Input.Age;
                    currentUser.PhoneNumber = Input.PhoneNumber;
                    currentUser.CongregationId = Input.CongregationId;
                    currentUser.Instagram = Input.Instagram;
                    currentUser.TikTok = Input.TikTok;
                    currentUser.Twitter = Input.Twitter;
                    currentUser.Facebook = Input.Facebook;
                    currentUser.NeedContact = Input.NeedContact;

                    var result = await _userManager.UpdateAsync(currentUser);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("El usuario creó una nueva cuenta con contraseña.");

                        await _signInManager.SignInAsync(currentUser, isPersistent: true);

                        if (!(await _userManager.IsInRoleAsync(currentUser, UserRoles.Competitor)))
                        {
                            //Add rol to user.
                            await _userManager.AddToRoleAsync(currentUser, UserRoles.Competitor);
                        }

                        return LocalRedirect(returnUrl);

                    }
                }
            }

            Congregations = await listItemsCongregation();
            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task<List<SelectListItem>> listItemsCongregation()
        {
            var items = await _context.Congregations
                                    .OrderBy(x => x.Name)
                                    .Select(x =>
                                        new SelectListItem
                                        {
                                            Value = x.Id.ToString(),
                                            Text = x.Name == "Ninguna" ? "No formo parte de ninguna congregación" 
                                                        : (x.Name == "Otra congregación" ? x.Name : "CCN " + x.Name.Trim())
                                        }
                                    )
                                    .ToListAsync();

            items.Insert(0, new SelectListItem() { Value = "0", Text = "Seleccione su congregación", Selected = true });

            return items;
        }
    }
}
