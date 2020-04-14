using Newtonsoft.Json;

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