using JsReportApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsReportApi.DTOs
{
    public class TvPostajeDTO
    {
        public List<Tvpostaja> tvPostaje { get; set; }

        public TvPostajeDTO(List<Tvpostaja> tvPostaje)
        {
            this.tvPostaje = tvPostaje;
        }
    }
}
