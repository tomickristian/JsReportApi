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
using jsreport.Shared;
using jsreport.AspNetCore;

namespace JsReportApi.Controllers
{
    public class HomeController : Controller
    {
        private IJsReportMVCService _renderService;
        private readonly TvRasporedService _tvRasporedService;
        public HomeController(IJsReportMVCService jsReportMVCService)
        {
            _renderService = jsReportMVCService;
            _tvRasporedService = new TvRasporedService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<Stream> TvPostajeHtml()
        {
            var report = await _renderService.RenderByNameAsync("TvPostajeReport", _tvRasporedService.DohvatiTvPostaje());
            return report.Content;
        }
    }
}
