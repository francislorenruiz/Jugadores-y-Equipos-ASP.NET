using System;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications.SpecificationSimples
{
    public class SpecificationNombre : CompositeSpecification
    {
        public override bool IsSatisfiedBy(Jugador jugador)
        {
            try
            { 
                return !jugador.Nombre.StartsWith("Z") 
                    && !jugador.Nombre.StartsWith("z") 
                    && jugador.Nombre != ""
                    && jugador.Nombre != " ";
            }
            catch(Exception exc)
            {
                throw new SpecificationException("No se ha podido comprobar la especifiación del nombre", exc);
             }
        }
    }
}