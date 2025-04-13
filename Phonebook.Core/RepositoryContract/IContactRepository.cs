using Phonebook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.RepositoryContract
{
    public interface IContactRepository
    {

        IEnumerable<Contacts> GetAll();

        Contacts? GetByPhoneNumber(int PhoneNumber);

        IEnumerable<Contacts> GetByPhoneName(string Name);

        
        void AddContact(Contacts contact);   


        void UpdateContact(Contacts contact);   

        void DeleteContact(Contacts contact);   






    }
}
