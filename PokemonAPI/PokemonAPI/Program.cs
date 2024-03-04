using PokemonAPI.Interfaces;
using PokemonAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = "localhost";
    options.InstanceName = "local";
});

builder.Services.AddScoped<IPokeApiUrlManager, PokeApiUrlManager>();
builder.Services.AddScoped<IPokeApiCacheManager, PokeApiCacheManager>();
builder.Services.AddScoped<IPokeApiRequestMessageSender, PokeApiRequestMessageSender>();
builder.Services.AddScoped<IPokeApiService, PokeApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();