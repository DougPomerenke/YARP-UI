using FinancialPlanner.Components.Models;

namespace FinancialPlanner.Services
{

    public interface IAccountHolderService
    {
        List<AccountHolder> AccountHolders { get; set; }

       // List<Scenario> Scenarios { get; set; }


       // List<FinancialEvent> FinancialEvents { get; set; }


        Task GetAccountHolders();

        Task<AccountHolder> GetAccountHolder(string id);

        Task CreateAccountHolder(AccountHolder accountHolder);
        Task UpdateAccountHolder(AccountHolder accountHolder);
        Task DeleteAccountHolder(string id);

        //Task<IEnumerable<Scenario>> GetScenarios(string pathSetting);

        //Task<IEnumerable<FinancialEvent>> GetFinancialEvents(string pathSetting);
    }
}
