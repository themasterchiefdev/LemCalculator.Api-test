using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LemCalculator
{
    public static class RespondWithBankData
    {
        [FunctionName("RespondWithBankData")]
        public static IActionResult Run(
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

    public class BankDetails
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "bankWebsite")]
        public string BankWebsite { get; set; }

        [JsonProperty(PropertyName = "bankLvrLink")]
        public string BankLvrLink { get; set; }

        [JsonProperty(PropertyName = "fee")]
        public Fee Fee { get; set; }
    }

    /// <summary>
    /// This class is used to return the Fees slabs
    /// The property names should match the output names described in the JSON file
    /// </summary>
    public class Fee
    {
        [JsonProperty(PropertyName = "loanOver95")]
        public decimal LoanOver95 { get; set; }

        [JsonProperty(PropertyName = "loanBetween90To95")]
        public decimal LoanBetween90To95 { get; set; }

        [JsonProperty(PropertyName = "loanBetween85to90")]
        public decimal LoanBetween85To90 { get; set; }

        [JsonProperty(PropertyName = "loanBetween80to85")]
        public decimal LoanBetween80To85 { get; set; }
    }

    public class ParseDataFile
    {
        public IList<BankDetails> LoadJson()
        {
            IList<BankDetails> items = new List<BankDetails>();
            try
            {
                using (var reader = new StreamReader("./utilities/lemdata.json"))
                {
                    var json = reader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<BankDetails>>(json);
                }

                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return items;
        }
    }
}