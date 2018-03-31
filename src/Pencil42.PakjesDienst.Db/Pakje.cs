using System;

namespace Pencil42.PakjesDienst.Db
{
    public class Pakje
    {
        public int PakjeId { get; set; }
        public string Verzender { get; set; }
        public string KoerierDienst { get; set; }
        public string Inhoud { get; set; }
        public string Bestemmeling { get; set; }
        public DateTime? VoorzieneLeveringOp { get; set; }
        public DateTime? GeleverdOp { get; set; }
        public LeveringsStatus LeveringsStatus { get; set; }
    }
}
