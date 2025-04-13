using Phonebook.Core.Entities;
using Phonebook.Core.RepositoryContract;
using Phonebook.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.Repository.RepositoryImplementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _dbcontext;

        public ContactRepository(Context _context)
        {
            _dbcontext = _context;
        }



        // Get All the Data
        public IEnumerable<Contacts> GetAll()
        => _dbcontext.Contacts.ToList();

        public Contacts? GetByPhoneNumber(int PhoneNumber)
        => _dbcontext.Contacts.Where(c=>c.PhoneNumber == PhoneNumber).FirstOrDefault();

        //return the data with specific name 
        //public IReadOnlyList<Contacts> GetByPhoneName(string Name)
        //=>  _dbcontext.Contacts.Where(c => c.Name == Name).ToList();


        // search the contact by any char of the name
        public IEnumerable<Contacts> GetByPhoneName(string Name)
        => _dbcontext.Contacts.Where(c => c.Name.Contains(Name));




        public void AddContact(Contacts contact)
        {
            _dbcontext.Add(contact);
            _dbcontext.SaveChanges();
        }

        public void UpdateContact(Contacts contact)
        {
            _dbcontext.Update(contact);
            _dbcontext.SaveChanges();
        }

        public void DeleteContact(Contacts contact)
        {
            _dbcontext.Remove(contact);
            _dbcontext.SaveChanges();

        }
    }
}
