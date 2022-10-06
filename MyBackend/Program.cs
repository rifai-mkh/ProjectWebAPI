//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using MyBackend.DAL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//menambahkan automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



//untuk EF
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("StudentConnection")));

//DI
builder.Services.AddScoped<IStudent, StudentDAL>();
builder.Services.AddScoped<ICourse, CourseDAL>();
builder.Services.AddScoped<IEnrollment, EnrollmentDAL>();

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
