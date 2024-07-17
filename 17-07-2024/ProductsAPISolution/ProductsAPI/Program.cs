using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Contexts;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using ProductsAPI.Repositories;
using ProductsAPI.Services;

namespace ProductsAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //connection string retrieved from azure keyvault 
            const string secretName = "connectionString02";
            var keyVaultName = "products-keyVault-pavi";
            var kvUri = $"https://products-keyVault-pavi.vault.azure.net/";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync(secretName);

            #region Context
            builder.Services.AddDbContext<ProductContext>(
                options => options.UseSqlServer(secret.Value.Value)
                );
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
