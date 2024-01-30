using System.Text.Json.Serialization;

namespace FinancialPlanner.Components.Models
{
    public class AccountHolder
    {
        private List<Scenario> scenarios;
        private List<FinancialEvent> financialEvents;
        private List<SocialSecurityPayout> socialSecurityPayouts;

        [JsonPropertyName("id")]
        public string? id { get; set; }
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonPropertyName("accountStartingBalance")]
        public decimal? AccountStartingBalance { get; set; }

        // Schedule from the Social Security Administration that one receives shortly before the age of 65
        [JsonPropertyName("socialSecurityPayouts")]
        public List<SocialSecurityPayout>? SocialSecurityPayouts
        {
            get { return this.socialSecurityPayouts; }
            set { this.socialSecurityPayouts = value; }
        }
        [JsonPropertyName("scenarios")]
        public List<Scenario>? Scenarios
        {
            get { return this.scenarios; }
            set { this.scenarios = value; }
        }
        [JsonPropertyName("financialEvents")]
        public List<FinancialEvent>? FinancialEvents
        {
            get { return this.financialEvents; }
            set { this.financialEvents = value; }
        }
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        public AccountHolder()
        {
            this.id = "";
            this.scenarios = new List<Scenario>();
            Scenario scenario = new Scenario();
            this.scenarios.Add(scenario);

            this.financialEvents = new List<FinancialEvent>();

            FinancialEvent fe = new FinancialEvent("StartingYear");
            this.financialEvents.Add(fe);
            fe = new FinancialEvent("InflationRateChange");
            this.financialEvents.Add(fe);
            fe = new FinancialEvent("InvestmentYieldChange");
            this.financialEvents.Add(fe);
            fe = new FinancialEvent("SocialSecurityPayoutYear");
            this.financialEvents.Add(fe);
            fe = new FinancialEvent("LoanPayOffYear");
            this.financialEvents.Add(fe);

            this.socialSecurityPayouts = new List<SocialSecurityPayout>();

            SocialSecurityPayout payout = new SocialSecurityPayout();
            payout.StartingAge = 65;
            socialSecurityPayouts.Add(payout);
            payout = new SocialSecurityPayout();
            payout.StartingAge = 66;
            socialSecurityPayouts.Add(payout);
            payout = new SocialSecurityPayout();
            payout.StartingAge = 67; // 66 and 8 months
            socialSecurityPayouts.Add(payout);
            payout = new SocialSecurityPayout();
            payout.StartingAge = 68;
            socialSecurityPayouts.Add(payout);
            payout = new SocialSecurityPayout();
            payout.StartingAge = 69;
            socialSecurityPayouts.Add(payout);
            payout = new SocialSecurityPayout();
            payout.StartingAge = 70;
            socialSecurityPayouts.Add(payout);
        }
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

    public class FinancialEvent
    {
        private Guid id;

        private decimal[]? payload;
        private string type;

        public Guid Id
        {
            get { return this.id; }
        }
        [JsonPropertyName("type")]
        public string Type 
        {
            get { return this.type; }
            set { this.type = value; }
        }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("payload")]
        public decimal[] Payload 
        {
            get { return this.payload; }
            set { this.payload = value; } 
        }

        public FinancialEvent(string type)
        {
            this.id = Guid.NewGuid();   
            this.payload = new decimal[2];
            this.payload[0] = 0;
            this.payload[1] = 0;
            this.type = type;
        }
    }

    public enum FinancialEventType
    {
        StartingYear,
        RetirementYear,
        SavingChange,
        InvestmentYieldChange,
        InflationRateChange,
        SocialSecurityPayoutYear,
        LoanPayOffYear
    }

}
