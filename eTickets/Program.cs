
using eTickets.Domain.Interfaces.Repositories;
using eTickets.Infrastracture.Data;
using eTickets.Infrastracture.Repositories;
using eTickets.Infrastracture.SeedDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using eTickets.Data;
using eTickets.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("DefaultConnectionString")
    ));

builder.Services.AddDbContext<eTicketsDbContext>(
    options => options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("DefaultConnectionString")
    ));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<eTicketsDbContext>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>
//    (options =>
//    {
//        options.SignIn.RequireConfirmedAccount = true;
//        options.Password.RequireDigit = false;
//        options.Password.RequiredLength = 8;
//        options.Password.RequireNonAlphanumeric = false;
//        options.Password.RequireUppercase = false;
//        options.Password.RequireLowercase = false;
//    })
//.AddEntityFrameworkStores<AppDbContext>();


//Repositories
builder.Services.AddScoped<IActorRepository, ActorRepository>();
    builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
    builder.Services.AddScoped<IProducerRepository, ProducerRepository>();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.MapRazorPages();

AppDbInitializer.Seed(app);
app.Run();
