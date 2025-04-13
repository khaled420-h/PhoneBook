using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phonebook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Repository.Data.Configrations
{
    public class ContactConfigrations : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.HasIndex(c => c.PhoneNumber).IsUnique();   
        }
    }
}
