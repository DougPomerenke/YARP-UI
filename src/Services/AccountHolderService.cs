using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static FinancialPlanner.Components.Pages.ManageAccountHolders;
using FinancialPlanner.Components.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPlanner.Services
{

    public class AccountHolderService : IAccountHolderService
    {
        private readonly HttpClient httpClient;

        public AccountHolderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<AccountHolder>> GetAccountHolders(string pathSetting)
        {
            try
            {
                Uri uri = new Uri(pathSetting);

                httpClient.BaseAddress = uri;

                return await httpClient.GetFromJsonAsync<AccountHolder[]>("api/AccountHolders/accountHolder");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }

        }
    }
}
