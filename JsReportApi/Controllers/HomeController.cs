using jsreport.Client;
using JsReportApi.Services;
using JsReportApi.DTOs;
using JsReportApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsReportApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly TvRasporedService _tvRasporedService;
        public HomeController()
        {
            _tvRasporedService = new TvRasporedService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<Stream> TvPostajeHtml()
        {
            var rs = new ReportingService("http://localhost:5488", "admin", "admin");
            var report = await rs.RenderByNameAsync("TvPostajeReport", _tvRasporedService.DohvatiTvPostaje());
            return report.Content;
        }
    }
}
