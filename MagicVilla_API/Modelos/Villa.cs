using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Modelos
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nombre { get; set; }

        public string detalle { get; set; }

        [Required]
        public double tarifa { get; set; }
        public int ocupante { get; set; }
        public double metrocuadrado { get; set; }
        public string imagenUrl { get; set; }

        public string amenidad { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }


    }
}
