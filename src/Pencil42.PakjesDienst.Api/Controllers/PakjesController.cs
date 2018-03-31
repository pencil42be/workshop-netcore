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

            PakjeMessage pakjeMessage = null;
            if (pakje.LeveringsStatus == LeveringsStatus.Geleverd)
            {
                pakjeMessage = pakje.ToPakjeMessage<PakjeGeleverdMessage>();
                var s = pakjeMessage as PakjeGeleverdMessage;
                s.GeleverdOp = pakje.GeleverdOp;
            }
            else if (pakje.LeveringsStatus != entity.LeveringsStatus)
            {
                pakjeMessage = pakje.ToPakjeMessage<PakjeStatusGewijzigdMessage>();
                var s = pakjeMessage as PakjeStatusGewijzigdMessage;
                s.VorigeStatus = entity.LeveringsStatus;
                s.NieuweStatus = pakje.LeveringsStatus;
            }
            else if(pakje.VoorzieneLeveringOp != entity.VoorzieneLeveringOp)
            {
                pakjeMessage = pakje.ToPakjeMessage<PakjeLeveringGewijzigdMessage>();
                var s = pakjeMessage as PakjeLeveringGewijzigdMessage;
                s.VorigeVoorzieneLeveringOp = entity.VoorzieneLeveringOp;
                s.NieuweVoorzieneLeveringOp = pakje.VoorzieneLeveringOp;
            }

            entity.LeveringsStatus = pakje.LeveringsStatus;
            entity.Bestemmeling = pakje.Bestemmeling;
            entity.Inhoud = pakje.Inhoud;
            entity.KoerierDienst = pakje.KoerierDienst;
            entity.Verzender = pakje.Verzender;
            entity.VoorzieneLeveringOp = pakje.VoorzieneLeveringOp;
            entity.GeleverdOp = pakje.GeleverdOp;

            await _context.SaveChangesAsync();

            await _queueSender.SendMessage(pakjeMessage);

            return new OkObjectResult(entity);
        }
    }
}