using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalAccount.API.Models;
using PersonalAccount.DB;
using SQLitePCL;

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

    public async Task<List<Account>> GetAccountOnlyWithResidents(bool onlyWithResidents)
    {
        var request = _dbContext.Accounts.Include(a => a.Residents).AsQueryable();
        
        if (onlyWithResidents)
        {
            request = request.Where(a => a.Residents.Count > 0);
            return await request.ToListAsync();
        }

        return request.ToList();
    }

    public Task<List<Account>> GetAccountByOpenedDate(DateTime date)
    {
        
        var request = _dbContext.Accounts.Where(r => r.StartDate == date ); 
        return request.ToListAsync();
    }

    public Task<List<Account>> GetAccountByFullName(string firstName, string lastName, string middleName)
    {
        var request = _dbContext.Accounts.AsQueryable();

        if (!string.IsNullOrEmpty(firstName))
        {
            request = request.Where(r => r.Residents.Any(res => res.FirstName == firstName));
        }

        if (!string.IsNullOrEmpty(lastName))
        {
            request = request.Where(r => r.Residents.Any(res => res.LastName == lastName));
        }

        if (!string.IsNullOrEmpty(middleName))
        {
            request = request.Where(r => r.Residents.Any(res => res.MiddleName == middleName));
        }

        return request.ToListAsync();
    }
    

    public async Task<List<Account>> GetAccountByAddress(Address address)
    {
        var request = _dbContext.Accounts.Where(r => r.Address == address);
        
        return await request.ToListAsync();
    }
}