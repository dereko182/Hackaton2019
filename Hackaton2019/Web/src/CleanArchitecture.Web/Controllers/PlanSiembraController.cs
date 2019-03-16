using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using Syncfusion.JavaScript.Shared.Serializer;

namespace CleanArchitecture.Web.Controllers
{
    public class PlanSiembraController : Controller
    {
        private IRepository _repository;
        public PlanSiembraController(IRepository repository) {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> GetData([FromBody] DataManagerRequest dm)
        {
            var dataSource =  _repository.List<PlanSiembra>().ToList();

            return  Json(new { result = dataSource, count = dataSource.Count });
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() {
            var cultivos=_repository.List<Cultivo>().ToList();
            PlanSiembraModel planSiembra = new PlanSiembraModel { CultivosDisponibles = cultivos };
            return PartialView("Create",planSiembra);
        }
        [HttpPost]
        public IActionResult Create(PlanSiembra planSiembra) {
            if (ModelState.IsValid)
            {
                _repository.Add(planSiembra);
            }
         
            return View("Index");
            
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}