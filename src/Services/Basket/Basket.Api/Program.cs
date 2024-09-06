
var builder = WebApplication.CreateBuilder(args);
// Add services to the container

builder.Services.AddCarter();

var app = builder.Build();

// configure the http request pipeline
app.MapCarter();

app.Run();
