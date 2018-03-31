using System;
using System.Collections.Generic;
using System.Text;
using Amqp.Serialization;

namespace Pencil42.PakjesDienst.Db.Amqp
{

    [AmqpContract]
    [AmqpProvides(typeof(PakjeLeveringGewijzigdMessage))]
    [AmqpProvides(typeof(PakjeGeleverdMessage))]
    [AmqpProvides(typeof(PakjeStatusGewijzigdMessage))]
    public class PakjeMessage
    {
        [AmqpMember]
        public int PakjeId { get; set; }

        [AmqpMember]
        public string Bestemmeling { get; set; }

        [AmqpMember]
        public string Verzender { get; set; }

        [AmqpMember]
        public string KoerierDienst { get; set; }

        [AmqpMember]
        public string Inhoud { get; set; }

        [AmqpMember]
        public DateTime VoorzieneLeveringOp { get; set; }

    }

    [AmqpContract]
    public class PakjeLeveringGewijzigdMessage : PakjeMessage
    {
        [AmqpMember]
        public DateTime VorigeVoorzieneLeveringOp { get; set; }

        [AmqpMember]
        public DateTime NieuweVoorzieneLeveringOp { get; set; }
    }

    [AmqpContract]
    public class PakjeStatusGewijzigdMessage : PakjeMessage
    {
        [AmqpMember]
        public LeveringsStatus VorigeStatus { get; set; }

        [AmqpMember]
        public LeveringsStatus NieuweStatus { get; set; }
    }

    [AmqpContract]
    public class PakjeGeleverdMessage : PakjeMessage
    {
        [AmqpMember]
        public DateTime GeleverdOp { get; set; }
    }
}
