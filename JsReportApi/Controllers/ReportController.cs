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
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IJsReportMVCService _renderService;
        private readonly TvRasporedService _tvRasporedService;
        public ReportController(IJsReportMVCService jsReportMVCService)
        {
            _renderService = jsReportMVCService;
            _tvRasporedService = new TvRasporedService();
        }

        [HttpGet("TvPostajeHtml")]
        public async Task<IActionResult> TvPostajeHtml()
        {
            try
            {
                var report = await _renderService.RenderByNameAsync("TvPostajeReport", _tvRasporedService.DohvatiTvPostaje());
                return Ok(report.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("EmisijeTvPostajeHtml/{tvPostaja_id}")]
        public async Task<IActionResult> EmisijeTvPostajeHtml([FromRoute]int tvPostaja_id)
        {
            try
            {
                var report = await _renderService.RenderByNameAsync("EmisijeTvPostajeReport", _tvRasporedService.DohvatiEmisijeTvPostaje(tvPostaja_id));
                return Ok(report.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}