using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Specs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IRepository _repository;
        public  ReportesController(IRepository repository){
            _repository = repository;
}
        public IActionResult Index()
        {
            var plagas = _repository.List<Plaga>().ToList();
            var parcelas = _repository.List<Parcela>().ToList();
            var parcelasiembra = _repository.List<PlanSiembraParcela>().ToList();
            var cultivos = _repository.List<Cultivo>().ToList();
            var planSiembras = _repository.List(new PlanSiembraSpec()).ToList();

            List<ChartData> chartData6 = new List<ChartData> {
                new ChartData { xValue = "TERMINADO", yValue = 201 },
               
                new ChartData { xValue = "CANCELADO POR PLAGA", yValue = 54 },
              
                new ChartData { xValue = "ACTIVO", yValue = 60 }};
            ViewBag.chartData6 = chartData6;

            List<ChartData> chartData7 = new List<ChartData> ();
            foreach (var item in planSiembras)
            {
                chartData7.Add(new ChartData { xValue = item.Cultivo.Nombre, yValue = new Random().Next(100)});
            }
            ViewBag.chartData7 = chartData7;


            var fungicidas = _repository.List<Producto>().ToList().Where(m => m.Categoria.Equals("FUNGICIDA BIOLOGICO"));
            List<ChartData> chartData3 = new List<ChartData>();
            foreach (var item in parcelas) {
                chartData3.Add(new ChartData { xValue = item.Nombre, yValue = parcelasiembra.Where(m => m.ParcelaId == item.Id).Count() });
            }
            ViewBag.dataSource3 = chartData3;
            List<ChartData> chartData = new List<ChartData>();
            foreach(var item in cultivos)
            {
                chartData.Add(new ChartData { xValue = item.Nombre, yValue = planSiembras.Select(m => m.Cultivo).Where(m => m.Id == item.Id).Count() });
            }
            List<ChartData> chartData4 = new List<ChartData>();
            foreach (var item in fungicidas)
            {
                chartData4.Add(new ChartData { xValue = item.Nombre, yValue =  new Random().Next(30) });
            }

            ViewBag.dataSource4 = chartData4;
            List<ChartData> chartData2 = new List<ChartData>();
            foreach (var item in plagas) {
                chartData2.Add(new ChartData { xValue = item.Nombre, yValue = new Random().Next(40) });
            }
            ViewBag.dataSource = chartData;
            
            ViewBag.dataSource2 = chartData2;
            return View();

        }

        public class ChartData
        {
            public string xValue;
            public double yValue;
        }
    }
}