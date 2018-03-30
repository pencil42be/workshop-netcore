using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pencil42.PakjesDienst.Db;

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

            await _queueSender.SendMessage(
                $"pakje met id {entity.Entity.PakjeId} van {entity.Entity.Verzender} voor {entity.Entity.Bestemmeling}");

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

            entity.LeveringsStatus = pakje.LeveringsStatus;
            //TODO: rest

            await _context.SaveChangesAsync();

            await _queueSender.SendMessage(
                $"pakje met id {entity.PakjeId} van {entity.Verzender} voor {entity.Bestemmeling} aangepast");

            return new OkObjectResult(entity);
        }
    }
}