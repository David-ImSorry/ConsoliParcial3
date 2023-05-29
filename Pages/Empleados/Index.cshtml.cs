using ConsoliParcial3.Data;
using ConsoliParcial3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConsoliParcial3.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly RostrosFContext _context;
        public IndexModel(RostrosFContext context)
        {
            _context = context;
        }
        public IList<Empleado> Empleados { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Empleado != null)
            {
                Empleados = await _context.Empleado.ToListAsync();
            }
        }
    }
}
