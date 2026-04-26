using PhonesAPIWeb.Service;
using PhonesAPIWeb.Data;
using PhonesAPIWeb.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CelularesDbContext>();
// Repositorios — registrás la clase concreta directamente
builder.Services.AddScoped<IphoneRepository>();
builder.Services.AddScoped<SamsungRepository>();
builder.Services.AddScoped<PhoneRepository>();

// Services
builder.Services.AddScoped<PhoneService>();
builder.Services.AddScoped<IphoneService>();
builder.Services.AddScoped<SamsungService>();
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();