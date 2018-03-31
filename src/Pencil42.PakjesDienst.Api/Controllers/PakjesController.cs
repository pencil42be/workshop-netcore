using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pencil42.PakjesDienst.Db;
using Pencil42.PakjesDienst.Db.Amqp;

namespace Pencil42.PakjesDienst.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Pakjes")]
    public class PakjesController : Controller
    {
        private readonly PakjesContext _context;
        private readonly ILogger<PakjesController> _logger;
        private readonly QueueSender _queueSender;

        public PakjesController(PakjesContext context, ILogger<PakjesController> logger, QueueSender queueSender)
        {
            _context = context;
            _logger = logger;
            _queueSender = queueSender;
        }

        [HttpPost]
        public async Task<IActionResult> AddPakje([FromBody]Pakje pakje)
        {
            var entity = await _context.Pakjes.AddAsync(pakje);
            await _context.SaveChangesAsync();

            await _queueSender.SendMessage(pakje.ToPakjeMessage());

            return new OkObjectResult(entity.Entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPakjes()
        {
            var all = await _context.Pakjes.ToListAsync();
            return new OkObjectResult(all);
        }

        [HttpGet("{pakjeId}")]
        public async Task<IActionResult> GetPakje(int pakjeId)
        {
            var pakje = await _context.Pakjes.FirstOrDefaultAsync(p => p.PakjeId == pakjeId);
            if (pakje == null) return new NotFoundResult();
            return new OkObjectResult(pakje);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePakje([FromBody]Pakje pakje)
        {
            var entity = await _context.Pakjes.FirstOrDefaultAsync(p => p.PakjeId == pakje.PakjeId);
            if (entity == null) return new NotFoundResult();

            // determine update type
            PakjeMessage pakjeMessage = null;
            if (pakje.LeveringsStatus == LeveringsStatus.Geleverd)
            {
                pakjeMessage = new PakjeGeleverdMessage();
                 ((PakjeGeleverdMessage)pakjeMessage).GeleverdOp = pakje.GeleverdOp;
            }
            else if (pakje.LeveringsStatus != entity.LeveringsStatus)
            {
                pakjeMessage = new PakjeStatusGewijzigdMessage();
                ((PakjeStatusGewijzigdMessage)pakjeMessage).VorigeStatus = entity.LeveringsStatus;
                ((PakjeStatusGewijzigdMessage)pakjeMessage).NieuweStatus = pakje.LeveringsStatus;
            }
            else if(pakje.VoorzieneLeveringOp != entity.VoorzieneLeveringOp)
            {
                pakjeMessage = new PakjeLeveringGewijzigdMessage();
                ((PakjeLeveringGewijzigdMessage)pakjeMessage).VorigeVoorzieneLeveringOp = entity.VoorzieneLeveringOp;
                ((PakjeLeveringGewijzigdMessage)pakjeMessage).NieuweVoorzieneLeveringOp = pakje.VoorzieneLeveringOp;
            }
            else
            {
                pakjeMessage = new PakjeMessage();
            }

            // save changes
            entity.LeveringsStatus = pakje.LeveringsStatus;
            entity.Bestemmeling = pakje.Bestemmeling ?? entity.Bestemmeling;
            entity.Inhoud = pakje.Inhoud ?? entity.Inhoud;
            entity.KoerierDienst = pakje.KoerierDienst ?? entity.KoerierDienst;
            entity.Verzender = pakje.Verzender ?? entity.Verzender;
            entity.VoorzieneLeveringOp = pakje.VoorzieneLeveringOp ?? entity.VoorzieneLeveringOp;
            entity.GeleverdOp = pakje.GeleverdOp ?? entity.GeleverdOp;
            await _context.SaveChangesAsync();

            // send message
            pakjeMessage.Bestemmeling = entity.Bestemmeling;
            pakjeMessage.Inhoud = entity.Inhoud;
            pakjeMessage.KoerierDienst = entity.KoerierDienst;
            pakjeMessage.Verzender = entity.Verzender;
            pakjeMessage.VoorzieneLeveringOp = entity.VoorzieneLeveringOp;
            await _queueSender.SendMessage(pakjeMessage);

            return new OkObjectResult(entity);
        }
    }
}