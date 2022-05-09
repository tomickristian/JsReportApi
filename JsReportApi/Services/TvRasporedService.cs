using JsReportApi.DTOs;
using JsReportApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsReportApi.Services
{
    public class TvRasporedService
    {
        private readonly TVRASPOREDContext _context;
        public TvRasporedService()
        {
            _context = new TVRASPOREDContext();
        }

        public TvPostajeDTO DohvatiTvPostaje()
        {
            return new TvPostajeDTO(_context.Tvpostajas.Include(t => t.Emisijas).ToList());
        }

        public EmisijeDTO DohvatiEmisijeTvPostaje(int tvPostaja_id)
        {
            return new EmisijeDTO(_context.Emisijas.Where(e => e.TvpostajaId == tvPostaja_id).ToList());
        }
    }
}
