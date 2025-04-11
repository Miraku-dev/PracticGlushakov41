using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly PhoneBookContext _context;

    public ContactsController(PhoneBookContext context)
    {
        _context = context;
    }

    // GET: api/Contacts
    [HttpGet]
    public async Task<IActionResult> Get(string searchString = "")
    {
        var query = _context.Contacts.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(c => c.Name.Contains(searchString));
        }

        return Ok(await query.ToListAsync());
    }

    // GET: api/Contacts/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    // POST: api/Contacts
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
    }

    // PUT: api/Contacts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
    {
        if (id != contact.Id)
        {
            return BadRequest();
        }

        _context.Entry(contact).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContactExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Contacts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContactExists(int id)
    {
        return _context.Contacts.Any(e => e.Id == id);
    }
}