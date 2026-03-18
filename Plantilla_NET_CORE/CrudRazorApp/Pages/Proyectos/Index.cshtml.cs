using CrudRazorApp.Data;
using CrudRazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Pages.Proyectos
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Proyecto> ListaProyectos { get; set; } = new List<Proyecto>();

        public async Task OnGetAsync()
        {
            ListaProyectos = await _context.Proyectos
                .OrderByDescending(p => p.FechaCreacion)
                .ToListAsync();
        }
    }
} 