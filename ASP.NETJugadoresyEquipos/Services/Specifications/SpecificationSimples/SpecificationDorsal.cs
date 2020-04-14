using System;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications.SpecificationSimples
{
    public class SpecificationDorsal : CompositeSpecification
    {
        public override bool IsSatisfiedBy(Jugador jugador)
        {
            try
            {
                return jugador.Dorsal >= 0 && jugador.Dorsal < 100;
            }
            catch(Exception exc)
            {
                throw new SpecificationException("No se ha podido comprobar la especifiación del dorsal", exc);
            }
        }
    }
}