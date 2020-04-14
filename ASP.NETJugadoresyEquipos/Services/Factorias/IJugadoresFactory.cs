using EjercicioFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFinal.Services.Factorias
{
    public interface IJugadoresFactory
    {
        List<Jugador> CrearListaJugadores(List<Jugador> jugadores);
        List<Jugador> ListaJugadoresValidos();
        List<Jugador> ListaJugadoresInvalidos();
    }
}
