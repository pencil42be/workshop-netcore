using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses;

namespace Pencil42.PakjesDienst.Db.Amqp
{
    public static class PakjeMessageExtensions
    {
        public static PakjeMessage ToPakjeMessage(this Pakje pakje)
        {
            return new PakjeMessage
            {
                PakjeId = pakje.PakjeId,
                Bestemmeling = pakje.Bestemmeling,
                Inhoud = pakje.Inhoud,
                KoerierDienst = pakje.KoerierDienst,
                Verzender = pakje.Verzender,
                VoorzieneLeveringOp = pakje.VoorzieneLeveringOp
            };
        }

        public static PakjeMessage ToPakjeMessage<T>(this Pakje pakje) where T: PakjeMessage
        {
            T result = (T) Activator.CreateInstance(typeof(T));

            result.PakjeId = pakje.PakjeId;
            result.Bestemmeling = pakje.Bestemmeling;
            result.Inhoud = pakje.Inhoud;
            result.KoerierDienst = pakje.KoerierDienst;
            result.Verzender = pakje.Verzender;
            result.VoorzieneLeveringOp = pakje.VoorzieneLeveringOp;

            return result;
        }
    }
}
