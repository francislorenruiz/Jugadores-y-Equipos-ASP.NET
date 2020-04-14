using System;

namespace EjercicioFinal.InfraestructuraTransversal.Excepciones
{
    public class SpecificationException: Exception
    {
        public SpecificationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}