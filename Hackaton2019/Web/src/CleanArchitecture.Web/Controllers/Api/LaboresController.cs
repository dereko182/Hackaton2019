using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Specs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CleanArchitecture.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/labores")]
    public class LaboresController : Controller
    {
        private readonly IRepository _repository;

        public LaboresController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            var labores = _repository.List(new LaborSpec());

            var p = labores.Select(x => new A
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Fase = x.Fase.Nombre,
                Fecha = ""
            }
            ).ToList();

            var i = 0;
            p.ForEach(x =>
            {
                i++;

                if (i % 2 == 0)
                {
                    x.Fecha = DateTime.Now.ToString();
                    x.Estado = "En espera";
                }
                else if (i % 3 == 0)
                {
                    x.Fecha = DateTime.Now.AddDays(10).ToString();
                    x.Estado = "Cancelado";
                }

                else if (i % 5 == 0)
                {
                    x.Fecha = DateTime.Now.AddDays(5).ToString();
                    x.Estado = "En espera";
                }
                else
                {
                    x.Fecha = DateTime.Now.AddDays(3).ToString();
                    x.Estado = "Realizando";
                }
            });

            return Json(p);
        }

        [HttpPost]
        public IActionResult CambiarEstado(int id, string estado)
        {
            var x = _repository.List<Parcela>().FirstOrDefault();

            Random rnd = new Random();
            int month = rnd.Next(0, 3); // creates a number between 1 and 12

            switch (month)
            {
                case 0:
                    x.Color = "#d3d3d3";
                    break;
                case 1:
                    x.Color = "#ff1744";
                    break;
                case 2:
                    x.Color = "#6cff64";
                    break;
            }

            _repository.Update(x);

            return Ok();
        }
    }

    public class A
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Fase { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
    }
}
