using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorApp.Models
{
    [Table("Proyectos")]
    public class Proyecto
    {
        [Key]
        public int ProyectoId { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [StringLength(100)]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        [StringLength(200)]
        [Display(Name = "Nombre del Proyecto")]
        public string NombreProyecto { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalización es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Finalización")]
        public DateTime FechaFinalizacion { get; set; }

        [Required(ErrorMessage = "El integrante es obligatorio")]
        [StringLength(200)]
        public string Integrante { get; set; } = string.Empty;

        [StringLength(int.MaxValue)]
        public string? Tareas { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha de Modificación")]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}