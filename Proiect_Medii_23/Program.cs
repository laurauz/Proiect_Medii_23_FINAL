using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_Medii_23.Data;
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
    options.Conventions.AuthorizeFolder("/EchipamenteSki");
    options.Conventions.AllowAnonymousToPage("/EchipamenteSki/Index");
    options.Conventions.AllowAnonymousToPage("/EchipamenteSki/Details");
    options.Conventions.AuthorizeFolder("/Customers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Orders", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Brands", "AdminPolicy");
});

builder.Services.AddDbContext<Proiect_Medii_23Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Medii_23Context") ?? throw new InvalidOperationException("Connection string 'Proiect_Medii_23Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Medii_23Context") ?? 
    throw new InvalidOperationException("Connectionstring 'Proiect_Medii_23Context' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options =>options.SignIn.RequireConfirmedAccount = true)
//.AddEntityFrameworkStores<LibraryIdentityContext>();

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
