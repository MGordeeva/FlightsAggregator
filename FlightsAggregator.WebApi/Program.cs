using FlightsAggregator.Business;
using FlightsAggregator.Business.ExternalService1;
using FlightsAggregator.Business.ExternalService2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddAutoMapper(typeof(ExternalService1MappingProfile));
    services.AddAutoMapper(typeof(ExternalService2MappingProfile));

    services.AddScoped<IFlightAggregatorService, FlightAggregatorService>();
    services.AddScoped<IExternalService1, ExternalService1Mock>();
    services.AddScoped<IExternalService2, ExternalService2Mock>();
}