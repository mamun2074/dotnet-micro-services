
var builder = WebApplication.CreateBuilder(args);
// Add services to the container

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    // Validation behavior
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    // log behavior
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

// Fluent Validatoin 
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

// add custome exception handler
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();
// configure the http request pipeline
app.MapCarter();

// configure exception option
app.UseExceptionHandler(option => { });


app.Run();
