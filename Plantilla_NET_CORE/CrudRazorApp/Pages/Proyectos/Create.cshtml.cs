using CrudRazorApp.Data;
using CrudRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudRazorApp.Pages.Proyectos  // ← DEBE DECIR Proyectos
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proyecto Proyecto { get; set; } = new Proyecto();

        public IActionResult OnGet()
        {
            Proyecto.FechaInicio = DateTime.Today;
            Proyecto.FechaFinalizacion = DateTime.Today.AddMonths(1);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Proyecto.FechaFinalizacion < Proyecto.FechaInicio)
            {
                ModelState.AddModelError("Proyecto.FechaFinalizacion",
                    "La fecha de finalización debe ser posterior a la fecha de inicio");
                return Page();
            }

            Proyecto.FechaCreacion = DateTime.Now;
            Proyecto.FechaModificacion = DateTime.Now;

            _context.Proyectos.Add(Proyecto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}