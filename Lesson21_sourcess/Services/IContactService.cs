using PhoneBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        Task AddContactAsync(Contact contact);
        Task<IEnumerable<Contact>> SearchContactsAsync(string name);
    }
}