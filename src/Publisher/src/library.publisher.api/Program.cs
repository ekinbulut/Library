using Library.Publisher.Data.Repositories;
using Library.Publisher.Service;
using Library.Publisher.Service.Settings;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();


var mongoConnection = builder.Configuration.GetSection(PublisherServiceConstants.MongoSettingsConstants)
                .Get<MongoSettings>();

builder.Services.AddSingleton<IMongoClient, MongoClient>(t => new MongoClient(mongoConnection.Url));

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
