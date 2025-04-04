using System;
using Graph.API.DataTransfers;

namespace Graph.API.Interface;

public interface IGraphClientIntegration
{
    Task<HealthCheckResponse> HealthChecks();
    Task<CreatePersonResponse>CreatePerson(CreatePersonRequest request);
    Task<FetchPersonResponse>FetchPerson(string person_id);
    Task<ListPeopleResponse>ListPeople();
    Task<UpdatePersonKycResponse>UpgradePersonKYC(UpdatePersonKycRequest request);
    Task<UpdatePersonResponse> UpdatePerson(string person_id, UpdatePersonRequest request);

    Task<CreateBusinessResponse> CreateBusiness(CreateBusinessRequest request);
    Task<FetchBusinessResponse> FetchBusiness(string business_id);
    Task<ListBusinessesResponse> ListBusinesses(int pageNumber, int pageSize);
    Task<CreateAccountResponse>CreateAccount(CreateAccountRequest request);
    Task<FetchAccountResponse> FetchAccount(string account_id);
    Task<UpdateAccountResponse>UpdateAccountStatus(string account_id, UpdateAccountRequest request);
    Task<ListAccountResponse>ListAccount(ListAccountsRequest request);
    Task<WhitelistAccountResponse>AddWhitelistAccount(string account_id, WhitelistAccountRequest request);
    Task<ListWhitelistAccountResponse> ListWhitelistAccounts(string account_id, int page = 1, int perPage = 20);
    Task<RemoveWhiteListAccountResponse> RemoveWhitelistAccount(string account_id, string item_id);
    Task<ClearWhiteListAccountResponse> ClearWhitelistAccounts(string account_id);
    Task<FetchWalletAccountResponse>FetchWalletAccount(string account_id);
    Task<ListWalletAccountResponse> ListAccount(int page = 1, int perPage = 20, string from = "2021-05-30", string to = "2099-05-30", string? currency = null, string? status = null);
    Task<FetchTransactionResponse> FetchTransactions(string transaction_id);
    Task<ListOfTransactionResponse> ListTransactions(int page = 1, int perPage = 20, string from = "", string to = "", string status = "", string currency = "", string accountId = "", string cardId = "", string linkedTransactionId = "", bool asc = false);
    Task<FetchDepositResponse> FetchDeposit(string deposit_id);
    Task<ListDespositResponse> ListDeposits(int pageNum, int pageSize);
    Task<DepositResponse>Deposit(DepositRequest request);
    Task<FetchRateResponse> FetchRates();
    Task<CreatePayoutResponse> CreatePayouts(CreatePayoutRequest request);
    Task<FetchPayoutResponse> FetchPayouts(string payout_id);
    Task<ListOfPayoutResponse> ListPayouts(int pageNum, int pageSize); Task<ListBankReponse> ListBanks();
    Task<ResolveBankAccountResponse> ResolveBankAccount(ResolveBankAccountRequest request);
    
}
