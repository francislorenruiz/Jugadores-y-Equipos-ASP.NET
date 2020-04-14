using EjercicioFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFinal.Services.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(Jugador jugador);
        ISpecification And(ISpecification otra_especificacion);
    }
}
