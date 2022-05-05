using jsreport.Client;
using JsReportApi.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JsReportApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<System.IO.Stream> TvPostajeHtml()
        {
            var rs = new ReportingService("http://localhost:5488", "admin", "admin");
            var report = await rs.RenderByNameAsync("demoHandler", null);
            return report.Content;
        }
    }
}
