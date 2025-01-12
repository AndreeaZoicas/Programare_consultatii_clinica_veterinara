using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Programare_consultatii_clinica_veterinara.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Programare_consultatii_clinica_veterinaraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Programare_consultatii_clinica_veterinaraContext") ?? throw new InvalidOperationException("Connection string 'Programare_consultatii_clinica_veterinaraContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
