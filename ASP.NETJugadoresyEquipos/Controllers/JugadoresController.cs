using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using EjercicioFinal.Models;
using EjercicioFinal.Services.Repositorios.JugadorRepository;
using System;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;

namespace EjercicioFinal.Controllers
{
    public class JugadoresController : BaseController
    {
        private IJugadorRepository _repositorio;

        public JugadoresController()
        {
            _repositorio = new JugadorRepository();
        }

        public JugadoresController(IJugadorRepository repositorio)
        {
            _repositorio = repositorio;
        }
        
        // GET: Jugadores
        public async Task<ActionResult> Index()
        {
            await _repositorio.CargarDatos();
            return View(await _repositorio.GetAll());
        }

        // GET: Jugadores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jugador = await _repositorio.GetById(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nombre,Pais,Valoracion,Dorsal")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Insert(jugador);
                await _repositorio.Save();
                return RedirectToAction("Index");
            }

            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jugador = await _repositorio.GetById(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nombre,Pais,Valoracion,Dorsal")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Update(jugador);
                await _repositorio.Save();
                return RedirectToAction("Index");
            }
            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jugador = await _repositorio.GetById(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.Delete(id);
            await _repositorio.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}