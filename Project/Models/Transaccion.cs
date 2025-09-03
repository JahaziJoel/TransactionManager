

using System.ComponentModel.DataAnnotations;

public class Transaccion
{
    public int Id { get; set; }

    public string Tipo { get; set; } = "Gasto";

    [Required(ErrorMessage = "El campo monto es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage ="El monto tiene que ser mayor a 0")]
    public decimal Monto { get; set; }

    [Required(ErrorMessage ="El campo categoría es obligatorio")]
    public string Categoria { get; set; } = "";

    [Required(ErrorMessage ="El campo descripción es obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage ="La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;
}