using CargoTrack.Business;
using CargoTrack.Business.Services.Abouts;
using CargoTrack.Business.Services.Branches;
using CargoTrack.Business.Services.Cities;
using CargoTrack.DataAccess.Context;
using CargoTrack.DataAccess.Repositories.Abouts;
using CargoTrack.DataAccess.Repositories.Branches;
using CargoTrack.DataAccess.Repositories.Cities;
using CargoTrack.Entity.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IOC Container

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(typeof(BusinessAssembly).Assembly);


builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();


builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ICityService, CityService>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    options.UseLazyLoadingProxies();

});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();


builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login/Index";
    config.LogoutPath = "/Login/Logout";
    config.AccessDeniedPath = "/ErrorPages/AccessDenied";
    config.Cookie.Name = "CargoTrackCookie";
});


builder.Services.AddControllersWithViews();

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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Uygulama baþlarken Seed Data ekleme iþlemi
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Veritabanýnýn var olduðundan emin olun (Migration kullanýyorsanýz context.Database.Migrate() yapýn)
    context.Database.EnsureCreated();

    // Eðer veritabanýnda hiç þehir yoksa ekle
    if (!context.Cities.Any())
    {
        var cities = new List<City>
        {
            new City { Id = Guid.NewGuid(), Name = "Ýstanbul" },
            new City { Id = Guid.NewGuid(), Name = "Ankara" },
            new City { Id = Guid.NewGuid(), Name = "Ýzmir" },
            new City { Id = Guid.NewGuid(), Name = "Bursa" },
            new City { Id = Guid.NewGuid(), Name = "Antalya" },
            new City { Id = Guid.NewGuid(), Name = "Adana" },
            new City { Id = Guid.NewGuid(), Name = "Konya" },
            new City { Id = Guid.NewGuid(), Name = "Þanlýurfa" },
            new City { Id = Guid.NewGuid(), Name = "Gaziantep" },
            new City { Id = Guid.NewGuid(), Name = "Kocaeli" },
            new City { Id = Guid.NewGuid(), Name = "Mersin" },
            new City { Id = Guid.NewGuid(), Name = "Diyarbakýr" },
            new City { Id = Guid.NewGuid(), Name = "Hatay" },
            new City { Id = Guid.NewGuid(), Name = "Kayseri" },
            new City { Id = Guid.NewGuid(), Name = "Samsun" },
            new City { Id = Guid.NewGuid(), Name = "Balýkesir" },
            new City { Id = Guid.NewGuid(), Name = "Kahramanmaraþ" },
            new City { Id = Guid.NewGuid(), Name = "Van" },
            new City { Id = Guid.NewGuid(), Name = "Aydýn" },
            new City { Id = Guid.NewGuid(), Name = "Tekirdað" }
        };

        context.Cities.AddRange(cities);
        context.SaveChanges();


       
    }

    if (!context.Roles.Any())
    {
        var roles = new List<AppRole>
            {
                new AppRole{Name="Admin"},
                new AppRole{Name="Manager"},
                new AppRole{Name="User"}
            };

        context.Roles.AddRange(roles);
        context.SaveChanges();
    }

    if (!context.Cargos.Any())
    {
        var cargo = new Cargo
        {
            Id = Guid.NewGuid(),
            SenderId = Guid.Parse("38dcc957-3de7-461d-9539-08df085c7901"),
            ReceiverId = Guid.Parse("c759391c-c627-46cd-953a-08df085c7901"),
            OriginBranchId = Guid.Parse("1253aafb-cccc-4eeb-97cf-394c67cfbe38"),
            DestinationBranchId = Guid.Parse("3842bdc9-c4a6-4ced-8528-9a11686d907a"),
            TrackCode = "CT202609081234",
            ShipmentDate = DateTime.Now,
            EstimatedArrivalDate = DateTime.Now.AddDays(2),
            Weight = 2.5,
            CargoType = CargoTrack.Entity.Entities.Enums.CargoType.Standard,
            CargoStatus = CargoTrack.Entity.Entities.Enums.CargoStatus.DispatchedFromTransferCenter
        };

        context.Add(cargo);
        context.SaveChanges();
    }



    
}




app.Run();
