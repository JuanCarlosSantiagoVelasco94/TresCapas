using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BLL.Service
{
    public interface IVideojuegoService
    {
        Task<bool> Insertar(Juego modelo);
        Task<bool> Actualizar(Juego modelo);
        Task<bool> Eliminar(int id);
        Task<Juego> Obtener(int id);
        Task<IQueryable<Juego>> ObtenerTodos();
        Task<Juego> ObtenerPorNombre(string NombreJuego);
    }
}
