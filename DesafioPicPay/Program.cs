using DesafioPicPay.Application.Services.CarteiraService;
using DesafioPicPay.Application.Services.TransacaoService;
using DesafioPicPay.Infrastructure;
using DesafioPicPay.Infrastructure.Repositories.CarteiraRepository;
using DesafioPicPay.Infrastructure.Repositories.Transacao;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbConnection>(options =>
    options.UseNpgsql(builder
    .Configuration
    .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();
builder.Services.AddScoped<ITrasacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<ICarteiraService, CarteiraService>();
builder.Services.AddScoped<ITrasacaoService, TransacaoService>();

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
