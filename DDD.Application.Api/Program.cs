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
� aqui que a m�gica acontece, em builder.Services.AddScoped sempre que IAlunoRepository � 
injetada � criada uma inst�ncia de AlunoRepositorySqlServer isso serve obviamente para as 
linhas 10 at� 18.

Invers�o de controle -> A chamadas dos m�todos � invertida em rela��o � programa��o tradicional, 
ou seja, ela n�o � determinada diretamente pelo programador
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