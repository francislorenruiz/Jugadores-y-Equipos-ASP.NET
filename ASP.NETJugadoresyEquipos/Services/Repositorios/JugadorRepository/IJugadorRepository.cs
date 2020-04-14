using EjercicioFinal.Models;
using EjercicioFinal.Models.ViewModel;
using System.Collections.Generic;

namespace EjercicioFinal.Services.Repositorios.JugadorRepository
{
    public interface IJugadorRepository: IGenericRepository<Jugador>
    {
        IList<EquiposValidos> EquiposValidos();
        IList<Jugador> JugadoresDelEquipo(string Pais);
    }
}
