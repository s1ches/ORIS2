using System.Net;
using LiveStreamingServerNet;
using LiveStreamingServerNet.Flv.Installer;
using LiveStreamingServerNet.Networking.Helpers;
using TeamHost.Persistence.Extensions;

await using var liveStreamingServer = LiveStreamingServerBuilder.Create()
    .ConfigureRtmpServer(options => options.AddFlv())
    .ConfigureLogging(options => options.AddConsole())
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBackgroundServer(liveStreamingServer, new IPEndPoint(IPAddress.Any, 1935));
builder.Services.AddHttpClient();
builder.Services.AddLogging();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddPersistenceLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebSockets();
app.UseWebSocketFlv(liveStreamingServer);

app.UseHttpFlv(liveStreamingServer);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Home}/{controller=Home}/{action=Index}");

app.Run();