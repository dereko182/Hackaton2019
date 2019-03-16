using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(AppDbContext db)
        {
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
