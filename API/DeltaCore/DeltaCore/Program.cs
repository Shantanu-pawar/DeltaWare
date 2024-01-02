using DeltaCore.Controllers;
using DeltaCore.Models;
using DeltaCore.ServiceLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IMapper, MyMapper>();
builder.Services.AddScoped<IProductService, ServiceLayer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProductContext>(options => {
    options.UseSqlServer("server=DESKTOP-NJ7R381;database=deltaDBb;Trusted_Connection=true;TrustServerCertificate=True"
        );
});

//public void ConfigureServices(IServiceCollection services){
    // Other configurations...
  //  services.AddScoped<ProductService>();
//}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// now enabling the cors for UI - which means we are allowing angular app to talk to our api
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
