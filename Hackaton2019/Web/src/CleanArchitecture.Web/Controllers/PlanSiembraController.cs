using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Specs;
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
           var DataSource = _repository.List(new PlanSiembraSpec()).Select(c => new { id = c.Id, finProgramado = c.FinProgramado, cultivo = c.Cultivo.Nombre, inicioProgramado = c.InicioProgramado, inicioReal = c.InicioReal, finReal = c.FinReal });

            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
            //var dataSource = _repository.List(new PlanSiembraSpec()).Select(c => new  { id = c.Id, finProgramado = c.FinProgramado, cultivo = c.Cultivo.Nombre, inicioProgramado = c.InicioProgramado, inicioReal = c.InicioReal, finReal = c.FinReal }).ToList();

            //return Json(new { result = dataSource, count = dataSource.Count });
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
         
            return RedirectToAction("Index");
            
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