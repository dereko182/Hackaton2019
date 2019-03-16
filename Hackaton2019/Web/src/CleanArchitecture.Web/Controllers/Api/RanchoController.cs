using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Specs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CleanArchitecture.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/ranchos")]
    public class RanchoController : Controller
    {
        private readonly IRepository _repository;

        public RanchoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerRancho(int id)
        {
            var firstOrDefault = _repository.List(new RanchoSpec()).FirstOrDefault(x => x.Id == id);

            firstOrDefault.Lotes.ToList().ForEach(a =>
            {
                var i = 0;
                a.Parcelas.ToList().ForEach(x =>
                {
                    i++;
                    switch (i)
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
                });
            });

            return Json(firstOrDefault);
        }
    }
}
