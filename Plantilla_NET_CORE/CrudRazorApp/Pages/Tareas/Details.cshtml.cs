using CrudRazorApp.Data;
using CrudRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Pages.Tareas
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Tarea Tarea { get; set; } = new Tarea();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .Include(t => t.Proyecto)
                .FirstOrDefaultAsync(t => t.TareaId == id);

            if (tarea == null)
            {
                return NotFound();
            }

            Tarea = tarea;
            return Page();
        }
    }
}