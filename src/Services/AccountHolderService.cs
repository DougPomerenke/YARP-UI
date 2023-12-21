using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static FinancialPlanner.Components.Pages.ManageAccountHolders;
using FinancialPlanner.Components.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using System.Text.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using FinancialPlanner.Components.Pages;

namespace FinancialPlanner.Services
{

    public class AccountHolderService : IAccountHolderService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private bool getaccountHoldersError;

        public List<AccountHolder> AccountHolders { get; set; } = new List<AccountHolder>();

        public List<Scenario> ScenarioSets { get; set; } = new List<Scenario>();


        public List<FinancialEvent> FinancialEvents { get; set; } = new List<FinancialEvent>();


        public AccountHolderService(HttpClient http, NavigationManager navigationManager, IConfiguration configuration)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
            _configuration = configuration;
        }

        public async Task GetAccountHolders()
        {

            try
            {
                string pathSetting = _configuration.GetSection("ApiUrls:AccountHolders").Value;

                Uri uri = new Uri(pathSetting);

                var result = await _httpClient.GetFromJsonAsync<List<AccountHolder>>(uri);
                if (result != null)
                    AccountHolders = result;
            }
            catch (Exception ex)
            {
                getaccountHoldersError = true;
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<AccountHolder> GetAccountHolder(string id)
        {
                string pathSetting = _configuration.GetSection("ApiUrls:AccountHolders").Value;

                Uri uri = new Uri(pathSetting + id);

            AccountHolder acountHolder = new AccountHolder();

            try
            {
                var acountHolders = await _httpClient.GetFromJsonAsync<List<AccountHolder>>(uri);
                if (acountHolders != null)
                {
                    acountHolder = acountHolders.Where(c=>c.id== id).FirstOrDefault();
                }

            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

            return acountHolder;
        }

        public async Task CreateAccountHolder(AccountHolder accountHolder)
        {
            string pathSetting = _configuration.GetSection("ApiUrls:AccountHolders").Value;

            Uri uri = new Uri(pathSetting);

            var result = await _httpClient.PostAsJsonAsync(uri, accountHolder);
            await SetAccountHolders(result);


        }

        private async Task SetAccountHolders(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<AccountHolder>>();
            AccountHolders = response;
            _navigationManager.NavigateTo("manageaccountholders");
        }


        public async Task UpdateAccountHolder(AccountHolder accountHolder)
        {
            string pathSetting = _configuration.GetSection("ApiUrls:UpdateAccountHolders").Value;

            pathSetting = pathSetting + accountHolder.id;
            Uri uri = new Uri(pathSetting);
            

            var result = await _httpClient.PutAsJsonAsync<AccountHolder>(uri, accountHolder);
            await SetAccountHolders(result);
        }

        public async Task DeleteAccountHolder(string id)
        { 
        
        }

        //Task<IEnumerable<Scenario>> GetScenarios(string pathSetting)
        //{ }

        //Task<IEnumerable<FinancialEvent>> GetFinancialEvents(string pathSetting)
        // { }
    }
}
