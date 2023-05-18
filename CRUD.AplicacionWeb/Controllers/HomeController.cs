using CRUD.AplicacionWeb.Models;
using CRUD.AplicacionWeb.Models.ViewModels;
using CRUD.BLL.Service;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideojuegoService _videojuegoService;

        public HomeController(IVideojuegoService VideojuegoServ)
        {
            _videojuegoService = VideojuegoServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task <IActionResult>Lista()
        {
            IQueryable<Juego> queryVideojuego=await _videojuegoService.ObtenerTodos();
            List<VMVideojuego> lista= queryVideojuego.Select(c => new VMVideojuego()
            {
                IdVideojuego = c.IdVideojuego,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Anio = c.Anio,
                Calificacion = c.Calificacion,
                Genero = c.Genero,
                //ConsolaId = c.ConsolaId
            }).ToList();
            return StatusCode(StatusCodes.Status200OK,lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMVideojuego modelo)
        {
            Juego NuvoModelo = new Juego()
            {
                Nombre = modelo.Nombre,
                Descripcion = modelo.Descripcion,
                Anio = modelo.Anio,
                Calificacion = modelo.Calificacion,
                Genero = modelo.Genero
            };
            bool respuesta=await _videojuegoService.Insertar(NuvoModelo);

            return StatusCode(StatusCodes.Status200OK, new {valor=respuesta});
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMVideojuego modelo)
        {
            Juego NuvoModelo = new Juego()
            {
                IdVideojuego = modelo.IdVideojuego,
                Nombre = modelo.Nombre,
                Descripcion = modelo.Descripcion,
                Anio = modelo.Anio,
                Calificacion = modelo.Calificacion,
                Genero = modelo.Genero
            };
            bool respuesta = await _videojuegoService.Actualizar(NuvoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _videojuegoService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}