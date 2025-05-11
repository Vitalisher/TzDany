using Microsoft.AspNetCore.Mvc;
using PersonalAccount.API.Models;


public interface IAccountService
{
    public Task<ActionResult<Account>> CreateAccountAsync(Account account);
    
    public Task<ActionResult<Account>> GetAccountByIdAsync(int id);
    
    public Task<List<Account>> GetAccountOnlyWithResidents(bool onlyWithResidents);
    
    public Task<List<Account>> GetAccountByOpenedDate(DateTime date);
    
    public Task<List<Account>> GetAccountByFullName(string firstName, string LastName, string middleName);
    
    public Task<List<Account>> GetAccountByAddress(Address address);

}