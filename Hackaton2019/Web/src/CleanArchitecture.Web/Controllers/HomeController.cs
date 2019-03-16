using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository) {
            _repository = repository;
        }

    public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View("CrearEditar");
        }

        [HttpPost]
        public IActionResult Guardar(Parcela model)
        {
            var tam = _repository.List<Parcela>().Count + 1;
            model.Latitud = 32.549356;
            model.Longitud = -115.059435;
            model.LoteId = 1;
            model.Color = "#d3d3d3";
            model.Nombre = tam.ToString();


            if (ModelState.IsValid)
            {
                _repository.Add(model);
            }
            return View(nameof(Index));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
