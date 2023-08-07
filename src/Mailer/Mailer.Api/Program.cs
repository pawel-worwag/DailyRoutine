using System.Reflection;
using DailyRoutine.Shared.Infrastructure.Exceptions;
using Mailer.Api.BackgroudServices;
using Mailer.Application;
using Mailer.Infrastructure;
using Mailer.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.CustomSchemaIds(type => type.FullName?.Replace("Mailer.Application.",""));
});

builder.Services.AddHostedService<MailBusConsumerService>();

var app = builder.Build();

app.UseErrorHandling();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
