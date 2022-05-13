using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserRolesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReportController : ControllerBase
    {

        private IJsReportMVCService _renderService;

        public ReportController(IJsReportMVCService renderService)
        {
            _renderService = renderService;
        }

        [HttpGet("UserRolesHtml")]
        public async Task<IActionResult> UserRolesHtml()
        {
            try
            {
                var report = await _renderService.RenderByNameAsync("UserRolesReport", null);
                return Ok(report.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("UserRolesXlsx")]
        public async Task<IActionResult> TvPostajeXlsx()
        {
            try
            {
                var report = await _renderService.RenderAsync(new RenderRequest() { Template = new Template()
                {
                    Name = "UserRolesReport",
                    Recipe = Recipe.HtmlToXlsx
                }
                });
                return File(report.Content, "application/octet-stream", "report.xlsx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
