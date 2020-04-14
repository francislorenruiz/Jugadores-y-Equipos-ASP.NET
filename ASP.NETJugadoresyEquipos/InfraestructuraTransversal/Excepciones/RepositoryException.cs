using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioFinal.InfraestructuraTransversal.Excepciones
{
    public class RepositoryException: Exception
    {
        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}