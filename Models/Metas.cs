using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_DavidRosario.Models;

public class Metas
{
    [Key]
    public int MetaId { get; set; }

    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Debe ingresar una descripción")]
    public string Descripcion { get; set; }

    [Range(1,float.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }
}
