
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Phonebook.Core.RepositoryContract;
using Phonebook.Repository.Data;
using Phonebook.Repository.RepositoryImplementation;
using PhoneBook.Helpers;

namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region configure services 

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Context>(Options =>
            {
                Options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            } );

            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Mapping));
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region configure kestrel  // middlewares
             
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
