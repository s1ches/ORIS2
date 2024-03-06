using System.Reflection;
using PokemonAPI.Interfaces;
using PokemonAPI.Middlewares;
using PokemonAPI.Models.Properties.PokemonInfoProperties;
using PokemonAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<ExceptionMiddleware>();

builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost");

builder.Services.AddScoped<IPokeApiUrlManager, PokeApiUrlManager>();
builder.Services.AddScoped<ICacheManager, CacheManager>();
builder.Services.AddScoped<IPokeApiRequestMessageSender, PokeApiRequestMessageSender>();
builder.Services.AddScoped<IPokeApiService, PokeApiService>();
builder.Services.AddScoped<ISearchFilter<PokemonInfo>, SearchFilter>();

builder.Services.AddCors(opt => 
    opt.AddPolicy("AllowAnyOrigin", policy => policy.AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors(opt => opt.AllowAnyOrigin());

app.UseMiddleware<ExceptionMiddleware>();

app.Run();