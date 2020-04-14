using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;
using EjercicioFinal.Services.Specifications;
using EjercicioFinal.Services.Specifications.SpecificationSimples;

namespace EjercicioFinal.Services.Factorias
{
    public class JugadoresFactory : IJugadoresFactory
    {
        private ISpecification _especificacion;
        private List<Jugador> jugadoresValidos = new List<Jugador>();
        private List<Jugador> jugadoresInvalidos = new List<Jugador>();

        public JugadoresFactory()
        {
            _especificacion = new SpecificationNombre();
            _especificacion = _especificacion.And(new SpecificationPais());
            _especificacion = _especificacion.And(new SpecificationValoracion());
            _especificacion = _especificacion.And(new SpecificationDorsal());
        }

        public JugadoresFactory(ISpecification especificacion)
        {
            _especificacion = especificacion;
        }

        public List<Jugador> CrearListaJugadores(List<Jugador> jugadores)
        {
            jugadoresValidos = new List<Jugador>();
            jugadoresInvalidos = new List<Jugador>();

            try
            {
                foreach (var jugador in jugadores)
                {
                    if (_especificacion.IsSatisfiedBy(jugador))
                    {
                        jugadoresValidos.Add(jugador);
                    }
                    else
                    {
                        jugadoresInvalidos.Add(jugador);
                    }
                }

                return jugadoresValidos;
            }
            catch(Exception exc)
            {
                throw new JugadoresFactoryException("No se ha podido crear la lista de jugadores válidos." ,exc);
            }
        }

        public List<Jugador> ListaJugadoresInvalidos()
        {
            return jugadoresValidos;
        }

        public List<Jugador> ListaJugadoresValidos()
        {
            return jugadoresInvalidos;
        }
    }
}