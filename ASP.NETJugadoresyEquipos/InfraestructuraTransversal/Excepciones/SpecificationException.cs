using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinal.InfraestructuraTransversal.Excepciones
{
    public class SpecificationException: Exception
    {
        public SpecificationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}