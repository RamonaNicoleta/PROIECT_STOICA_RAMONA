using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_Stoica_Ramona.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Cars");
    options.Conventions.AllowAnonymousToPage("/Cars/Index");
    options.Conventions.AllowAnonymousToPage("/Cars/Details");
    options.Conventions.AuthorizeFolder("/Clients", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Locations", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/EngineTypes", "AdminPolicy");
});

builder.Services.AddDbContext<Proiect_Stoica_RamonaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Stoica_RamonaContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Stoica_RamonaContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Stoica_RamonaContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Stoica_RamonaContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
