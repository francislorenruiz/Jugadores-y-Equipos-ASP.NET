using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications
{
    public class AndSpecification : CompositeSpecification
    {
        private ISpecification _specification1;
        private ISpecification _specification2;

        public AndSpecification(ISpecification specification1, ISpecification specification2)
        {
            _specification1 = specification1;
            _specification2 = specification2;
        }

        public override bool IsSatisfiedBy(Jugador jugador)
        {
            return _specification1.IsSatisfiedBy(jugador) && _specification2.IsSatisfiedBy(jugador);
        }
    }
}