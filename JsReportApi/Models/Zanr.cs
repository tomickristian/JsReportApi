using System;
using System.Collections.Generic;

#nullable disable

namespace JsReportApi.Models
{
    public partial class Zanr
    {
        public Zanr()
        {
            Emisijas = new HashSet<Emisija>();
        }

        public int ZanrId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Emisija> Emisijas { get; set; }
    }
}
