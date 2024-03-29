using System.Buffers;
using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;

[Area("Main")]
public class StreamController(HttpClient client) : Controller
{
    public IActionResult Streams() => View();

    public IActionResult StreamPage() => View();
    
    public async Task GetStream(CancellationToken cancellationToken)
    {
        var message = new HttpRequestMessage();
        message.RequestUri = new Uri("https://localhost:44318/live/demo.flv");
        message.Method = HttpMethod.Get;

        var response = await client.SendAsync(message, cancellationToken);

        await Response.BodyWriter.WriteAsync(await response.Content.ReadAsByteArrayAsync(cancellationToken),
            cancellationToken);
        await Response.Body.FlushAsync(cancellationToken);
    }
}