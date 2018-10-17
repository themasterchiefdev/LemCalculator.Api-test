using Newtonsoft.Json;

    namespace LemCalculator.utilities
    {
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
    }