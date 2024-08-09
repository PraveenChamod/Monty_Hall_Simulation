using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("Policy", 
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    } 
    ));

builder.Services.AddSingleton<Random>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<ISimulationService, SimulationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
