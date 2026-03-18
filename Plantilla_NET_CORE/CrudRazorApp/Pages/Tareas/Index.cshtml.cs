using CrudRazorApp.Data;
using CrudRazorApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Pages.Tareas
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Tarea> ListaTareas { get; set; } = new List<Tarea>();

        public async Task OnGetAsync()
        {
            ListaTareas = await _context.Tareas
                .Include(t => t.Proyecto)
                .OrderByDescending(t => t.FechaCreacion)
                .ToListAsync();
        }
    }
}