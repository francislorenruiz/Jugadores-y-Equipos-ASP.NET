using System.ComponentModel.DataAnnotations;

namespace EjercicioFinal.Models.ViewModel
{
    public class EquiposValidos
    {
        [Key]
        public string Pais { get; set; }

        [Display(Name = "Número de jugadores")]
        public int NumeroJugadores { get; set; }
        public double ValoracionMedia { get; set; }
    }
}