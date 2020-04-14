using EjercicioFinal.Models;
using EjercicioFinal.Services.Specifications;
using EjercicioFinal.Services.Specifications.SpecificationSimples;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http;

namespace EjercicioFinal.DAL
{
    public class JugadorInitializer : System.Data.Entity.CreateDatabaseIfNotExists<JugadorContext>
    {
    }
}