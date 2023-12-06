using System.Text.Json.Serialization;

namespace FinancialPlanner.Components.Models
{
    public class AccountHolder
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("accountStaringBalance")]
        public decimal AccountStaringBalance { get; set; }

        // Schedule from the Social Security Administration that one receives shortly before the age of 65
        [JsonPropertyName("socialSecurityPayouts")]
        public List<SocialSecurityPayout> SocialSecurityPayouts { get; set; }

        [JsonPropertyName("scenario")]
        public Scenario Scenario { get; set; }

        [JsonPropertyName("financialEvents")]
        public List<FinancialEvent> FinancialEvents { get; set; }
    }

    public class Scenario
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        //  Age when retiree stops pre-retirement monthly savings contributions and starts expected monthly retirement income

        [JsonPropertyName("retirementAge")]
        public int RetirementAge { get; set; }

        [JsonPropertyName("expectedMonthlyRetirementIncome")]
        public decimal ExpectedMonthlyRetirementIncome { get; set; }

        [JsonPropertyName("preRetirementMonthlySavingsContribution")]
        public decimal PreRetirementMonthlySavingsContribution { get; set; }

        // Selected from the SocialSecurityPayout list to be used in simulation runs
        [JsonPropertyName("socialSecurityPayoutAge")]
        public int SocialSecurityPayoutAge { get; set; }
    }

    public class SocialSecurityPayout
    {
        [JsonPropertyName("startingAge")]
        public int StartingAge { get; set; }

        [JsonPropertyName("monthlyPayout")]
        public decimal MonthlyPayout { get; set;}
    }

    public class FinancialEvent()
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("payload")]
        public decimal[] Payload { get; set; }
    }



}
