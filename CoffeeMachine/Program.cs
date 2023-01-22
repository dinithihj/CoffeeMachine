using CoffeeMachine.Helpers;
using CoffeeMachine.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ICounterService, CounterService>();
builder.Services.AddScoped<IDateTimeHelper, DateTimeHelper>();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();
builder.Services.AddScoped<IWeatherApiHelper, WeatherApiHelper>();
builder.Services.AddScoped<IWeatherService, WeatherService>();


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
