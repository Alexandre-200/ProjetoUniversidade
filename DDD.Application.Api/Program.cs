using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAlunoRepository, AlunoRepositorySqlServer>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepositorySqlServer>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepositorySqlServer>();
builder.Services.AddScoped<SqlContext, SqlContext>();

/*

é aqui que a magica acontece, em builder.Services.AddScoped sempre que IAlunoRepository é 
injetada é criada uma instância de AlunoRepositorySqlServer isso serve obviamente para as 
linhas 9 até 12.
 
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