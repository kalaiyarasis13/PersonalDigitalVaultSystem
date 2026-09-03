
using PersonalDigitalVaultSystem.Repositories.Implementations;
using PersonalDigitalVaultSystem.Repositories.Interfaces;
using PersonalDigitalVaultSystem.Services.Implementations;
using PersonalDigitalVaultSystem.Services.Interfaces;

namespace PersonalDigitalVaultSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

            builder.Services.AddScoped<IPaymentService, PaymentService>();

            // Add services to the container.

            builder.Services.AddControllers();
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
