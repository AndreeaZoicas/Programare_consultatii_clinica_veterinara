using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Programare_consultatii_clinica_veterinara.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure Identity with LibraryIdentityContext
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

// Configure LibraryIdentityContext with the correct connection string
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIdentityContextConnection")
    ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContextConnection' not found.")));

// Configure Programare_consultatii_clinica_veterinaraContext with its connection string
builder.Services.AddDbContext<Programare_consultatii_clinica_veterinaraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Programare_consultatii_clinica_veterinaraContext")
    ?? throw new InvalidOperationException("Connection string 'Programare_consultatii_clinica_veterinaraContext' not found.")));

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
