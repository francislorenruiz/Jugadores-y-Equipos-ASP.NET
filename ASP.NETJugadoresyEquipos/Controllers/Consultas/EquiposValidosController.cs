using AutoMapper;
using EjercicioFinal.Models;
using EjercicioFinal.Models.ViewModel;
using EjercicioFinal.Services.Repositorios.JugadorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EjercicioFinal.Controllers.Consultas
{
    public class EquiposValidosController : BaseController
    {
        IJugadorRepository _repositorio = new JugadorRepository();

        // GET: EquiposValidos
        public async Task<ActionResult> Index()
        {
            await _repositorio.CargarDatos();
            return View(_repositorio.EquiposValidos().ToList());
        }

        public ActionResult JugadoresPorPais(string Pais)
        {
            ViewBag.NombreEquipo = Pais;
            return View(_repositorio.JugadoresDelEquipo(Pais));
        }

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
    }
}