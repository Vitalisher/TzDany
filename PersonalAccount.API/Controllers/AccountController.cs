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
    
    [HttpPost]
    public async Task<ActionResult<Account>> Create(Account account)
    {
        await accountService.CreateAccountAsync(account);
        return Ok(account);
    }
}