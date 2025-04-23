using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalAccount.API.Models;
using PersonalAccount.DB;

namespace PersonalAccount.API.Services;

public class AccountService : IAccountService
{
    private readonly AccountContext _dbContext;

    public AccountService(AccountContext dbContext)
    {
        _dbContext = dbContext; 
    }
    public async Task<ActionResult<Account>> CreateAccountAsync(Account account)
    {
        _dbContext.Accounts.Add(account);
        await _dbContext.SaveChangesAsync();
        return account;
    }

    public async Task<ActionResult<Account>> GetAccountByIdAsync(int id)
    {
        var personalAccount = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        if (personalAccount == null)
        {
            return new NotFoundResult();
        }
        
        return personalAccount;

    }
}