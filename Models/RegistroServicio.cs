using System.ComponentModel.DataAnnotations;

namespace ConsoliParcial3.Models
{
    public class RegistroServicio
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Cliente")]
        public int PacienteId { get; set; }
        [Display(Name = "Empleado")]
        public int id { get; set; }
        public string Descripcion { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
    }
}
