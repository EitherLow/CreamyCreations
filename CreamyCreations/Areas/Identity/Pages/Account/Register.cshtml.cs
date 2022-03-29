using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CreamyCreations.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CreamyCreations.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace CreamyCreations.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager; // handling user roles during the registration

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager, // added for roles
            IEmailSender emailSender,
            ApplicationDbContext context
        )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager; // added for roles
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var url = Request.GetEncodedUrl();
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                if (url.Contains("localhost"))
                {
                    user.EmailConfirmed = true;
                }

                // Check if the roles already exists
                string roleUser = "User";
                string roleAdmin = "Admin";
                bool defaultRoleUser = await _roleManager.RoleExistsAsync(roleUser);
                bool defaultRoleAdmin = await _roleManager.RoleExistsAsync(roleAdmin);

                // If the default role User doesn't exist, create a new one
                if (!defaultRoleUser)
                {
                    var newDefaultRole = new IdentityRole();
                    newDefaultRole.Name = roleUser;
                    await _roleManager.CreateAsync(newDefaultRole);
                }

                // If the default role Admin doesn't exist, create a new one
                if (!defaultRoleAdmin)
                {
                    var newDefaultRole = new IdentityRole();
                    newDefaultRole.Name = roleAdmin;
                    await _roleManager.CreateAsync(newDefaultRole);
                }

                // Create a new user with the password
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Assign the default role to the new user
                    await _userManager.AddToRoleAsync(user, roleUser);

                    // Register new user to the User table
                    // Normally this code would be placed in a repository.
                    User registerUser = new User()
                    {
                        Email = Input.Email,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName
                    };
                    _context.Users.Add(registerUser);
                    _context.SaveChanges();

                    _logger.LogInformation("New user has been created.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
