using Microsoft.AspNetCore.Mvc;
using PersonalAccount.API.Models;
using PersonalAccount.DB;

namespace PersonalAccount.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ICollection<Account>>> GetAccount(int id)
    {
        var result = await accountService.GetAccountByIdAsync(id);
        return Ok(result);
    }
    
    [HttpGet("/WithResidents")]
    public async Task<ActionResult<ICollection<Account>>> GetAccountOnlyWithResidents(bool onlyWithResidents)
    {
        var result = await accountService.GetAccountOnlyWithResidents(onlyWithResidents);
        return Ok(result);
    }
    
    [HttpGet("/OpenedDate")]
    public async Task<ActionResult<ICollection<Account>>> GetAccountByOpenedDate(DateTime openedDate)
    {
        var result = await accountService.GetAccountByOpenedDate(openedDate);
        return Ok(result);
    }
    
    [HttpGet("/FullName")]
    public async Task<ActionResult<ICollection<Account>>> GetAccountByFullName(string firstName, string LastName, string middleName)
    {
        var result = await accountService.GetAccountByFullName(firstName, LastName, middleName);
        return Ok(result);
    }
    
    [HttpGet("/Adress")]
    public async Task<ActionResult<ICollection<Account>>> GetAccountByAddress(Address address)
    {
        var result = await accountService.GetAccountByAddress(address);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Account>> Create(Account account)
    {
        await accountService.CreateAccountAsync(account);
        return Ok(account);
    }
}