using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Graph.API.DataTransfers;
using Graph.API.Interface;
using Graph.API.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Graph.API.Integrations;

public class GraphClientIntegration : IGraphClientIntegration
{
    private readonly HttpClient _client;
    private readonly GraphSettings _graphSettings;
    public GraphClientIntegration(HttpClient httpClient, IOptions<GraphSettings> graphSettings)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        _client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _client.DefaultRequestHeaders.Add("User-Agent", "Custom User Agent");
        _client.Timeout = TimeSpan.FromMinutes(30);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        _graphSettings = graphSettings.Value;
    }

    public async Task<T> GetAsync<T>(string relativePath, Dictionary<string, string>? content = null)
    {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, relativePath));
            var request = new HttpRequestMessage() { RequestUri = requestUrl, Method = HttpMethod.Get };

            // request.Headers.Add("Bearer", );

            if (content != null) request.Content = new FormUrlEncodedContent(content);

            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
    }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(string.Concat(_graphSettings.BaseUrl, relativePath));
           var uriBuilder = new UriBuilder(endpoint);
            if (!string.IsNullOrEmpty(queryString))
            {
                uriBuilder.Query = queryString;
            }
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Common method for making POST calls
        /// </summary>
        public async Task<T> PostAsync<T>(string relativePath, object content, string? token = null)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, relativePath));
            var request = new HttpRequestMessage() { RequestUri = requestUrl, Method = HttpMethod.Post, Content = CreateHttpContent(content) };
           
            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response from Mail Service:: " + data);

            return JsonConvert.DeserializeObject<T>(data);
        }


        public async Task<T> PutAsync<T>(string relativePath, object content, string? token = null)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, relativePath));
            var request = new HttpRequestMessage() { RequestUri = requestUrl, Method = HttpMethod.Put, Content = CreateHttpContent(content) };       

            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response from Mail Service:: " + data);

            return JsonConvert.DeserializeObject<T>(data);
        }


        public async Task<T> PatchAsync<T>(string relativePath, object content, string? token = null)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, relativePath));
            var request = new HttpRequestMessage() { RequestUri = requestUrl, Method = HttpMethod.Patch, Content = CreateHttpContent(content) };

            // if (token is not null) request.Headers.Add("Bearer", token);
           
            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response from Mail Service:: " + data);

            return JsonConvert.DeserializeObject<T>(data);
        }

        public async Task<T> DeleteAsync<T>(string relativePath, string? token = null)
        {
            Uri requestUrl = CreateRequestUri(relativePath);

            var request = new HttpRequestMessage(HttpMethod.Delete, requestUrl);

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response from Mail Service:: " + data);

            return JsonConvert.DeserializeObject<T>(data) ?? throw new Exception("Failed to deserialize response");
        }


        private HttpContent CreateHttpContent(object content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }


        #region HealthCheck

            public async Task<HealthCheckResponse> HealthChecks()
            {
                var response = await GetAsync<HealthCheckResponse>("/health");
                return response ?? new HealthCheckResponse();
            }

        #endregion HealthCheck


        #region People
         public async Task<CreatePersonResponse>CreatePerson(CreatePersonRequest request)
         {
            var response = await PostAsync<CreatePersonResponse>("/person",request);
            return response ?? new CreatePersonResponse();
         }

         public async Task<FetchPersonResponse>FetchPerson(string person_id)
         {
            var response = await GetAsync<FetchPersonResponse>($"/person/{person_id}");
            return response ?? new FetchPersonResponse();
         }

         public async Task<ListPeopleResponse>ListPeople()
         {
            var response = await GetAsync<ListPeopleResponse>("/person");
            return response ?? new ListPeopleResponse();
         }

         public async Task<UpdatePersonKycResponse>UpgradePersonKYC(UpdatePersonKycRequest request)
         {
            var requestBody = new
            {
                id_type = request.IdType, 
                id_number = request.IdNumber,
                id_country = request.IdCountry, 
                id_upload = request.IdUpload
            };

           var response = await PatchAsync<UpdatePersonKycResponse>($"/person/{request.PersonId}/kyc", requestBody);
             Console.WriteLine("KYC Upgrade Successful: " + response);

            return response ?? new UpdatePersonKycResponse();
         }

         public async Task<UpdatePersonResponse> UpdatePerson(string person_id, UpdatePersonRequest request)
         {
            var response = await PatchAsync<UpdatePersonResponse>($"/person/{person_id}", request);
             return response ?? new UpdatePersonResponse(); 
         }

        #endregion People

        
        #region  Businesses

        public async Task<CreateBusinessResponse> CreateBusiness(CreateBusinessRequest request)
        {
             var response = await PostAsync<CreateBusinessResponse>($"/business", request);
             return response ?? new CreateBusinessResponse();
        }

        public async Task<FetchBusinessResponse> FetchBusiness(string business_id)
        {
            var response = await GetAsync<FetchBusinessResponse>($"/business/{business_id}");
            return response ?? new FetchBusinessResponse();
        }

        public async Task<ListBusinessesResponse> ListBusinesses(int pageNumber, int pageSize)
        {
            var response = await GetAsync<ListBusinessesResponse>($"/business?page={pageNumber}&per_page={pageSize}");
            return response ?? new ListBusinessesResponse();
        }

        #endregion Businesses

        #region  Bank Accounts

           public async Task<CreateAccountResponse>CreateAccount(CreateAccountRequest request)
           {
              var response = await PostAsync<CreateAccountResponse>($"/bank_account", request);
              return response ?? new CreateAccountResponse();
           }

           public async Task<FetchAccountResponse> FetchAccount(string account_id)
           {
              var response = await GetAsync<FetchAccountResponse>($"/bank_account/{account_id}");
              return response ?? new FetchAccountResponse();
           }

           public async Task<UpdateAccountResponse>UpdateAccountStatus(string account_id, UpdateAccountRequest request)
           {
               var response = await PatchAsync<UpdateAccountResponse>($"/bank_account/{account_id}", request);
                return response ?? new UpdateAccountResponse();;
           }

           public async Task<ListAccountResponse>ListAccount(ListAccountsRequest request)
           {
             var queryParams = new List<string>();

                if (request.Page > 0) queryParams.Add($"page={request.Page}");
                if (request.PerPage > 0) queryParams.Add($"per_page={request.PerPage}");
                if (!string.IsNullOrEmpty(request.From)) queryParams.Add($"from={request.From}");
                if (!string.IsNullOrEmpty(request.To)) queryParams.Add($"to={request.To}");
                if (!string.IsNullOrEmpty(request.SettlementCurrency)) queryParams.Add($"settlement_currency={request.SettlementCurrency}");
                if (!string.IsNullOrEmpty(request.Currency)) queryParams.Add($"currency={request.Currency}");
                if (!string.IsNullOrEmpty(request.Label)) queryParams.Add($"label={request.Label}");
                if (!string.IsNullOrEmpty(request.Status)) queryParams.Add($"status={request.Status}");
                if (!string.IsNullOrEmpty(request.Provider)) queryParams.Add($"provider={request.Provider}");
                if (!string.IsNullOrEmpty(request.Kind)) queryParams.Add($"kind={request.Kind}");
                if (!string.IsNullOrEmpty(request.Type)) queryParams.Add($"type={request.Type}");
                if (!string.IsNullOrEmpty(request.HolderType)) queryParams.Add($"holder_type={request.HolderType}");
                if(request.AutoSweepEnabled.HasValue) queryParams.Add($"autosweep_enabled={request.AutoSweepEnabled.Value.ToString().ToLower()}");

                string queryString = queryParams.Any() ? $"?{string.Join("&", queryParams)}" : "";
                var requestUrl = $"/bank_account{queryString}";

                 var response = await GetAsync<ListAccountResponse>(requestUrl);
                 return response ?? new ListAccountResponse();
           }


            #region Whitelist Bank Accounts

                public async Task<WhitelistAccountResponse>AddWhitelistAccount(string account_id, WhitelistAccountRequest request)
                {
                    var response =  await PostAsync<WhitelistAccountResponse>($"/bank_account/{account_id}/whitelist", request);
                     return response ?? new WhitelistAccountResponse();
                }


                public async Task<ListWhitelistAccountResponse> ListWhitelistAccounts(string account_id, int page = 1, int perPage = 20)
                {
                    var requestUrl = $"/bank_account/{account_id}/whitelist?page={page}&per_page={perPage}";
                    var response = await GetAsync<ListWhitelistAccountResponse>(requestUrl);
                    return response ?? new ListWhitelistAccountResponse();
                }

                public async Task<RemoveWhiteListAccountResponse> RemoveWhitelistAccount(string account_id, string item_id)
                {
                    var response = await DeleteAsync<RemoveWhiteListAccountResponse>($"/bank_account/{account_id}/whitelist/{item_id}");
                    return response ?? new RemoveWhiteListAccountResponse();
                }


                public async Task<ClearWhiteListAccountResponse> ClearWhitelistAccounts(string account_id)
                {
                    var response = await DeleteAsync<ClearWhiteListAccountResponse>($"/bank_account/{account_id}/whitelist (COPY)");
                    return response ?? new ClearWhiteListAccountResponse();
                }

            #endregion Whitelist Bank Accounts

        #endregion Bank Accounts



        #region Wallet Accounts
        // Wallet Accounts
        // Virtual Bank Accounts for Individual and Businesses

        public async Task<FetchWalletAccountResponse>FetchWalletAccount(string account_id)
        {
            var response = await GetAsync<FetchWalletAccountResponse>($"/wallet_account/{account_id}");
            return response ?? new FetchWalletAccountResponse();
        }

        public async Task<ListWalletAccountResponse> ListAccount(int page = 1, int perPage = 20, string from = "2021-05-30", string to = "2099-05-30", string? currency = null, string? status = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "per_page", perPage.ToString() },
                { "from", from },
                { "to", to }
            };

            if (!string.IsNullOrEmpty(currency)) queryParams.Add("currency", currency);
            if (!string.IsNullOrEmpty(status)) queryParams.Add("status", status);

            var response = await GetAsync<ListWalletAccountResponse>($"/wallet_account?{queryParams}");
            return response ?? new ListWalletAccountResponse();
        }

        #endregion Wallet Accounts


        #region  Transactions

            public async  Task<FetchTransactionResponse> FetchTransactions(string transaction_id)
            {
                var response = await GetAsync<FetchTransactionResponse>($"/transaction/{transaction_id}");
                return response ?? new FetchTransactionResponse();
            }

            public async Task<ListOfTransactionResponse> ListTransactions(int page = 1, int perPage = 20, string from = "", string to = "", string status = "", string currency = "", string accountId = "", string cardId = "", string linkedTransactionId = "", bool asc = false)
            {
                var queryParams = new Dictionary<string, string>
                {
                    { "page", page.ToString() },
                    { "per_page", perPage.ToString() },
                    { "asc", asc.ToString().ToLower() }
                };

                if (!string.IsNullOrEmpty(from)) queryParams.Add("from", from);
                if (!string.IsNullOrEmpty(to)) queryParams.Add("to", to);
                if (!string.IsNullOrEmpty(status)) queryParams.Add("status", status);
                if (!string.IsNullOrEmpty(currency)) queryParams.Add("currency", currency);
                if (!string.IsNullOrEmpty(accountId)) queryParams.Add("account_id", accountId);
                if (!string.IsNullOrEmpty(cardId)) queryParams.Add("card_id", cardId);
                if (!string.IsNullOrEmpty(linkedTransactionId)) queryParams.Add("linked_transaction_id", linkedTransactionId);

                var response = await GetAsync<ListOfTransactionResponse>($"/transaction?{queryParams}");
                return response ?? new ListOfTransactionResponse();
            }

        #endregion Transactions


        #region Deposit

            public async Task<FetchDepositResponse> FetchDeposit(string deposit_id)
            {
                var response =  await GetAsync<FetchDepositResponse>($"/deposit/{deposit_id}");
                return response ?? new FetchDepositResponse();
            }

            public async Task<ListDespositResponse> ListDeposits(int pageNum, int pageSize)
            {
                var response = await GetAsync<ListDespositResponse>($"/deposit?page={pageNum}&per_page={pageSize}");
                return response ?? new ListDespositResponse();
            }

            public async Task<DepositResponse>Deposit(DepositRequest request)
            {
                var response =  await PostAsync<DepositResponse>("/deposit/mock", request);
                return response ?? new DepositResponse();
            }

        #endregion Deposit


        #region  Rates

            public async Task<FetchRateResponse> FetchRates()
            {
                var response = await GetAsync<FetchRateResponse>("/rate");
                return response ?? new FetchRateResponse();
            }

        #endregion Rates

      
      #region  Payouts

        public async Task<CreatePayoutResponse> CreatePayouts(CreatePayoutRequest request)
        {
            var response =  await PostAsync<CreatePayoutResponse>("/payout", request);
            return response ?? new CreatePayoutResponse();
        }

        public async Task<FetchPayoutResponse> FetchPayouts(string payout_id)
        {
            var response = await GetAsync<FetchPayoutResponse>($"/payout/{payout_id}");
            return response ?? new FetchPayoutResponse();
        }

        public async Task<ListOfPayoutResponse> ListPayouts(int pageNum, int pageSize)
        {
            var response = await GetAsync<ListOfPayoutResponse>($"/payout?page={pageNum}?per_page={pageSize}");
            return response ?? new ListOfPayoutResponse();
        }

      #endregion Payouts


      #region Banks

        public async Task<ListBankReponse> ListBanks()
        {
           var response = await GetAsync<ListBankReponse>("/bank");
           return response ?? new ListBankReponse();
        }

        public async Task<ResolveBankAccountResponse> ResolveBankAccount(ResolveBankAccountRequest request)
        {
            var response = await PostAsync<ResolveBankAccountResponse>("/bank/resolve/account", request);
            return response ?? new ResolveBankAccountResponse();
        }

      #endregion Banks
      
}
