using DataBaseFirstApproach.Models;
using DataBaseFirstApproach.NewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlPracticeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CricketerConnection"));
});
//here Connection for Cte Tables 
builder.Services.AddDbContext<SqlPracticeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CteConnection"));
});

builder.Services.AddDbContext<DbfirstContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbFIrstConnection"));
});

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
