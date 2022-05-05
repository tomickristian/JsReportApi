using System;
using System.Collections.Generic;

#nullable disable

namespace JsReportApi.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Pretplata = new HashSet<Pretplatum>();
            Tvpostajas = new HashSet<Tvpostaja>();
        }

        public int KorisnikId { get; set; }
        public int TipId { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Slika { get; set; }
        public DateTime? DatumPrijave { get; set; }

        public virtual TipKorisnika Tip { get; set; }
        public virtual ICollection<Pretplatum> Pretplata { get; set; }
        public virtual ICollection<Tvpostaja> Tvpostajas { get; set; }
    }
}
