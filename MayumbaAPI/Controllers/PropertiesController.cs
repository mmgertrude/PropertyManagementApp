using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstatesAppDomain;
using EstatesData;

namespace EstatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly EstatesContext _context;
        //constructor that references the Estates context
        public PropertiesController(EstatesContext context)
        {
            _context = context;
        }

        // GET: api/Properties    ----------this method retrieves all the properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5  ----------this method retrieves 1  property by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(string id)
        {
            var @property = await _context.Properties.FindAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        // PUT: api/Properties/5 ----------this method updates a property
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(string id, Property @property)
        {
            if (id != @property.Property_Id)
            {
                return BadRequest();
            }

            _context.Entry(@property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties ----------this method adds a property
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
            _context.Properties.Add(@property);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropertyExists(@property.Property_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProperty", new { id = @property.Property_Id }, @property);
        }

        // DELETE: api/Properties/5 ----------this method deletes a property
        [HttpDelete("{id}")]
        public async Task<ActionResult<Property>> DeleteProperty(string id)
        {
            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();

            return @property;
        }

        private bool PropertyExists(string id)
        {
            return _context.Properties.Any(e => e.Property_Id == id);
        }
    }
}
