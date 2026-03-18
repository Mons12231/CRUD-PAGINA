using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudRazorApp.Models
{
    [Table("Tareas")]
    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }

        [Required(ErrorMessage = "El proyecto es obligatorio")]
        [Display(Name = "Proyecto")]
        public int ProyectoId { get; set; }

        [Required(ErrorMessage = "El nombre de la tarea es obligatorio")]
        [StringLength(200)]
        [Display(Name = "Nombre de la Tarea")]
        public string NombreTarea { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de finalización es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Finalización")]
        public DateTime FechaFinalizacion { get; set; }

        [Required(ErrorMessage = "Los integrantes son obligatorios")]
        [StringLength(200)]
        public string Integrantes { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estatus es obligatorio")]
        [StringLength(50)]
        public string Estatus { get; set; } = string.Empty;

        [StringLength(int.MaxValue)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [StringLength(int.MaxValue)]
        public string? Acciones { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha de Modificación")]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        // Propiedad de navegación
        [ForeignKey("ProyectoId")]
        public virtual Proyecto? Proyecto { get; set; }
    }
}