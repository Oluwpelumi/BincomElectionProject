using BincomElectionProject.Models;
using BincomElectionProject.Repositories.Implementations;
using BincomElectionProject.Repositories.Interfaces;
using BincomElectionProject.Services.Implementations;
using BincomElectionProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ElectionDbContext>(options => options.UseMySQL(connectionStrings));
builder.Services.AddScoped<IPollingUnitRepository, PollingUnitRepository>();
builder.Services.AddScoped<IAnnouncedPuResultRepository, AnnouncedPuResultRepository>();
builder.Services.AddScoped<ILgaRepository, LgaRepository>();
builder.Services.AddScoped<IElectionService, ElectionService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
