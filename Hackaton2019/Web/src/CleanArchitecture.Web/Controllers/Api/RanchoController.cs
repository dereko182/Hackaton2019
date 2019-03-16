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

            return Json(_repository.List(new RanchoSpec()).FirstOrDefault(x => x.Id == id));
        }
    }
}
