using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.UnitTest
{
    [TestClass]
    public class JugadoresControllerTest
    {
        JugadoresController controlador = new JugadoresController();

        [TestMethod]
        public async Task PruebaIndex()
        {
            var resultado = await controlador.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
        }

        [TestMethod]
        public async Task PruebaCrear()
        {
            IJugadorRepository repositorio = new JugadorRepository();
            Jugador jugador = new Jugador {Nombre = "Pepe", Pais = "España", Valoracion = 5.6, Dorsal = 1};

            var resultado = await controlador.Create(jugador);
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
            var jugadorGuardado = await repositorio.GetById(jugador.ID);
            Assert.IsNotNull(jugadorGuardado);
            
            Assert.AreEqual(jugador.Nombre, jugadorGuardado.Nombre);
            Assert.AreEqual(jugador.Pais, jugadorGuardado.Pais);
            Assert.AreEqual(jugador.Valoracion, jugadorGuardado.Valoracion);
            Assert.AreEqual(jugador.Dorsal, jugadorGuardado.Dorsal);

            await repositorio.Delete(jugador.ID);
            await repositorio.Save();
        }
    }
}
