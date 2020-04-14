using EjercicioFinal.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EjercicioFinal.DAL
{
    public class JugadorContext: DbContext
    {
        public JugadorContext() : base("JugadorContext")
        { }

        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<EjercicioFinal.Models.ViewModel.EquiposValidos> EquiposValidos { get; set; }
    }
}