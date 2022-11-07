using Microsoft.Extensions.Options;
using MongoDB.Driver;
using APIsViciBuzz.Models;
using APIsViciBuzz.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MakeOrderStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(MakeOrderStoreDatabaseSettings)));

builder.Services.Configure<DeliverOrderStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(DeliverOrderStoreDatabaseSettings)));

builder.Services.AddSingleton<IMakeOrderStoreDatabaseSettings>(sp=>
                                                                sp.GetRequiredService<IOptions<MakeOrderStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
                                                new MongoClient(builder.Configuration.GetValue<string>("MakeOrderStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IMakeOrderService, MakeOrderService>();


//Deliver order 
builder.Services.AddSingleton<IDeliverOrderStoreDatabaseSettings>(sp =>
                                                                sp.GetRequiredService<IOptions<DeliverOrderStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
                                                new MongoClient(builder.Configuration.GetValue<string>("DeliverOrderStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IDeliverOrderService, DeliverOrderService>();




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
