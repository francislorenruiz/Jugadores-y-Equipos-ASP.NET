using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;

namespace EjercicioFinal.Services.Specifications.SpecificationSimples
{
    public class SpecificationPais : CompositeSpecification
    {
        public override bool IsSatisfiedBy(Jugador jugador)
        {
            try
            { 
                return jugador.Pais != "USA"
                    && jugador.Pais != "usa"
                    && jugador.Pais != "EEUU";
            }
            catch(Exception exc)
            {
                throw new SpecificationException("No se ha podido comprobar la especifiación del país", exc);
            }
        }
    }
}