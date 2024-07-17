using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SignalRContext>();

builder.Services.AddScoped<IAboutService, AboutManager>(); //Burda diyor ki IAboutService g�rd���n zaman AboutManager s�n�f�n� �a��r
builder.Services.AddScoped<IAboutDal,EfAboutDal>(); //IAboutDal s�n�f�n� g�rd���n zaman EfAboutDal s�n�f�n� �a��r diyor.  Ayn�s� a�a��daki class lar i�in de ge�erli

builder.Services.AddScoped<IBookingService,BookingManager>();
builder.Services.AddScoped<IBookingDal,EfBookingDal>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
