using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Data;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormResponseController : ControllerBase
    {
        private readonly FormResponseContext _context;

        public FormResponseController(FormResponseContext context)
        {
            _context = context;
        }

        // GET: api/FormResponse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormResponse>>> GetFormResponses()
        {
            return await _context.FormResponses.ToListAsync();
        }

        // GET: api/FormResponse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormResponse>> GetFormResponse(int id)
        {
            var formResponse = await _context.FormResponses.FindAsync(id);

            if (formResponse == null)
            {
                return NotFound();
            }

            return formResponse;
        }

        // PUT: api/FormResponse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormResponse(int id, FormResponse formResponse)
        {
            if (id != formResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(formResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormResponseExists(id))
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

        // POST: api/FormResponse
        [HttpPost]
        public async Task<ActionResult<FormResponse>> PostFormResponse(FormResponse formResponse)
        {
            _context.FormResponses.Add(formResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormResponse", new { id = formResponse.Id }, formResponse);
        }

        // DELETE: api/FormResponse/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FormResponse>> DeleteFormResponse(int id)
        {
            var formResponse = await _context.FormResponses.FindAsync(id);
            if (formResponse == null)
            {
                return NotFound();
            }

            _context.FormResponses.Remove(formResponse);
            await _context.SaveChangesAsync();

            return formResponse;
        }

        private bool FormResponseExists(int id)
        {
            return _context.FormResponses.Any(e => e.Id == id);
        }
    }
}