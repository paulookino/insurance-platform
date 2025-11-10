using Proposta.Application.Interfaces;
using Proposta.Application.Services;
using Proposta.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Application
builder.Services.AddScoped<IPropostaService, PropostaService>();

// Infrastructure
builder.Services.AddPropostaInfrastructure(builder.Configuration);

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
