using JONATHA_PROJETO_WEB_API_01_REPOSITORY.Interface;
using JONATHA_PROJETO_WEB_API_01_REPOSITORY.Repository;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ILeftValue, LeftValueRepository>();
builder.Services.AddScoped<IRightValue, RightValueRepository>();
builder.Services.AddScoped<IGetValue, GetValueRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();

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
