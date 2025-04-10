using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;
using PhoneBook.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet("Search/{name?}")]
    public async Task<ActionResult<IEnumerable<Contact>>> Search(string? name)
    {
        return Ok(await _contactService.SearchContactsAsync(name));
    }

    [HttpPost]
    public async Task<ActionResult<Contact>> Create([FromBody] ContactViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var contact = new Contact
        {
            Name = model.FullName,
            PhoneNumber = model.PhoneNumber,
            Email = model.Email
        };

        await _contactService.AddContactAsync(contact);
        return CreatedAtAction(nameof(Search), contact);
    }
}