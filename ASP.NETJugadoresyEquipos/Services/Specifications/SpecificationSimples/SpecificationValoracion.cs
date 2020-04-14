using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications.SpecificationSimples
{
    public class SpecificationValoracion : CompositeSpecification
    {
        public override bool IsSatisfiedBy(Jugador jugador)
        {
            try
            { 
                return jugador.Valoracion >= 1 && jugador.Valoracion <= 10;
            }
            catch(Exception exc)
            {
                throw new SpecificationException("No se ha podido comprobar la especifiación de la valoración", exc);
            }
        }
    }
}