using System;

namespace EjercicioFinal.InfraestructuraTransversal.Excepciones
{
    public class JugadoresFactoryException: Exception
    {
        public JugadoresFactoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}