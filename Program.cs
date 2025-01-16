using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Programare_consultatii_clinica_veterinara.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIdentityContextConnection")
    ?? throw new InvalidOperationException("Connection string 'LibraryIdentityContextConnection' not found.")));

builder.Services.AddDbContext<Programare_consultatii_clinica_veterinaraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Programare_consultatii_clinica_veterinaraContext")
    ?? throw new InvalidOperationException("Connection string 'Programare_consultatii_clinica_veterinaraContext' not found.")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
