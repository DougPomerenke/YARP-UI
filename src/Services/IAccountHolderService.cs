using FinancialPlanner.Components.Models;

namespace FinancialPlanner.Services
{

    public interface IAccountHolderService
    {
        Task<IEnumerable<AccountHolder>> GetAccountHolders(string pathSetting);
    }
}
