
using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IOC - Dependency Injection

//builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
//builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
//builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();

builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositorySqlServer>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositorySqlServer>();
builder.Services.AddScoped<SqlContext, SqlContext>();

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
