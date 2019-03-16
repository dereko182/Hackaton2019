using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
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
            List<ChartData> chartData3 = new List<ChartData>
            {
                new ChartData { xValue = "2014", yValue = 21 },
                new ChartData { xValue = "2015", yValue = 24 },
                new ChartData { xValue = "2016", yValue = 36 },
                new ChartData { xValue = "2017", yValue = 38 },
                new ChartData { xValue = "2018", yValue = 54 },
                new ChartData { xValue = "2019", yValue = 57 },
                new ChartData { xValue = "2020", yValue = 70 },
            };
            ViewBag.dataSource3 = chartData3;
            List<ChartData> chartData = new List<ChartData>
            {

                new ChartData { xValue = "Chrome", yValue = 37 },
                new ChartData { xValue = "UC Browser", yValue = 17 },
                new ChartData { xValue = "iPhone", yValue = 19 },
                new ChartData { xValue = "Others", yValue = 4  },
                new ChartData { xValue = "Opera", yValue = 11 },
                new ChartData { xValue = "Android", yValue = 12 },
            };
            List<ChartData> chartData2 = new List<ChartData>
            {
                new ChartData { xValue = "2014", yValue = 21 },
                new ChartData { xValue = "2015", yValue = 24 },
                new ChartData { xValue = "2016", yValue = 36 },
                new ChartData { xValue = "2017", yValue = 38 },
                new ChartData { xValue = "2018", yValue = 54 },
                new ChartData { xValue = "2019", yValue = 57 },
                new ChartData { xValue = "2020", yValue = 70 },
            };
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