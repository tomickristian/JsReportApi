using System;
using System.Collections.Generic;

#nullable disable

namespace JsReportApi.Models
{
    public partial class Emisija
    {
        public Emisija()
        {
            Pretplata = new HashSet<Pretplatum>();
        }

        public int EmisijaId { get; set; }
        public int TvpostajaId { get; set; }
        public int ZanrId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumVrijemePocetka { get; set; }
        public DateTime DatumVrijemeZavrsetka { get; set; }

        public virtual Tvpostaja Tvpostaja { get; set; }
        public virtual Zanr Zanr { get; set; }
        public virtual ICollection<Pretplatum> Pretplata { get; set; }
    }
}
