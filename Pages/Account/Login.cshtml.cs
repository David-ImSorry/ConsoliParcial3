using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConsoliParcial3.Models;
using System.Security.Claims;

namespace ConsoliParcial3.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (User.Email == "correo@gmail.com" && User.Password == "12345")
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
                    new Claim(ClaimTypes.Name, "User "),
                    new Claim(ClaimTypes.Email, User.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal clasimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", clasimsPrincipal);
                return RedirectToPage("/index");

            }
            return Page();
        }
    }
}

