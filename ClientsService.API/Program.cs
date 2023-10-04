using ClientsService.Core.Interfaces;
using ClientsService.Infraestructure.Data;
using ClientsService.Infraestructure.Mappings;
using ClientsService.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClientsService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ClientsDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ClientsDBConnection")));
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}