using Domain.Entities;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController(IAccountService accountService): ControllerBase
{
    [HttpGet]
    public ApiResponse<List<Account>> GetAll()
    {
        return accountService.GetAll();
    }
    [HttpGet("{id:int}")]
    public ApiResponse<Account> GetById(int id)
    {
        return accountService.GetById(id);
    }
    [HttpPost]
    public ApiResponse<bool> Add(Account account)
    {
        return accountService.Add(account);
    }
    [HttpPut]
    public ApiResponse<bool> Update(Account account)
    {
        return accountService.Update(account);
    }
    [HttpDelete]
    public ApiResponse<bool> Delete(int id)
    {
        return accountService.Delete(id);
    }
    [HttpGet("sum-Of-All-Balance")]
    public ApiResponse<decimal> GetSumOfAllBalance()
    {
        return accountService.GetSumOfAllBalance();
    }
}