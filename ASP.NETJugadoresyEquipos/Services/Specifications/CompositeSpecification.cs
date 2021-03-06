﻿using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications
{
    public abstract class CompositeSpecification : ISpecification
    {
        public abstract bool IsSatisfiedBy(Jugador jugador);

        public ISpecification And(ISpecification otra_especificacion)
        {
            return new AndSpecification(this, otra_especificacion);
        }
    }
}