using Contratacao.Application;
using Contratacao.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Camadas
builder.Services.AddContratacaoApplication();
builder.Services.AddContratacaoInfrastructure(builder.Configuration);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
