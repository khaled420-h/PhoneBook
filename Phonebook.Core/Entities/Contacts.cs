using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.Entities
{
    public class Contacts: BaseEntity
    {

        
        [Required]
        public int PhoneNumber { get; set; }

     
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }


    }
}
