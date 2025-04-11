using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        private readonly PhoneBookContext _context;

        public ContactService(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task AddContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return await _context.Contacts.ToListAsync();

            return await _context.Contacts
                .Where(c => c.Name.Contains(name))
                .ToListAsync();
        }
    }
}