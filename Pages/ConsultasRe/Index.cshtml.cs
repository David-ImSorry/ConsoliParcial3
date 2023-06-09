using ConsoliParcial3.Data;
using ConsoliParcial3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConsoliParcial3.Pages.ConsultasRe
{
    public class ConsultaModel : PageModel
    {
        private readonly RostrosFContext _context;

        public ConsultaModel(RostrosFContext context)
        {
            _context = context;
        }

        public List<ServicioRealizado> Citas { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        
        {
            Citas = await _context.RegistroServicio
                .Include(_dbContext => _dbContext.Cliente)
                .Include(_dbContext => _dbContext.Empleado)
                .Select(_dbContext => new ServicioRealizado
                {
                    Fecha = _dbContext.Fecha,
                    Cliente = _dbContext.Cliente.Nombre,
                    Empleado = _dbContext.Empleado.Nombre
                })
                .ToListAsync();

            return Page();
        }
    }
}
