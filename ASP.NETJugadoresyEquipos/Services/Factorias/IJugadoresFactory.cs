using EjercicioFinal.Models;
using System.Collections.Generic;

namespace EjercicioFinal.Services.Factorias
{
    public interface IJugadoresFactory
    {
        List<Jugador> CrearListaJugadores(List<Jugador> jugadores);
        List<Jugador> ListaJugadoresValidos();
        List<Jugador> ListaJugadoresInvalidos();
    }
}
