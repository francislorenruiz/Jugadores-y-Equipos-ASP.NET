using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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