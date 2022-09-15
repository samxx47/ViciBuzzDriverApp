using Microsoft.Extensions.Options;
using MongoDB.Driver;
using APIsViciBuzz.Models;
using APIsViciBuzz.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MakeOrderStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(MakeOrderStoreDatabaseSettings)));

builder.Services.AddSingleton<IMakeOrderStoreDatabaseSettings>(sp=>
                                                                sp.GetRequiredService<IOptions<MakeOrderStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s=>
                                                new MongoClient(builder.Configuration.GetValue<string> ("MakeOrderStoreDatabaseSettings:ConnectionString") ));

builder.Services.AddScoped<IMakeOrderService, MakeOrderService>();

// Add services to the container.

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
