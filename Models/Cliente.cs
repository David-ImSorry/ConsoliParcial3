using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsoliParcial3.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Cliente")]
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Descripcion { get; set; }
        public ICollection<RegistroServicio>? RegistroServicio { get; set; } = default!;
    }
}
