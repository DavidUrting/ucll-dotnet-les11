using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdventureWorks.Web.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            ReportViewModel vm = new ReportViewModel();
            vm.AvailableReports.Add(new SelectListItem("Alle producten", "AP"));
            vm.AvailableReports.Add(new SelectListItem("Alle klanten", "AC"));

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowReport(string report)
        {
            switch (report)
            {
                case "AP":
                    return Content("Not implemented yet");
                    
                case "AC":
                    return RedirectToAction("GetAllCustomersReport", "Customer", new { area = "Sales" });
                default:
                    return NotFound();
            }
        }
    }
}