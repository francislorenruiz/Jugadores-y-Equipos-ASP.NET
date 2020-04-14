using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(Jugador jugador);
        ISpecification And(ISpecification otra_especificacion);
    }
}
