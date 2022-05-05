using JsReportApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsReportApi.DAL
{
    public class TvRasporedService
    {
        private readonly TVRASPOREDContext _context;

        public TvRasporedService(TVRASPOREDContext tVRASPOREDContext)
        {
            _context = tVRASPOREDContext;
        }

        public List<Tvpostaja> DohvatiTvPostaje()
        {
            return _context.Tvpostajas.Include(t => t.Emisijas).ToList();
        }
    }
}
