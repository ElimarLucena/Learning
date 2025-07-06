using Application.services;
using Application.workers;

var builder = WebApplication.CreateBuilder(args);

// services.
builder.Services.AddScoped<IProcessingPaymentService, ProcessingPaymentService>();

// background services.
builder.Services.AddHostedService<ProcessingPaymentWorker>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
