using System;
using System.Threading.Tasks;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;
using EjercicioFinal.Services.Repositorios;
using EjercicioFinal.Services.Repositorios.JugadorRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.UnitTest
{
    [TestClass]
    public class JugadorRepositoryTest
    {
        Jugador jugador = new Jugador { Nombre = "Juan", Pais = "España", Dorsal = 9, Valoracion = 4.5 };
        IJugadorRepository repositorio = new JugadorRepository();

        //[TestInitialize]

        [TestMethod]
        public async Task InsertarElemento()
        {
            repositorio.Insert(jugador);
            await repositorio.Save();

            var jugadorGuardado = await repositorio.GetById(jugador.ID);
            Assert.IsNotNull(jugadorGuardado);
            Assert.AreEqual(jugador, jugadorGuardado);

            await repositorio.Delete(jugador.ID);
            await repositorio.Save();
        }

        [TestMethod]
        public async Task BorrarElemento()
        {
            repositorio.Insert(jugador);
            await repositorio.Delete(jugador.ID);
            await repositorio.Save();

            var jugadorGuardado = await repositorio.GetById(jugador.ID);
            Assert.IsNull(jugadorGuardado);
        }
    }
}
