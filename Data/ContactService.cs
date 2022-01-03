using System;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ContactService
    {
        private readonly ContactDbContext _context;

        public ContactService(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<bool> InsertContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Contact> GetContact(Guid Id)
        {
            try
            {
                Contact contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id.Equals(Id));

                return contact;
            }
            catch(Exception e){

                Console.WriteLine($"Could not find contact with that id: {e}");
                return null;
            }
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContact(Contact contact)
        {
            _context.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}



