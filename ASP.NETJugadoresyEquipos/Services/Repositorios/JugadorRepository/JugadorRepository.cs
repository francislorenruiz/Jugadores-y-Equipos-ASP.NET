using EjercicioFinal.InfraestructuraTransversal.Excepciones;
using EjercicioFinal.Models;
using EjercicioFinal.Services.Factorias;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EjercicioFinal.Models.ViewModel;

namespace EjercicioFinal.Services.Repositorios.JugadorRepository
{
    public class JugadorRepository: GenericRepository<Jugador>, IJugadorRepository
    {
        public override async Task CargarDatos()
        {
            IJugadoresFactory factoria = new JugadoresFactory();

            string url = "https://webbasketapi.azurewebsites.net/api/jugadores";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    List<Jugador> lista;
                    string contenido = await response.Content.ReadAsStringAsync();
                    {
                        lista = JsonConvert.DeserializeObject<List<Jugador>>(contenido);
                    }

                    _tabla.RemoveRange(_tabla);
                    lista = factoria.CrearListaJugadores(lista);
                    _tabla.AddRange(lista);

                    await _contexto.SaveChangesAsync();
                }
                catch(HttpRequestException){ }
                catch(Exception exc)
                {
                    throw new RepositoryException("No se han podido cargar los datos en el repositorio.", exc);
                }
            }
        }

        public IList<EquiposValidos> EquiposValidos()
        {
            var equipos = new List<EquiposValidos>();
            var query = (from jugador in _tabla
                        group jugador by jugador.Pais into JugadorPais
                        where JugadorPais.Count() >= 3
                        select new
                        {
                            Pais = JugadorPais.Key,
                            NumeroJugadores = JugadorPais.Count(),
                            MediaEquipo = JugadorPais.Sum(x=> x.Valoracion) / JugadorPais.Count()
                        }).Where(x => x.MediaEquipo >= 5);

            foreach(var item in query)
            {
                var equipoValido = new EquiposValidos
                {
                    Pais = item.Pais,
                    NumeroJugadores = item.NumeroJugadores,
                    ValoracionMedia = item.MediaEquipo
                };

                equipos.Add(equipoValido);
            }

            return equipos;
        }

        public IList<Jugador> JugadoresDelEquipo(string Pais)
        {
            var listaJugadores = new List<Jugador>();
            var query = from jugador in _tabla
                        where jugador.Pais.Equals(Pais)
                        select jugador;
            
            return query.ToList();
        }
    }
}