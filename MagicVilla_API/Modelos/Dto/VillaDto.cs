using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos.Dto
{
    public class VillaDto
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string nombre { get; set; }
        public string detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }

        public int ocupante { get; set; }
        public string imagenUrl { get; set; }
        public string amenidad { get; set; }
        public double MetroCuadrado { get; set; }

    }
}
