using CRUD.DAL.DataContext;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL.Repositories
{
    public class VideojuegosRepository : IGenericRepository<Juego>
    {
        private readonly VideojuegosCrudContext _context;
        public VideojuegosRepository(VideojuegosCrudContext context)
        {
            _context = context;
        }
        public async Task<bool> Actualizar(Juego modelo)
        {
            _context.Juegos.Update(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Juego modelo=_context.Juegos.First(c=>c.IdVideojuego==id);
            _context.Juegos.Remove(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Juego modelo)
        {
            _context.Juegos.Add(modelo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Juego> Obtener(int id)
        {
            return await _context.Juegos.FindAsync(id);
        }

        public async Task<IQueryable<Juego>> ObtenerPorNombre()
        {
            throw new NotImplementedException();
            //IQueryable<Juego> queryJuegoSQL = await _contactRepo.ObtenerPorNombre();
            //Juego juego = queryJuegoSQL.Where(c => c.Nombre == NombreJuego).FirstOrDefault();
            //return juego;
        }

        public async Task<IQueryable<Juego>> ObtenerTodos()
        {
            IQueryable<Juego> queryJuegoSQL = _context.Juegos;
            return queryJuegoSQL;
        }
    }
}
