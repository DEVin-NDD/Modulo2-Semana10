using Aula2NDD.Infra;
using Aula2NDD.Repositories;
using Aula2NDD.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de Serviços
builder.Services.AddScoped<LogAcao>((s) => new LogAcao("C:\\Logs\\Logs.txt"));
builder.Services.AddScoped<ServicoSMS>();

// Injeção de Repositórios
builder.Services.AddScoped<TipoClienteRepository>();
builder.Services.AddScoped<ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
