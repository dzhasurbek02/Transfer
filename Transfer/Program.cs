using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Transfer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigin", builder => builder.AllowAnyOrigin());
});

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ApplicationDBContext>(opt =>
    opt.UseNpgsql("Host=localhost;Port=5432;Database=Transfer;Username=postgres;Password=root"));

builder.Services.AddScoped<IApplicationDBContext, ApplicationDBContext>();

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