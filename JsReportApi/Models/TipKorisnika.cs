using System;
using System.Collections.Generic;

#nullable disable

namespace JsReportApi.Models
{
    public partial class TipKorisnika
    {
        public TipKorisnika()
        {
            Korisniks = new HashSet<Korisnik>();
        }

        public int TipId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
