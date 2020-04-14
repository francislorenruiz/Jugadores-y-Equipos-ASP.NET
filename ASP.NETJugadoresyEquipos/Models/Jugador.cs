using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinal.Models
{
    public partial class Jugador : IPersona
    {
        public int? ID { get; set; }
        [JsonProperty("NombreJugador")]
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public double Valoracion { get; set; }
        public int Dorsal { get; set; }
    }
}