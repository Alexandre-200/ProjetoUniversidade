using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositorySqlServer>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositorySqlServer>();
builder.Services.AddScoped<ITipoEventosRepository, TipoEventoRepositorySqlServer>();
builder.Services.AddScoped<IEventosRepository, EventoRepositorySqlServer>();
builder.Services.AddScoped<IInscricaoRepository, InscricaoRepositorySqlServer>();
builder.Services.AddScoped<IParticipanteRepository, ParticipanteRepositorySqlServer>();
builder.Services.AddScoped<IParticipacaoRepository, ParticipacaoRepositorySqlServer>();
builder.Services.AddScoped<SqlContext, SqlContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

/*
é aqui que a magica acontece, em builder.Services.AddScoped sempre que IAlunoRepository é 
injetada é criada uma instância de AlunoRepositorySqlServer isso serve obviamente para as 
linhas 9 até 12.

Inversão de controle -> A chamadas dos métodos é invertida em relação à programação tradicional, 
ou seja, ela não é determinada diretamente pelo programador
*/

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