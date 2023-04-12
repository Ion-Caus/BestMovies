using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BestMovies.Func;

public static class MovieFunctions
{
    [FunctionName("GetMovies")]
    public static async Task<IActionResult> GetMovies(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "movies")]HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request");

        string genre = req.Query["genre"];

        return new OkObjectResult($"Movies .. {genre}");
    }

    [FunctionName("LikeMovie")]
    public static async Task<IActionResult> LikeMovie(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "movies/{id}")] HttpRequest req,
        int id,
        ILogger log)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();


        return new BadRequestObjectResult($"wrong id {id} and body \n {body}");
    }
}