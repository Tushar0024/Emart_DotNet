
using Emart_final.Models.Repository;
using Emart_final.Models.Repository.Cartfolder;
using Emart_final.Models.Repository.Categoryfolder;
using Emart_final.Models.Repository.ConfigDetailsfolder;
using Emart_final.Models.Repository.Configfolder;
using Emart_final.Models.Repository.Customerfolder;
using Emart_final.Models.Repository.InvoiceDetailsFolder;
using Emart_final.Models.Repository.Invoicefolder;
using Emart_final.Models.Repository.Orderfolder;
using Emart_final.Models.Repository.Productfolder;
using Microsoft.EntityFrameworkCore;

namespace Emart_final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICartRepository, CartRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddTransient<IInvoiceDetailsRepository, Invoice_detailsRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IConfigDetailsRepository, ConfigDetailsRepository>();
            builder.Services.AddTransient<IConfigRepository, ConfigRepository>();

            builder.Services.AddDbContext<AppDbContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("EmartDBConnection")));
            //builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("EmartDBConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("MyAllowSpecificOrigins");


            app.MapControllers();

            app.Run();
        }
    }
}