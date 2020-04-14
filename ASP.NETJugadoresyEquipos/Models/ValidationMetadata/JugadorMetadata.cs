using System.ComponentModel.DataAnnotations;

namespace EjercicioFinal.Models
{
    public partial class JugadorMetadata
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Debe introducir un nombre")]
        [RegularExpression("^(?!(Z|z).*$).*", ErrorMessage = "El nombre no puede empezar por z")]
        public string Nombre { get; set; }

        [Display(Name = "País")]
        [RegularExpression("^(?!(USA|usa|EEUU)$).*$", ErrorMessage = "El país no puede ser Estados Unidos")]
        [Required(ErrorMessage = "Debe introducir un país")]
        public string Pais { get; set; }

        [Display(Name = "Valoración")]
        [Required(ErrorMessage = "Debe introducir una valoración")]
        [Range(1, 10)]
        public double Valoracion { get; set; }

        [Range(0, 99)]
        [Required(ErrorMessage = "Debe introducir un dorsal")]
        public int Dorsal { get; set; }
    }

    [MetadataType(typeof(JugadorMetadata))]
    public partial class Jugador { }
}
    