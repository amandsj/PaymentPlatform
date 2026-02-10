using PaymentPlatform.Application.Interfaces;
using PaymentPlatform.Application.Services;
using PaymentPlatform.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ?? Registrar dependências
builder.Services.AddSingleton<IPaymentRepository, InMemoryPaymentRepository>();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddControllers();
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
