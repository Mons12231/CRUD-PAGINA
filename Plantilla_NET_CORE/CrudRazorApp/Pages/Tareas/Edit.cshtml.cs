using CrudRazorApp.Data;
using CrudRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudRazorApp.Pages.Tareas
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarea Tarea { get; set; } = new Tarea();

        public SelectList ProyectosLista { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }

            Tarea = tarea;

            var proyectos = await _context.Proyectos
                .OrderBy(p => p.NombreProyecto)
                .ToListAsync();
            ProyectosLista = new SelectList(proyectos, "ProyectoId", "NombreProyecto");

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

            Tarea.FechaModificacion = DateTime.Now;

            _context.Attach(Tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(Tarea.TareaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.TareaId == id);
        }
    }
}