using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsoliParcial3.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Nombre Medico")]
        public string Nombre { get; set; }
        public string TipodeServicio { get; set; }
        [Display(Name = "Correo Corporativo")]
        public string CorreoCo { get; set; }
        public ICollection<RegistroServicio>? RegistroServicio { get; set; } = default!;
    }
}
