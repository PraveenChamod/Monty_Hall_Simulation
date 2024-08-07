using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Random>();
builder.Services.AddTransient<IGame, Game>();
builder.Services.AddTransient<ISimulation, Simulation>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
