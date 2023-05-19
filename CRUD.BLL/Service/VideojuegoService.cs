using CRUD.DAL.Repositories;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Service
{
    public class VideojuegoService : IVideojuegoService
    {
        private readonly IGenericRepository<Juego> _contactRepo;
        public VideojuegoService(IGenericRepository<Juego>contactRepo)
        {
         _contactRepo   = contactRepo;
        }
        public async Task<bool> Actualizar(Juego modelo)
        {
            return await _contactRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contactRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Juego modelo)
        {
            return await _contactRepo.Insertar(modelo);
        }

        public async Task<Juego> Obtener(int id)
        {
            return await _contactRepo.Obtener(id);
        }

        public async Task<Juego> ObtenerPorNombre(string NombreJuego)
        {
            IQueryable<Juego> queryJuegoSQL = await _contactRepo.ObtenerPorNombre();
            Juego juego=queryJuegoSQL.Where(c=>c.Nombre == NombreJuego).FirstOrDefault();
            return juego;   
        }

        public async Task<IQueryable<Juego>> ObtenerTodos()
        {
            return await _contactRepo.ObtenerTodos();
        }
    }
}
