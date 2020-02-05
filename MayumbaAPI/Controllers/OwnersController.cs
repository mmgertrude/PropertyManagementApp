using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstatesAppDomain;
using MayumbaApp.Data;

namespace MayumbaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly MayumbaContext _context;

        //constructor that references the MayumbaContext context
        public OwnersController(MayumbaContext context)
        {
            _context = context;
        }

        // GET: api/Owners----------this method retrieves all the Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            return await _context.Owners.ToListAsync();
        }

        // GET: api/Owners/5 ----------this method retrieves 1  Owner by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(string id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        // PUT: api/Owners/5----------this method updates a property
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(string id, Owner owner)
        {
            if (id != owner.Owner_NIN)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners----------this method adds an Owner
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnerExists(owner.Owner_NIN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOwner", new { id = owner.Owner_NIN }, owner);
        }

        // DELETE: api/Owners/5----------this method deletes an Owner
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owner>> DeleteOwner(string id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return owner;
        }

        private bool OwnerExists(string id)
        {
            return _context.Owners.Any(e => e.Owner_NIN == id);
        }
    }
}
