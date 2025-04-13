using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Core.Entities;
using Phonebook.Core.RepositoryContract;
using PhoneBook.DTO;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactsController(IContactRepository contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<ContactDTO>> GetallContacts()
        {

            var data = _contactRepository.GetAll();
            if (data is not null)
            {
                var mappeddata = _mapper.Map<IEnumerable<Contacts>, IEnumerable<ContactDTO>>(data);
                return Ok(mappeddata);
            }
            else 
                { return NotFound(); }
        }


        [HttpGet("SecrchByNumber")]
        public ActionResult<ContactDTO> Getspecificnumber([FromQuery] int number)
        {
            var contact = _contactRepository.GetByPhoneNumber(number);
            if(contact is not null)
            {
                var mappeddata= _mapper.Map<Contacts, ContactDTO>(contact);

                return Ok(mappeddata);
            }
            
            else return NotFound();
        }

        [HttpGet("SearchByName")]
        public ActionResult<ContactDTO> Getspecificnumber([FromQuery] string name)
        {
           
            var contact = _contactRepository.GetByPhoneName(name);
            if (contact is not null)
            {
                var mappeddata = _mapper.Map<IEnumerable<Contacts>,IEnumerable<ContactDTO>>(contact);

                return Ok(mappeddata);
            }
            else return NotFound();
        }


        [HttpGet("Update")]
        public void UpdateContact([FromQuery]int oldNumber,[FromQuery]ContactDTO UpdatedContact)
        {

            Contacts checkcontact = _contactRepository.GetByPhoneNumber(oldNumber);

            if (checkcontact is not null)
            {

                checkcontact.Name = UpdatedContact.Name;
                checkcontact.PhoneNumber = UpdatedContact.PhoneNumber;
                checkcontact.Email = UpdatedContact.Email;

                _contactRepository.UpdateContact(checkcontact);
            }

            
        }

        [HttpGet("Delete")]
        public void DeleteContactByNumber([FromQuery] int  number)
        {
            var contact = _contactRepository.GetByPhoneNumber(number);

            if (contact is not null)
            {
                _contactRepository.DeleteContact(contact);

            }


           
        }


        [HttpGet("Add")]
        public ActionResult<ContactDTO> AddContact([FromQuery] ContactDTO contact)
        {
            if (contact is not null)
            {
                //Contacts con=new Contacts();    
                //con.Name = contact.Name;
                //con.PhoneNumber = contact.PhoneNumber;
                //con.Email = contact.Email;
                var con = _mapper.Map<ContactDTO,Contacts>(contact);
                _contactRepository.AddContact(con);
                return Ok();
            }
            else
                return BadRequest();
                
            

        }
    }
}
