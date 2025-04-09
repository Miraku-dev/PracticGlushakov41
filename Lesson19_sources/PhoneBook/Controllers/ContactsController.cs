using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly PhoneBookContext _context;

        public ContactsController(PhoneBookContext context)
        {
            _context = context;
        }

        // GET: api/Contacts/Search/{name}
        [HttpGet("Search/{name?}")]
        public async Task<IActionResult> Search(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Ok(await _context.Contacts.ToListAsync());
            }

            var contacts = await _context.Contacts
                .Where(c => c.Name.Contains(name))
                .ToListAsync();

            return Ok(contacts);
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Search), new { name = contact.Name }, contact);
        }
    }
}