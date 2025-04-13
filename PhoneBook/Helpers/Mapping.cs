using AutoMapper;
using Phonebook.Core.Entities;
using PhoneBook.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook.Helpers
{
    public class Mapping: Profile
    {

        public Mapping()
        {
            CreateMap<Contacts, ContactDTO>()
                .ForMember(D => D.PhoneNumber, O => O.MapFrom(C => C.PhoneNumber))
                .ForMember(D => D.Name, O => O.MapFrom(C => C.Name))
                .ForMember(D => D.Email, O => O.MapFrom(C => C.Email)).ReverseMap();
        }


    }
}
