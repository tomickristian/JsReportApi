using System;
using System.Collections.Generic;

#nullable disable

namespace JsReportApi.Models
{
    public partial class Pretplatum
    {
        public int PretplataId { get; set; }
        public int KorisnikId { get; set; }
        public int EmisijaId { get; set; }
        public int Status { get; set; }

        public virtual Emisija Emisija { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
