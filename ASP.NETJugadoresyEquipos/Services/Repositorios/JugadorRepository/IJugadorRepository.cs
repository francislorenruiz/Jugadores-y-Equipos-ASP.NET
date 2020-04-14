using EjercicioFinal.Models;
using EjercicioFinal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFinal.Services.Repositorios.JugadorRepository
{
    public interface IJugadorRepository: IGenericRepository<Jugador>
    {
        IList<EquiposValidos> EquiposValidos();
        IList<Jugador> JugadoresDelEquipo(string Pais);
    }
}
