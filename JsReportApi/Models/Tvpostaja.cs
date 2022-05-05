using System;
using System.Collections.Generic;

#nullable disable

namespace JsReportApi.Models
{
    public partial class Tvpostaja
    {
        public Tvpostaja()
        {
            Emisijas = new HashSet<Emisija>();
        }

        public int TvpostajaId { get; set; }
        public int ModeratorId { get; set; }
        public string Naziv { get; set; }

        public virtual Korisnik Moderator { get; set; }
        public virtual ICollection<Emisija> Emisijas { get; set; }
    }
}
