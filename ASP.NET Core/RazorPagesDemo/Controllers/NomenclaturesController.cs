﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPagesDemo.Data;

namespace RazorPagesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomenclaturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NomenclaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Nomenclatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nomenclature>>> GetNomenclature(int? skip,int? take, string? orderby)
        {
            return await _context.Nomenclature.ToListAsync();
        }

        // GET: api/Nomenclatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nomenclature>> GetNomenclature(int id)
        {
            var nomenclature = await _context.Nomenclature.FindAsync(id);

            if (nomenclature == null)
            {
                return NotFound();
            }

            return nomenclature;
        }

        // PUT: api/Nomenclatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomenclature(int id, Nomenclature nomenclature)
        {
            if (id != nomenclature.Id)
            {
                return BadRequest();
            }

            _context.Entry(nomenclature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomenclatureExists(id))
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

        // POST: api/Nomenclatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nomenclature>> PostNomenclature(Nomenclature nomenclature)
        {
            _context.Nomenclature.Add(nomenclature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomenclature", new { id = nomenclature.Id }, nomenclature);
        }

        // DELETE: api/Nomenclatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomenclature(int id)
        {
            var nomenclature = await _context.Nomenclature.FindAsync(id);
            if (nomenclature == null)
            {
                return NotFound();
            }

            _context.Nomenclature.Remove(nomenclature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NomenclatureExists(int id)
        {
            return _context.Nomenclature.Any(e => e.Id == id);
        }
    }
}
