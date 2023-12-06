using System.Text.Json.Serialization;

namespace FinancialPlanner.Components.Models
{
    public class AccountBalanceMetrix
    {
        [JsonPropertyName("currentYear")]
        public int CurrentYear { get; set; }
        [JsonPropertyName("currentAge")]
        public int CurrentAge { get; set; }
        [JsonPropertyName("startingBalance")]
        public decimal StartingBalance { get; set; }
        [JsonPropertyName("endingBalance")]
        public decimal EndingBalance { get; set; }
        [JsonPropertyName("annualSavingsContribution")]
        public decimal AnnualSavingsContribution { get; set; }
        [JsonPropertyName("desiredMonthlyIncome")]
        public decimal DesiredMonthlyIncome { get; set; }
        [JsonPropertyName("socialSecurityMonthlyIncome")]
        public decimal SocialSecurityMonthlyIncome { get; set; }
        [JsonPropertyName("annualSavingsChange")]
        public decimal AnnualSavingsChange { get; set; }
        [JsonPropertyName("annualInvestmentChange")]
        public decimal AnnualInvestmentChange { get; set; }
        [JsonPropertyName("annualInflationRate")]
        public decimal AnnualInflationRate { get; set; }
        [JsonPropertyName("annualInvestmentRateOfReturn")]
        public decimal AnnualInvestmentRateOfReturn { get; set; }
    }
}
