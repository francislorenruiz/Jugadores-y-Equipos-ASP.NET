using EjercicioFinal.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EjercicioFinal.Services.Repositorios
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbContext _contexto;
        public DbSet<T> _tabla;

        public GenericRepository()
        {
            _contexto = new JugadorContext();
            _tabla = _contexto.Set<T>();
        }

        public GenericRepository(JugadorContext contexto)
        {
            _contexto = contexto;
            _tabla = _contexto.Set<T>();
        }

        public abstract Task CargarDatos();

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _tabla.ToListAsync();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _tabla.FindAsync(id);
        }

        public virtual void Insert(T obj)
        {
            _tabla.Add(obj);
        }

        public virtual void Update(T obj)
        {
            _tabla.Attach(obj);
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task Delete(object id)
        {
            T existing = await _tabla.FindAsync(id);
            _tabla.Remove(existing);
        }

        public virtual async Task Save()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}