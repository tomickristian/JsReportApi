using JsReportApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsReportApi.DTOs
{
    public class EmisijeDTO
    {
        public List<Emisija> emisije { get; set; }

        public EmisijeDTO(List<Emisija> emisije)
        {
            this.emisije = emisije;
        }
    }
}
