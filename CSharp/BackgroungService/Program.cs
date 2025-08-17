using Application.interfaces;
using Application.request;
using Application.services;
using Application.workers;

var builder = WebApplication.CreateBuilder(args);

// services.
builder.Services.AddScoped<IProcessingPaymentService, ProcessingPaymentService>();
builder.Services.AddScoped<ISendPaymentNotificationMail, SendPaymentNotificationMail>();

// background services: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-9.0&tabs=net-cli
builder.Services.AddHostedService<ProcessingPaymentWorker>();

var app = builder.Build();

// Create a minimal API with ASP.NET Core: https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio
app.MapPost("/ClientAccount", (ClientAccountRequest request) =>
{
    HostedServiceQueue.QueueAccount.Enqueue(request.Account);

    // TypedResults Class: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.typedresults?view=aspnetcore-9.0
    return Results.Ok();
});

app.Run();
