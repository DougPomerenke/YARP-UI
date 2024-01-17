namespace FinancialPlanner.Components.Models
{
    public class ScenarioParameters
    {
        protected string lifeEventDisplayMessage;
        protected string newValue;
        public string LifeEventDisplayMessage
        {
            get
            {
                if (LifeEventType == "StartingYear") { return "Initial Savings Balance"; }
                else if (LifeEventType == "RetirementYear") { return "Monthly Retirement Income"; }
                else if (LifeEventType == "SavingChange") { return "Monthly Savings Contribution"; }
                else if (LifeEventType == "InvestmentYieldChange") { return "Investment Yield Range"; }
                else if (LifeEventType == "InflationRateChange") { return "Inflation Rate Range"; }
                else if (LifeEventType == "SocialSecurityPayoutYear") { return "Monthly Social Security Payment"; }
                else if (LifeEventType == "LoanPayOffYear") { return "Retired Long Term Debt"; }
                else { return LifeEventType; }
            }
        }
        public string LifeEventType { get; set; }
        public int LifeEventStartingYear { get; set; }
        public string DisplayValue
        {
            get
            {
                if (IntValue != null)
                {
                    return string.Format("{0:C}", IntValue);
                }
                else if (DecimalValue != null)
                {
                    return string.Format("{0:C}", DecimalValue);
                }
                else if (DecimalArray != null)
                {
                    if(DecimalArray.Length>1)
                    {
                        return DecimalArray[0].ToString("P01") + " to " + DecimalArray[1].ToString("P01");
                    }
                    else
                    {
                        return DecimalArray[0].ToString("P01");
                    }

                }
                else { return ""; }
            }
            set { }
        }
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public decimal[]? DecimalArray { get; set; }

        public ScenarioParameters(string lifeEventType)
        {
            LifeEventType = lifeEventType;
        }
    }
    public class SocialSecurityPayoutYearDropdownList
    {
        public List<SocialSecurityPayoutYear> socialSecurityPayoutYears { get; set; }
    }

    public class SocialSecurityPayoutYear
    {
        public decimal Age { get; set; }
        public string DisplayValue { get; set; }
    }

}
