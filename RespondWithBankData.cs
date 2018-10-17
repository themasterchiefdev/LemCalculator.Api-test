using LemCalculator.utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LemCalculator
{
    public static class RespondWithBankData
    {
        [FunctionName("RespondWithBankData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation("Hello, Rajiv!");
            try
            {
                var elmData = new ParseDataFile();
                log.LogInformation($"{JsonConvert.SerializeObject(elmData.LoadJson().ToList())}");
                return new OkObjectResult($"{JsonConvert.SerializeObject(elmData.LoadJson().ToList())}");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Something un-expected has happened. " + e.Message);
            }

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}