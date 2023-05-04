﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PilgrimFinalDmv.Data;
using PilgrimFinalDmv.Models;

namespace PilgrimFinalDmv.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DriverInfractionsController : ControllerBase
    {
        private readonly pilgrimfinalContext _context;

        public DriverInfractionsController(pilgrimfinalContext context)
        {
            _context = context;
        }

        // GET: api/DriverInfractions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverInfraction>>> GetDriverInfractions()
        {
          if (_context.DriverInfractions == null)
          {
              return NotFound();
          }
            return await _context.DriverInfractions.ToListAsync();
        }

        // GET: api/DriverInfractions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverInfraction>> GetDriverInfraction(int id)
        {
          if (_context.DriverInfractions == null)
          {
              return NotFound();
          }
            var driverInfraction = await _context.DriverInfractions.FindAsync(id);

            if (driverInfraction == null)
            {
                return NotFound();
            }

            return driverInfraction;
        }

        // PUT: api/DriverInfractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverInfraction(int id, DriverInfraction driverInfraction)
        {
            if (id != driverInfraction.InfractionId)
            {
                return BadRequest();
            }

            _context.Entry(driverInfraction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverInfractionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DriverInfractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverInfraction>> PostDriverInfraction(DriverInfraction driverInfraction)
        {
          if (_context.DriverInfractions == null)
          {
              return Problem("Entity set 'pilgrimfinalContext.DriverInfractions'  is null.");
          }
            _context.DriverInfractions.Add(driverInfraction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverInfraction", new { id = driverInfraction.InfractionId }, driverInfraction);
        }

        // DELETE: api/DriverInfractions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverInfraction(int id)
        {
            if (_context.DriverInfractions == null)
            {
                return NotFound();
            }
            var driverInfraction = await _context.DriverInfractions.FindAsync(id);
            if (driverInfraction == null)
            {
                return NotFound();
            }

            _context.DriverInfractions.Remove(driverInfraction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverInfractionExists(int id)
        {
            return (_context.DriverInfractions?.Any(e => e.InfractionId == id)).GetValueOrDefault();
        }
    }
}
