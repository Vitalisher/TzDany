using Microsoft.AspNetCore.Mvc;
using PersonalAccount.API.Models;


public interface IAccountService
{
    public Task<ActionResult<Account>> CreateAccountAsync(Account account);
    
    public Task<ActionResult<Account>> GetAccountByIdAsync(int id);
    
}