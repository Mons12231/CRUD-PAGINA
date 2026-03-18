using CrudRazorApp.Data;
using CrudRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Pages.Tareas
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarea Tarea { get; set; } = new Tarea();

        public SelectList ProyectosLista { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var proyectos = await _context.Proyectos
                .OrderBy(p => p.NombreProyecto)
                .ToListAsync();

            ProyectosLista = new SelectList(proyectos, "ProyectoId", "NombreProyecto");

            Tarea.FechaInicio = DateTime.Today;
            Tarea.FechaFinalizacion = DateTime.Today.AddDays(7);
            Tarea.Estatus = "Pendiente";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var proyectos = await _context.Proyectos
                    .OrderBy(p => p.NombreProyecto)
                    .ToListAsync();
                ProyectosLista = new SelectList(proyectos, "ProyectoId", "NombreProyecto");
                return Page();
            }

            if (Tarea.FechaFinalizacion < Tarea.FechaInicio)
            {
                ModelState.AddModelError("Tarea.FechaFinalizacion",
                    "La fecha de finalización debe ser posterior a la fecha de inicio");

                var proyectos = await _context.Proyectos
                    .OrderBy(p => p.NombreProyecto)
                    .ToListAsync();
                ProyectosLista = new SelectList(proyectos, "ProyectoId", "NombreProyecto");
                return Page();
            }

            Tarea.FechaCreacion = DateTime.Now;
            Tarea.FechaModificacion = DateTime.Now;

            _context.Tareas.Add(Tarea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}