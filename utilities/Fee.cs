using Newtonsoft.Json;

namespace LemCalculator.utilities
{
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
}