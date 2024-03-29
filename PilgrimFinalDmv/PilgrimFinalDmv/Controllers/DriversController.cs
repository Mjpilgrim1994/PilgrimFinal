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
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly pilgrimfinalContext _context;

        public DriversController(pilgrimfinalContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
          if (_context.Drivers == null)
          {
              return NotFound();
          }
            return await _context.Drivers.ToListAsync();
        }

        // GET: api/Drivers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(string id)
        {
          if (_context.Drivers == null)
          {
              return NotFound();
          }
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(string id, Driver driver)
        {
            if (id != driver.SocialNumber)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(Driver driver)
        {
          if (_context.Drivers == null)
          {
              return Problem("Entity set 'pilgrimfinalContext.Drivers'  is null.");
          }
            _context.Drivers.Add(driver);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriverExists(driver.SocialNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDriver", new { id = driver.SocialNumber }, driver);
        }

        // DELETE: api/Drivers/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(string id)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(string id)
        {
            return (_context.Drivers?.Any(e => e.SocialNumber == id)).GetValueOrDefault();
        }
    }
}
