using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoliParcial3.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using ConsoliParcial3.Data;

namespace ConsoliParcial3.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly RostrosFContext _dbContext;

        public LoginModel(RostrosFContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (User.Email == "jd.barbetti@gmail.com" && User.Password == "juanda10000")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin "),
                    new Claim(ClaimTypes.Email, User.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal clasimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", clasimsPrincipal);
                return RedirectToPage("/index");
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "User"),
                    new Claim(ClaimTypes.Email, User.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                // Agregar el usuario a la base de datos
                var user = new User
                {
                    Email = User.Email,
                    Password = User.Password
                };

                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                return RedirectToPage("/index");


            }
        }
    }
}

